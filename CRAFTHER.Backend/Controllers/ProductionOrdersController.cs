// Path: CRAFTHER.Backend/Controllers/ProductionOrdersController.cs
using CRAFTHER.Backend.DTOs.ProductionOrders;
using CRAFTHER.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims; // For HttpContext.User.FindFirst
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // ต้องมีการ Login ถึงจะเข้าถึงได้
    public class ProductionOrdersController : ControllerBase
    {
        private readonly IProductionOrderService _productionOrderService;

        public ProductionOrdersController(IProductionOrderService productionOrderService)
        {
            _productionOrderService = productionOrderService;
        }

        // Helper method เพื่อดึง OrganizationId ของผู้ใช้ที่ Login อยู่
        private Guid GetUserOrganizationId()
        {
            var orgIdClaim = User.FindFirst("OrganizationId")?.Value;
            if (string.IsNullOrEmpty(orgIdClaim) || !Guid.TryParse(orgIdClaim, out Guid orgId))
            {
                throw new InvalidOperationException("Organization ID claim not found or invalid.");
            }
            return orgId;
        }

        /// <summary>
        /// Retrieves all production orders for the authenticated user's organization.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductionOrderResponseDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductionOrderResponseDto>>> GetAllProductionOrders()
        {
            try
            {
                var userOrgId = GetUserOrganizationId();
                var orders = await _productionOrderService.GetAllProductionOrdersAsync(userOrgId);
                return Ok(orders);
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error retrieving production orders: {ex.Message}" });
            }
        }

        /// <summary>
        /// Retrieves a specific production order by its ID for the authenticated user's organization.
        /// </summary>
        /// <param name="id">The ID of the production order.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductionOrderResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductionOrderResponseDto>> GetProductionOrderById(Guid id)
        {
            try
            {
                var userOrgId = GetUserOrganizationId();
                var order = await _productionOrderService.GetProductionOrderByIdAsync(id, userOrgId);

                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error retrieving production order: {ex.Message}" });
            }
        }

        /// <summary>
        /// Creates a new production order. Requires Admin or Manager role.
        /// </summary>
        /// <param name="createDto">The production order data.</param>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductionOrderResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductionOrderResponseDto>> CreateProductionOrder([FromBody] CreateProductionOrderDto createDto)
        {
            try
            {
                var userOrgId = GetUserOrganizationId();
                var createdOrder = await _productionOrderService.CreateProductionOrderAsync(createDto, userOrgId);
                return CreatedAtAction(nameof(GetProductionOrderById), new { id = createdOrder.ProductionOrderId }, createdOrder);
            }
            catch (InvalidOperationException ex) // Business rule violations from service
            {
                return BadRequest(ex.Message); // ใช้ BadRequest สำหรับ InvalidOperationException
            }
            catch (ArgumentException ex) // Invalid input data from DTO validation
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error creating production order: {ex.Message}" });
            }
        }

        /// <summary>
        /// Updates an existing production order. Requires Admin or Manager role.
        /// </summary>
        /// <param name="id">The ID of the production order to update.</param>
        /// <param name="updateDto">The updated production order data.</param>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductionOrderResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProductionOrder(Guid id, [FromBody] UpdateProductionOrderDto updateDto)
        {
            if (id != updateDto.ProductionOrderId)
            {
                return BadRequest("Production Order ID in route must match ID in request body.");
            }

            try
            {
                var userOrgId = GetUserOrganizationId();
                var updatedOrder = await _productionOrderService.UpdateProductionOrderAsync(updateDto, userOrgId);
                if (updatedOrder == null)
                {
                    return NotFound();
                }
                return Ok(updatedOrder);
            }
            catch (InvalidOperationException ex) // Business rule violations
            {
                return BadRequest(ex.Message); // ใช้ BadRequest สำหรับ InvalidOperationException
            }
            catch (ArgumentException ex) // Invalid input data
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error updating production order: {ex.Message}" });
            }
        }

        /// <summary>
        /// Deletes a production order. Requires Admin or Manager role.
        /// </summary>
        /// <param name="id">The ID of the production order to delete.</param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status409Conflict)] // For business rules preventing deletion
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProductionOrder(Guid id)
        {
            try
            {
                var userOrgId = GetUserOrganizationId();
                var deleted = await _productionOrderService.DeleteProductionOrderAsync(id, userOrgId);
                if (!deleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (InvalidOperationException ex) // Business rule violation (e.g., cannot delete based on status)
            {
                return BadRequest(ex.Message); // ใช้ BadRequest สำหรับ InvalidOperationException
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error deleting production order: {ex.Message}" });
            }
        }

        /// <summary>
        /// Marks a production order as completed and triggers stock movements (consumption of materials, production of finished goods). Requires Admin or Manager role.
        /// </summary>
        /// <param name="id">The ID of the production order to complete.</param>
        [HttpPost("{id}/complete")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductionOrderResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)] // For insufficient stock
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductionOrderResponseDto>> CompleteProductionOrder(Guid id)
        {
            try
            {
                var userOrgId = GetUserOrganizationId();
                var completedOrder = await _productionOrderService.CompleteProductionOrderAsync(id, userOrgId);
                if (completedOrder == null)
                {
                    return NotFound();
                }
                return Ok(completedOrder);
            }
            catch (InvalidOperationException ex) // Business rule violations (e.g., already completed, insufficient stock)
            {
                return Conflict(new { message = ex.Message }); // 409 Conflict for business rule violations
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error completing production order: {ex.Message}" });
            }
        }

        /// <summary>
        /// Calculates the required materials (components and sub-products) for a given product and quantity, based on its Bill of Materials (BOM). This does not create a production order.
        /// </summary>
        /// <param name="productId">The ID of the product to calculate materials for.</param>
        /// <param name="quantityToProduce">The quantity of the product to produce (in its primary unit).</param>
        [HttpGet("required-materials")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductionOrderItemResponseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductionOrderItemResponseDto>>> GetRequiredMaterialsForProduction(
            [FromQuery] Guid productId,
            [FromQuery] decimal quantityToProduce)
        {
            if (productId == Guid.Empty || quantityToProduce <= 0)
            {
                return BadRequest("Product ID and Quantity to Produce must be provided and greater than zero.");
            }

            try
            {
                var userOrgId = GetUserOrganizationId();
                var requiredMaterials = await _productionOrderService.GetRequiredMaterialsForProductionAsync(productId, quantityToProduce, userOrgId);
                return Ok(requiredMaterials);
            }
            catch (InvalidOperationException ex)
            {
                // เช่น Product ไม่พบ, BOM ไม่สมบูรณ์, Conversion Factor ไม่พบ
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error calculating required materials: {ex.Message}" });
            }
        }
    }
}