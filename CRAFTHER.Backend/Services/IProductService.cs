// Path: CRAFTHER.Backend/Services/IProductService.cs
using CRAFTHER.Backend.DTOs.Products;
using CRAFTHER.Backend.DTOs; // สำหรับ CurrentStockBalanceDto
using CRAFTHER.Backend.DTOs.BOMItems; // เพิ่มเข้ามาสำหรับ WhatIfBomItemDto

namespace CRAFTHER.Backend.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync(Guid organizationId);
        Task<ProductResponseDto?> GetProductByIdAsync(Guid productId, Guid organizationId);
        Task<ProductResponseDto> CreateProductAsync(CreateProductDto createProductDto);
        Task<ProductResponseDto?> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<bool> DeleteProductAsync(Guid productId, Guid organizationId);
        Task<CurrentStockBalanceDto?> GetProductStockBalanceAsync(Guid productId, Guid organizationId);
    }
}