using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.DTOs.Products;
using CRAFTHER.Backend.DTOs; // For CurrentStockBalanceDto
using CRAFTHER.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CRAFTHER.Backend.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper method to map Product Model to ProductResponseDto
        private async Task<ProductResponseDto?> MapProductToResponseDto(Product? product)
        {
            if (product == null) return null;

            // Ensure related entities are loaded if not already included in the query.
            // This is crucial if using AsNoTracking() or if the entities weren't eager-loaded.
            // If you always use .Include() in your queries, these LoadAsync calls might not be strictly necessary,
            // but they provide a safety net.
            if (product.ProductUnit == null)
            {
                await _context.Entry(product).Reference(p => p.ProductUnit).LoadAsync();
            }
            if (product.SaleUnit == null && product.SaleUnitId.HasValue)
            {
                await _context.Entry(product).Reference(p => p.SaleUnit).LoadAsync();
            }
            if (product.Organization == null)
            {
                await _context.Entry(product).Reference(p => p.Organization).LoadAsync();
            }

            return new ProductResponseDto
            {
                ProductId = product.ProductId,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                CurrentStockQuantity = product.CurrentStockQuantity,
                SellingPrice = product.SellingPrice,
                CalculatedCost = product.CalculatedCost,
                IsSubProduct = product.IsSubProduct,
                ProductUnitId = product.ProductUnitId,
                ProductUnitName = product.ProductUnit?.UnitName ?? "N/A", // Handle potential null if not loaded
                ProductUnitAbbreviation = product.ProductUnit?.Abbreviation ?? "N/A",
                SaleUnitId = product.SaleUnitId,
                SaleUnitName = product.SaleUnit?.UnitName,
                SaleUnitAbbreviation = product.SaleUnit?.Abbreviation,
                OrganizationId = product.OrganizationId,
                OrganizationName = product.Organization?.OrganizationName ?? "N/A",
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync(Guid organizationId)
        {
            var products = await _context.Products
                .Where(p => p.OrganizationId == organizationId)
                .Include(p => p.ProductUnit) // Eager load ProductUnit for DTO mapping
                .Include(p => p.SaleUnit)    // Eager load SaleUnit for DTO mapping
                .Include(p => p.Organization) // Eager load Organization for DTO mapping
                .AsNoTracking() // Good practice for read-only queries to improve performance
                .ToListAsync();

            var productDtos = new List<ProductResponseDto>();
            foreach (var product in products)
            {
                // No need for await here if MapProductToResponseDto only depends on loaded data
                // But if it contains other async calls like .LoadAsync() as above, keep await.
                productDtos.Add((await MapProductToResponseDto(product))!);
            }
            return productDtos;
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(Guid productId, Guid organizationId)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == productId && p.OrganizationId == organizationId)
                .Include(p => p.ProductUnit)
                .Include(p => p.SaleUnit)
                .Include(p => p.Organization)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await MapProductToResponseDto(product);
        }

        public async Task<ProductResponseDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            // Optional: Check for unique ProductCode within the organization before creating
            var existingProduct = await _context.Products
                .AnyAsync(p => p.OrganizationId == createProductDto.OrganizationId &&
                               p.ProductCode == createProductDto.ProductCode);
            if (existingProduct)
            {
                throw new InvalidOperationException($"Product with code '{createProductDto.ProductCode}' already exists for this organization.");
            }

            var product = new Product
            {
                ProductId = Guid.NewGuid(), // Generate new ID
                ProductCode = createProductDto.ProductCode,
                ProductName = createProductDto.ProductName,
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                ProductUnitId = createProductDto.ProductUnitId,
                SellingPrice = createProductDto.SellingPrice,
                IsSubProduct = createProductDto.IsSubProduct,
                OrganizationId = createProductDto.OrganizationId,
                SaleUnitId = createProductDto.SaleUnitId,
                CurrentStockQuantity = 0, // Initial stock is 0 for a new product
                CalculatedCost = 0, // Initial calculated cost (might be updated later by business logic)
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // After saving, load related entities to map to DTO
            // This is important because the DTO needs data from ProductUnit, SaleUnit, Organization
            // which are not automatically loaded unless included in a query or explicitly loaded.
            await _context.Entry(product).Reference(p => p.ProductUnit).LoadAsync();
            if (product.SaleUnitId.HasValue)
            {
                await _context.Entry(product).Reference(p => p.SaleUnit).LoadAsync();
            }
            await _context.Entry(product).Reference(p => p.Organization).LoadAsync();

            return (await MapProductToResponseDto(product))!;
        }

        public async Task<ProductResponseDto?> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == updateProductDto.ProductId && p.OrganizationId == updateProductDto.OrganizationId)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return null; // Product not found or does not belong to the specified organization
            }

            // Apply updates only if value is provided in the DTO
            if (updateProductDto.ProductName != null) product.ProductName = updateProductDto.ProductName;
            if (updateProductDto.Description != null) product.Description = updateProductDto.Description;
            if (updateProductDto.ImageUrl != null) product.ImageUrl = updateProductDto.ImageUrl;
            if (updateProductDto.ProductUnitId.HasValue) product.ProductUnitId = updateProductDto.ProductUnitId.Value;
            if (updateProductDto.SellingPrice.HasValue) product.SellingPrice = updateProductDto.SellingPrice.Value;
            if (updateProductDto.IsSubProduct.HasValue) product.IsSubProduct = updateProductDto.IsSubProduct.Value;

            // Handling SaleUnitId update explicitly for nullable:
            // If SaleUnitId is explicitly passed as null, set it to null.
            // If SaleUnitId has a value, set it.
            // If SaleUnitId is not passed (its default value for nullable Guid is Guid.Empty), do nothing.
            // Note: This logic assumes that if SaleUnitId is provided as default(Guid) or not provided,
            // we don't update it. If it's explicitly null, then set to null.
            if (updateProductDto.SaleUnitId != null) // If a value or null is explicitly provided
            {
                product.SaleUnitId = updateProductDto.SaleUnitId;
            }


            product.UpdatedAt = DateTime.UtcNow; // Update timestamp

            await _context.SaveChangesAsync();

            // After saving, load related entities to map to DTO
            await _context.Entry(product).Reference(p => p.ProductUnit).LoadAsync();
            if (product.SaleUnitId.HasValue) // Check if SaleUnitId has a value before trying to load
            {
                await _context.Entry(product).Reference(p => p.SaleUnit).LoadAsync();
            }
            await _context.Entry(product).Reference(p => p.Organization).LoadAsync();

            return (await MapProductToResponseDto(product))!;
        }

        public async Task<bool> DeleteProductAsync(Guid productId, Guid organizationId)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == productId && p.OrganizationId == organizationId)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return false; // Product not found or does not belong to the specified organization
            }

            // Optional: Add business logic to prevent deletion if product is in use
            // For example, if it's part of a BOMItem (as ParentProduct or SubProduct)
            var isUsedInBOMs = await _context.BOMItems.AnyAsync(bi => bi.ParentProductId == productId || bi.ProductId == productId);
            if (isUsedInBOMs)
            {
                // You might throw an exception here, or return a specific error code
                // For simplicity, returning false. Controller can decide how to handle this.
                // throw new InvalidOperationException("Product cannot be deleted as it is used in a Bill of Material.");
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CurrentStockBalanceDto?> GetProductStockBalanceAsync(Guid productId, Guid organizationId)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == productId && p.OrganizationId == organizationId)
                .Include(p => p.ProductUnit) // Ensure ProductUnit is loaded for the DTO
                .AsNoTracking()
                .Select(p => new CurrentStockBalanceDto
                {
                    EntityId = p.ProductId,
                    EntityCode = p.ProductCode,
                    EntityName = p.ProductName,
                    CurrentStockQuantity = p.CurrentStockQuantity,
                    UnitId = p.ProductUnitId,
                    UnitName = p.ProductUnit != null ? p.ProductUnit.UnitName : "N/A",
                    UnitAbbreviation = p.ProductUnit != null ? p.ProductUnit.Abbreviation : "N/A"
                })
                .FirstOrDefaultAsync();

            return product;
        }
    }
}