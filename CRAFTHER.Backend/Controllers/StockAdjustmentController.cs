// Path: CRAFTHER.Backend/Controllers/StockAdjustmentController.cs
using CRAFTHER.Backend.Data; // Keep this using for ApplicationDbContext if still needed for other base methods or utility.
using CRAFTHER.Backend.Models; // Keep for models directly used if needed for return types or type checking.
using CRAFTHER.Backend.DTOs.StockAdjustments; // Use new DTOs
using CRAFTHER.Backend.Services; // Use the new service interface
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims; // For HttpContext.User.FindFirst
using System.Threading.Tasks;
using CRAFTHER.Backend.DTOs;

namespace CRAFTHER.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Requires authentication for all actions in this controller
    public class StockAdjustmentController : ControllerBase
    {
        private readonly IStockAdjustmentService _stockAdjustmentService;
        // private readonly ApplicationDbContext _context; // Can be removed if no direct context access is needed

        public StockAdjustmentController(IStockAdjustmentService stockAdjustmentService) // Inject the service
        {
            _stockAdjustmentService = stockAdjustmentService;
            // _context = context; // Remove if not used
        }

        /// <summary>
        /// Helper method to retrieve the OrganizationId from the current user's claims.
        /// </summary>
        /// <returns>The OrganizationId of the logged-in user.</returns>
        /// <exception cref="InvalidOperationException">Thrown if Organization ID is not found in user claims.</exception>
        private Guid GetUserOrganizationId()
        {
            var orgIdClaim = User.FindFirst("OrganizationId")?.Value; // Access User from ControllerBase
            if (string.IsNullOrEmpty(orgIdClaim) || !Guid.TryParse(orgIdClaim, out Guid orgId))
            {
                throw new InvalidOperationException("Organization ID claim not found or invalid.");
            }
            return orgId;
        }

        // --- API Endpoints for StockAdjustmentType (Master Data) ---
        // Assuming StockAdjustmentTypes are global and can be fetched directly from context
        // If you need a service for StockAdjustmentType, you can create one.
        // For simplicity, we'll fetch directly from context here if it's just master data.
        // If StockAdjustmentType is exposed through a service, replace _context.StockAdjustmentTypes with that service call.
        // (Keeping it as is for now, as it's typically simple master data lookup)

        /// <summary>
        /// Retrieves all available stock adjustment types.
        /// </summary>
        /// <returns>A list of StockAdjustmentType objects.</returns>
        [HttpGet("Types")]
        [AllowAnonymous] // Master data might not require authorization
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StockAdjustmentType>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StockAdjustmentType>>> GetStockAdjustmentTypes()
        {
            try
            {
                // Note: StockAdjustmentType is typically master data, so no organization filtering is needed here.
                // If it becomes organization-specific, adjust accordingly.
                // Assuming _context is still available for simple master data retrieval, or inject a dedicated service for it.
                return Ok(await _stockAdjustmentService.GetAllStockAdjustmentTypesAsync()); // Assuming service has this method
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error retrieving stock adjustment types: {ex.Message}" });
            }
        }

        // --- API Endpoints for StockAdjustment (CRUD operations) ---

        /// <summary>
        /// Retrieves all stock adjustments for the current user's organization.
        /// </summary>
        /// <returns>A list of StockAdjustmentResponseDto objects.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StockAdjustmentResponseDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StockAdjustmentResponseDto>>> GetAllStockAdjustments()
        {
            try
            {
                var userOrgId = GetUserOrganizationId();
                var adjustments = await _stockAdjustmentService.GetAllStockAdjustmentsAsync(userOrgId);
                return Ok(adjustments);
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(new { message = ex.Message }); // e.g., OrganizationId claim missing
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error retrieving stock adjustments: {ex.Message}" });
            }
        }

        /// <summary>
        /// Retrieves a specific stock adjustment by its ID for the current user's organization.
        /// </summary>
        /// <param name="id">The ID of the stock adjustment.</param>
        /// <returns>A StockAdjustmentResponseDto object if found, otherwise NotFound.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockAdjustmentResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StockAdjustmentResponseDto>> GetStockAdjustmentById(Guid id)
        {
            try
            {
                var userOrgId = GetUserOrganizationId();
                var stockAdjustment = await _stockAdjustmentService.GetStockAdjustmentByIdAsync(id, userOrgId);

                if (stockAdjustment == null)
                {
                    return NotFound();
                }
                return Ok(stockAdjustment);
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error retrieving stock adjustment: {ex.Message}" });
            }
        }

        /// <summary>
        /// Creates a new stock adjustment and updates the component's current stock quantity. Requires Admin or Manager role.
        /// </summary>
        /// <param name="createDto">The StockAdjustment data to create.</param>
        /// <returns>The created StockAdjustmentResponseDto object.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")] // Only Admin or Manager roles can create adjustments
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StockAdjustmentResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status409Conflict)] // For insufficient stock or business rules
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StockAdjustmentResponseDto>> CreateStockAdjustment([FromBody] CreateStockAdjustmentDto createDto)
        {
            try
            {
                var userOrgId = GetUserOrganizationId();
                var createdStockAdjustment = await _stockAdjustmentService.CreateStockAdjustmentAsync(createDto, userOrgId);
                return CreatedAtAction(nameof(GetStockAdjustmentById), new { id = createdStockAdjustment.AdjustmentId }, createdStockAdjustment);
            }
            catch (InvalidOperationException ex) // Business rule violations from service
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex) // Invalid input data
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error creating stock adjustment: {ex.Message}" });
            }
        }

        /// <summary>
        /// Updates an existing stock adjustment and re-calculates the component's current stock quantity. Requires Admin or Manager role.
        /// Note: Updating old adjustments can be complex and potentially lead to inconsistencies.
        /// It's often recommended to create new adjustments for corrections instead of updating old ones.
        /// </summary>
        /// <param name="id">The ID of the stock adjustment to update.</param>
        /// <param name="updateDto">The updated StockAdjustment data.</param>
        /// <returns>The updated StockAdjustmentResponseDto if successful, otherwise BadRequest, NotFound, or Forbid.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")] // Only Admin or Manager roles can update adjustments
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockAdjustmentResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status409Conflict)] // For insufficient stock or business rules
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStockAdjustment(Guid id, [FromBody] UpdateStockAdjustmentDto updateDto)
        {
            if (id != updateDto.AdjustmentId)
            {
                return BadRequest("Stock adjustment ID in route must match ID in request body.");
            }

            try
            {
                var userOrgId = GetUserOrganizationId();
                var updatedStockAdjustment = await _stockAdjustmentService.UpdateStockAdjustmentAsync(updateDto, userOrgId);
                if (updatedStockAdjustment == null)
                {
                    return NotFound();
                }
                return Ok(updatedStockAdjustment);
            }
            catch (InvalidOperationException ex) // Business rule violations from service
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex) // Invalid input data
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error updating stock adjustment: {ex.Message}" });
            }
        }

        /// <summary>
        /// Deletes a stock adjustment and reverts its effect on the component's current stock quantity. Requires Admin or Manager role.
        /// </summary>
        /// <param name="id">The ID of the stock adjustment to delete.</param>
        /// <returns>NoContent if successful, otherwise NotFound or BadRequest.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")] // Only Admin or Manager roles can delete adjustments
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStockAdjustment(Guid id)
        {
            try
            {
                var userOrgId = GetUserOrganizationId();
                var deleted = await _stockAdjustmentService.DeleteStockAdjustmentAsync(id, userOrgId);
                if (!deleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (InvalidOperationException ex) // Business rule violation (e.g., cannot revert due to insufficient stock)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error deleting stock adjustment: {ex.Message}" });
            }
        }

        // --- API Endpoint for retrieving current stock balances ---

        /// <summary>
        /// Retrieves the current stock balances for all components in the user's organization.
        /// This data is directly pulled from the Component's CurrentStockQuantity.
        /// </summary>
        /// <returns>A list of CurrentStockBalanceDto objects.</returns>
        [HttpGet("CurrentBalances")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CurrentStockBalanceDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CurrentStockBalanceDto>>> GetCurrentStockBalances()
        {
            try
            {
                var userOrgId = GetUserOrganizationId();
                // Assuming you have a method in IComponentService or a dedicated StockReportService
                // to get current stock balances efficiently.
                // For now, let's assume it's part of IStockAdjustmentService for simplicity,
                // or you can inject IComponentService directly here.
                var stockBalances = await _stockAdjustmentService.GetCurrentStockBalancesAsync(userOrgId); // Assuming new method in service
                return Ok(stockBalances);
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error retrieving current stock balances: {ex.Message}" });
            }
        }
    }
}