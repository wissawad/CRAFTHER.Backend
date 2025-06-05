// Path: CRAFTHER.Backend/Services/ProductService.cs
using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.DTOs.Products;
using CRAFTHER.Backend.DTOs; // For CurrentStockBalanceDto
using CRAFTHER.Backend.Models;
using Microsoft.EntityFrameworkCore;
// using CRAFTHER.Backend.Services; // ลบ using นี้ออก เพราะไม่จำเป็นต้อง Inject IUnitConversionService, IComponentService, IBOMItemService ที่นี่แล้ว
using CRAFTHER.Backend.DTOs.BOMItems; // เพิ่มเข้ามาสำหรับ WhatIfBomItemDto (ถ้ายังใช้ใน DTO mapping หรืออื่นๆ)

namespace CRAFTHER.Backend.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        // private readonly IUnitConversionService _unitConversionService; // ลบออก
        // private readonly IComponentService _componentService; // ลบออก
        // private readonly IBOMItemService _bomItemService; // ลบออก
        private readonly IProductCostingService _productCostingService; // Inject IProductCostingService

        public ProductService(ApplicationDbContext context,
                              // IUnitConversionService unitConversionService, // ลบออก
                              // IComponentService componentService, // ลบออก
                              // IBOMItemService bomItemService, // ลบออก
                              IProductCostingService productCostingService) // Inject IProductCostingService
        {
            _context = context;
            // _unitConversionService = unitConversionService; // ลบออก
            // _componentService = componentService; // ลบออก
            // _bomItemService = bomItemService; // ลบออก
            _productCostingService = productCostingService; // Assign it
        }

        // Helper method to map Product Model to ProductResponseDto
        private async Task<ProductResponseDto?> MapProductToResponseDto(Product? product)
        {
            if (product == null) return null;

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
                ProductUnitName = product.ProductUnit?.UnitName ?? "N/A",
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
                .Include(p => p.ProductUnit)
                .Include(p => p.SaleUnit)
                .Include(p => p.Organization)
                .AsNoTracking()
                .ToListAsync();

            var productDtos = new List<ProductResponseDto>();
            foreach (var product in products)
            {
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
            var existingProduct = await _context.Products
                .AnyAsync(p => p.OrganizationId == createProductDto.OrganizationId &&
                               p.ProductCode == createProductDto.ProductCode);
            if (existingProduct)
            {
                throw new InvalidOperationException($"Product with code '{createProductDto.ProductCode}' already exists for this organization.");
            }

            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                ProductCode = createProductDto.ProductCode,
                ProductName = createProductDto.ProductName,
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                ProductUnitId = createProductDto.ProductUnitId,
                SellingPrice = createProductDto.SellingPrice,
                IsSubProduct = createProductDto.IsSubProduct,
                OrganizationId = createProductDto.OrganizationId,
                SaleUnitId = createProductDto.SaleUnitId,
                CurrentStockQuantity = 0,
                CalculatedCost = 0, // Initial calculated cost will be 0, recalculated later if BOM exists
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            await _context.Entry(product).Reference(p => p.ProductUnit).LoadAsync();
            if (product.SaleUnitId.HasValue)
            {
                await _context.Entry(product).Reference(p => p.SaleUnit).LoadAsync();
            }
            await _context.Entry(product).Reference(p => p.Organization).LoadAsync();

            // ไม่ต้องเรียก RecalculateProductCostAsync ที่นี่ใน CreateProduct
            // เพราะ CalculatedCost จะเป็น 0 อยู่แล้วจนกว่าจะมี BOM Items เพิ่มเข้ามา
            // การคำนวณจะถูก Trigger เมื่อ BOM Item ถูกสร้าง/อัปเดต

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

            if (updateProductDto.SaleUnitId != null)
            {
                product.SaleUnitId = updateProductDto.SaleUnitId;
            }

            product.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Trigger cost recalculation for this product after its own update (if it has BOM items)
            // หรือหากมีการเปลี่ยน IsSubProduct เป็น true แล้วมันถูกใช้ใน BOM อื่น ก็อาจต้องคำนวณใหม่
            // _productCostingService จะจัดการการคำนวณจริง
            await _productCostingService.RecalculateProductCostAsync(product.ProductId, product.OrganizationId);

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

            var isUsedInBOMs = await _context.BOMItems.AnyAsync(bi => bi.ParentProductId == productId || bi.ProductId == productId);
            if (isUsedInBOMs)
            {
                throw new InvalidOperationException("Product cannot be deleted as it is used in a Bill of Material (as a parent or sub-product).");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CurrentStockBalanceDto?> GetProductStockBalanceAsync(Guid productId, Guid organizationId)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == productId && p.OrganizationId == organizationId)
                .Include(p => p.ProductUnit)
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

        // --- ลบเมธอด CalculateBOMCostInternal, RecalculateProductCostAsync และ GetWhatIfCalculatedCostAsync ออก ---
        // (ย้ายไปที่ ProductCostingService แล้ว)
        // --- ลบเมธอด RecalculateProductsAffectedByComponentPriceChange ออกจาก ProductService ---
        // (ย้ายไปที่ ProductCostingService แล้ว)
    }
}