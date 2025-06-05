using CRAFTHER.Backend.DTOs.Components;
using CRAFTHER.Backend.DTOs; // For CurrentStockBalanceDto
using CRAFTHER.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CRAFTHER.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // e.g., /api/Component
    // [Authorize] // Uncomment if authentication is required for all actions
    public class ComponentController : ControllerBase
    {
        private readonly IComponentService _componentService;

        public ComponentController(IComponentService componentService)
        {
            _componentService = componentService;
        }

        // Helper method to get OrganizationId from claims (same as in ProductController)
        private Guid GetOrganizationId()
        {
            // ดึง OrganizationId จาก Claims ของผู้ใช้งานที่ Login อยู่
            var organizationIdClaim = User.FindFirst("OrganizationId")?.Value;
            if (string.IsNullOrEmpty(organizationIdClaim) || !Guid.TryParse(organizationIdClaim, out var orgId))
            {
                // ถ้าหา Claim ไม่เจอ หรือแปลงไม่ได้ แสดงว่า Token มีปัญหา หรือ User ไม่ได้ผูกกับ Organization
                throw new InvalidOperationException("Organization ID claim not found or invalid for the authenticated user.");
            }
            return orgId;
        }

        /// <summary>
        /// Gets all components for the authenticated organization.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ComponentResponseDto>))]
        public async Task<ActionResult<IEnumerable<ComponentResponseDto>>> GetAllComponents()
        {
            var organizationId = GetOrganizationId();
            var components = await _componentService.GetAllComponentsAsync(organizationId);
            return Ok(components);
        }

        /// <summary>
        /// Gets a component by its ID for the authenticated organization.
        /// </summary>
        /// <param name="id">The ID of the component.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComponentResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ComponentResponseDto>> GetComponentById(Guid id)
        {
            var organizationId = GetOrganizationId();
            var component = await _componentService.GetComponentByIdAsync(id, organizationId);

            if (component == null)
            {
                return NotFound();
            }
            return Ok(component);
        }

        /// <summary>
        /// Creates a new component.
        /// </summary>
        /// <param name="createComponentDto">The component data.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ComponentResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<ComponentResponseDto>> CreateComponent([FromBody] CreateComponentDto createComponentDto)
        {
            // Security: Override organizationId from DTO with authenticated user's organizationId
            // createComponentDto.OrganizationId = GetOrganizationId();

            try
            {
                var createdComponent = await _componentService.CreateComponentAsync(createComponentDto);
                return CreatedAtAction(nameof(GetComponentById), new { id = createdComponent.ComponentId }, createdComponent);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error creating component: " + ex.Message });
            }
        }

        /// <summary>
        /// Updates an existing component.
        /// </summary>
        /// <param name="id">The ID of the component to update.</param>
        /// <param name="updateComponentDto">The updated component data.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComponentResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ComponentResponseDto>> UpdateComponent(Guid id, [FromBody] UpdateComponentDto updateComponentDto)
        {
            if (id != updateComponentDto.ComponentId)
            {
                return BadRequest("Component ID in URL does not match ID in body.");
            }

            // Security: Ensure updateComponentDto.OrganizationId matches the authenticated user's organization.
            updateComponentDto.OrganizationId = GetOrganizationId(); // Crucial for security and scoping

            var updatedComponent = await _componentService.UpdateComponentAsync(updateComponentDto);

            if (updatedComponent == null)
            {
                return NotFound();
            }
            return Ok(updatedComponent);
        }

        /// <summary>
        /// Deletes a component by its ID.
        /// </summary>
        /// <param name="id">The ID of the component to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)] // If deletion is prevented by business logic
        public async Task<ActionResult> DeleteComponent(Guid id)
        {
            var organizationId = GetOrganizationId();
            try
            {
                var result = await _componentService.DeleteComponentAsync(id, organizationId);
                if (!result)
                {
                    // This scenario might mean not found, or could not be deleted for other reasons (e.g., dependencies not throwing exception)
                    // You can refine this by checking existence first.
                    var componentExists = await _componentService.GetComponentByIdAsync(id, organizationId);
                    if (componentExists == null)
                    {
                        return NotFound(); // Component not found for this organization
                    }
                    else
                    {
                        // This case would be hit if DeleteComponentAsync returns false but doesn't throw.
                        // Given our service throws InvalidOperationException, this path might not be reached directly by business rule.
                        return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete component due to an unknown reason.");
                    }
                }
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message }); // e.g., "Component cannot be deleted as it is used in a Bill of Material."
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error deleting component: " + ex.Message });
            }
        }

        /// <summary>
        /// Gets the current stock balance for a specific component.
        /// </summary>
        /// <param name="id">The ID of the component.</param>
        [HttpGet("{id}/stock-balance")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CurrentStockBalanceDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CurrentStockBalanceDto>> GetComponentStockBalance(Guid id)
        {
            var organizationId = GetOrganizationId();
            var stockBalance = await _componentService.GetComponentStockBalanceAsync(id, organizationId);

            if (stockBalance == null)
            {
                return NotFound();
            }
            return Ok(stockBalance);
        }
    }
}