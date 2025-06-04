using CRAFTHER.Backend.DTOs.Products;
using CRAFTHER.Backend.DTOs; // For CurrentStockBalanceDto
using CRAFTHER.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims; // For getting user's organization ID

namespace CRAFTHER.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Sets the base route, e.g., /api/Product
    // [Authorize] // Uncomment this line if you want to require authentication for all actions in this controller
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // Helper method to get OrganizationId from claims (crucial for multi-tenancy/security)
        private Guid GetOrganizationId()
        {
            // In a real application, you'd extract this from the authenticated user's claims.
            // Example:
            // var organizationIdClaim = User.FindFirst("organizationId")?.Value;
            // if (Guid.TryParse(organizationIdClaim, out var orgId))
            // {
            //     return orgId;
            // }
            // For development/testing without full authentication, you can use a hardcoded GUID.
            // !!! IMPORTANT: REPLACE THIS WITH ACTUAL AUTHENTICATION LOGIC IN PRODUCTION !!!
            return Guid.Parse("YOUR_DEFAULT_ORGANIZATION_ID_HERE"); // <-- REPLACE THIS GUID!
        }

        /// <summary>
        /// Gets all products for the authenticated organization.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductResponseDto>))]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAllProducts()
        {
            var organizationId = GetOrganizationId();
            var products = await _productService.GetAllProductsAsync(organizationId);
            return Ok(products);
        }

        /// <summary>
        /// Gets a product by its ID for the authenticated organization.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductResponseDto>> GetProductById(Guid id)
        {
            var organizationId = GetOrganizationId();
            var product = await _productService.GetProductByIdAsync(id, organizationId);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="createProductDto">The product data.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)] // For duplicate code or business rule violation
        public async Task<ActionResult<ProductResponseDto>> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            // Security: In a real application, you'd likely set createProductDto.OrganizationId
            // based on the authenticated user's organizationId, overriding any value sent by the client.
            // createProductDto.OrganizationId = GetOrganizationId(); // Ensure organization ownership

            try
            {
                var createdProduct = await _productService.CreateProductAsync(createProductDto);
                return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.ProductId }, createdProduct);
            }
            catch (InvalidOperationException ex)
            {
                // Catch specific business logic errors from the service layer
                return Conflict(new { message = ex.Message }); // 409 Conflict for business rule violations
            }
            catch (Exception ex)
            {
                // Catch any other unexpected errors
                return BadRequest(new { message = "Error creating product: " + ex.Message });
            }
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="updateProductDto">The updated product data.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductResponseDto>> UpdateProduct(Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (id != updateProductDto.ProductId)
            {
                return BadRequest("Product ID in URL does not match ID in body.");
            }

            // Security: Ensure updateProductDto.OrganizationId matches the authenticated user's organization.
            updateProductDto.OrganizationId = GetOrganizationId(); // Crucial for security and scoping

            var updatedProduct = await _productService.UpdateProductAsync(updateProductDto);

            if (updatedProduct == null)
            {
                return NotFound(); // Product not found or not belonging to the organization
            }
            return Ok(updatedProduct);
        }

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)] // If deletion is prevented by business logic (e.g., in use)
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var organizationId = GetOrganizationId();
            var result = await _productService.DeleteProductAsync(id, organizationId);

            if (!result)
            {
                // This could mean not found, or it's in use. The service returns false for both.
                // You might refine the service to return different error codes or throw specific exceptions.
                // For now, if result is false, check if it exists first:
                var productExists = await _productService.GetProductByIdAsync(id, organizationId);
                if (productExists == null)
                {
                    return NotFound(); // Product not found for this organization
                }
                else
                {
                    return Conflict("Product cannot be deleted as it is in use (e.g., in a BOM).");
                }
            }
            return NoContent(); // 204 No Content for successful deletion
        }

        /// <summary>
        /// Gets the current stock balance for a specific product.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        [HttpGet("{id}/stock-balance")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CurrentStockBalanceDtoxx))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CurrentStockBalanceDtoxx>> GetProductStockBalance(Guid id)
        {
            var organizationId = GetOrganizationId();
            var stockBalance = await _productService.GetProductStockBalanceAsync(id, organizationId);

            if (stockBalance == null)
            {
                return NotFound();
            }
            return Ok(stockBalance);
        }
    }
}