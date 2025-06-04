using CRAFTHER.Backend.DTOs.BOMItems;
using CRAFTHER.Backend.Services;
using CRAFTHER.Backend.Models; // For InvalidOperationException if needed
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims; // For GetOrganizationId()
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Controllers
{
    [Authorize] // Requires authentication for all endpoints in this controller
    [Route("api/products/{parentProductId}/bomitems")]
    [ApiController]
    public class BOMItemsController : ControllerBase
    {
        private readonly IBOMItemService _bomItemService;
        private readonly IProductService _productService; // To verify parent product exists and organization

        public BOMItemsController(IBOMItemService bomItemService, IProductService productService)
        {
            _bomItemService = bomItemService;
            _productService = productService;
        }

        // Helper to get OrganizationId from JWT token
        private Guid GetOrganizationId()
        {
            var organizationIdClaim = User.FindFirst("organizationId")?.Value;
            if (string.IsNullOrEmpty(organizationIdClaim) || !Guid.TryParse(organizationIdClaim, out var organizationId))
            {
                throw new InvalidOperationException("Organization ID claim not found or invalid.");
            }
            return organizationId;
        }

        // GET: api/products/{parentProductId}/bomitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BOMItemResponseDto>>> GetAllBOMItemsByParentProductId(Guid parentProductId)
        {
            var organizationId = GetOrganizationId();

            // Optional: Verify Parent Product exists and belongs to the organization (redundant with service logic but good for early exit)
            var parentProduct = await _productService.GetProductByIdAsync(parentProductId, organizationId);
            if (parentProduct == null)
            {
                return NotFound($"Parent Product with ID '{parentProductId}' not found or does not belong to your organization.");
            }

            var bomItems = await _bomItemService.GetAllBOMItemsByParentProductIdAsync(parentProductId, organizationId);
            return Ok(bomItems);
        }

        // GET: api/products/{parentProductId}/bomitems/{bomItemId}
        [HttpGet("{bomItemId}")]
        public async Task<ActionResult<BOMItemResponseDto>> GetBOMItemById(Guid parentProductId, Guid bomItemId)
        {
            var organizationId = GetOrganizationId();

            // Optional: Verify Parent Product exists and belongs to the organization
            var parentProduct = await _productService.GetProductByIdAsync(parentProductId, organizationId);
            if (parentProduct == null)
            {
                return NotFound($"Parent Product with ID '{parentProductId}' not found or does not belong to your organization.");
            }

            var bomItem = await _bomItemService.GetBOMItemByIdAsync(bomItemId, parentProductId, organizationId);

            if (bomItem == null)
            {
                return NotFound();
            }
            return Ok(bomItem);
        }

        // POST: api/products/{parentProductId}/bomitems
        [HttpPost]
        public async Task<ActionResult<BOMItemResponseDto>> CreateBOMItem(Guid parentProductId, [FromBody] CreateBOMItemDto createBOMItemDto)
        {
            var organizationId = GetOrganizationId();

            // Ensure the ParentProductId in the DTO matches the route parameter
            if (parentProductId != createBOMItemDto.ParentProductId)
            {
                return BadRequest("ParentProductId in route must match ParentProductId in request body.");
            }

            // Optional: Verify Parent Product exists and belongs to the organization before passing to service
            var parentProduct = await _productService.GetProductByIdAsync(parentProductId, organizationId);
            if (parentProduct == null)
            {
                return NotFound($"Parent Product with ID '{parentProductId}' not found or does not belong to your organization.");
            }

            // Temporarily set OrganizationId in DTO for service-side validation
            // In a real app, ensure this comes from the authenticated user's claims
            // This is crucial for security.
            // For now, we'll ensure the organizationId is set correctly via the parent product's organization.
            // We use the organizationId from the authenticated user.
            // No direct organizationId in CreateBOMItemDto for now, as it's implicitly tied to ParentProduct.

            try
            {
                var createdBOMItem = await _bomItemService.CreateBOMItemAsync(createBOMItemDto);
                return CreatedAtAction(nameof(GetBOMItemById), new { parentProductId = createdBOMItem.ParentProductId, bomItemId = createdBOMItem.BOMItemId }, createdBOMItem);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/products/{parentProductId}/bomitems/{bomItemId}
        [HttpPut("{bomItemId}")]
        public async Task<ActionResult<BOMItemResponseDto>> UpdateBOMItem(Guid parentProductId, Guid bomItemId, [FromBody] UpdateBOMItemDto updateBOMItemDto)
        {
            var organizationId = GetOrganizationId();

            // Ensure IDs in DTO match route parameters
            if (bomItemId != updateBOMItemDto.BOMItemId)
            {
                return BadRequest("BOMItemId in route must match BOMItemId in request body.");
            }
            if (parentProductId != updateBOMItemDto.ParentProductId)
            {
                return BadRequest("ParentProductId in route must match ParentProductId in request body.");
            }

            // Optional: Verify Parent Product exists and belongs to the organization
            var parentProduct = await _productService.GetProductByIdAsync(parentProductId, organizationId);
            if (parentProduct == null)
            {
                return NotFound($"Parent Product with ID '{parentProductId}' not found or does not belong to your organization.");
            }

            try
            {
                var updatedBOMItem = await _bomItemService.UpdateBOMItemAsync(updateBOMItemDto);
                if (updatedBOMItem == null)
                {
                    return NotFound();
                }
                return Ok(updatedBOMItem);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/products/{parentProductId}/bomitems/{bomItemId}
        [HttpDelete("{bomItemId}")]
        public async Task<IActionResult> DeleteBOMItem(Guid parentProductId, Guid bomItemId)
        {
            var organizationId = GetOrganizationId();

            // Optional: Verify Parent Product exists and belongs to the organization
            var parentProduct = await _productService.GetProductByIdAsync(parentProductId, organizationId);
            if (parentProduct == null)
            {
                return NotFound($"Parent Product with ID '{parentProductId}' not found or does not belong to your organization.");
            }

            var deleted = await _bomItemService.DeleteBOMItemAsync(bomItemId, parentProductId, organizationId);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}