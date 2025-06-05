// Path: CRAFTHER.Backend/Services/IProductionOrderService.cs
using CRAFTHER.Backend.DTOs.ProductionOrders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public interface IProductionOrderService
    {
        // Get Production Orders for a specific organization
        Task<IEnumerable<ProductionOrderResponseDto>> GetAllProductionOrdersAsync(Guid organizationId);

        // Get a specific Production Order by ID
        Task<ProductionOrderResponseDto?> GetProductionOrderByIdAsync(Guid productionOrderId, Guid organizationId);

        // Create a new Production Order
        Task<ProductionOrderResponseDto> CreateProductionOrderAsync(CreateProductionOrderDto createDto, Guid organizationId);

        // Update an existing Production Order
        Task<ProductionOrderResponseDto?> UpdateProductionOrderAsync(UpdateProductionOrderDto updateDto, Guid organizationId);

        // Delete a Production Order
        Task<bool> DeleteProductionOrderAsync(Guid productionOrderId, Guid organizationId);

        // Mark a Production Order as Completed and trigger stock movements
        Task<ProductionOrderResponseDto?> CompleteProductionOrderAsync(Guid productionOrderId, Guid organizationId);

        // Calculate required components/sub-products for a given product and quantity (similar to what-if for BOM)
        Task<IEnumerable<ProductionOrderItemResponseDto>> GetRequiredMaterialsForProductionAsync(Guid productId, decimal quantityToProduce, Guid organizationId);
    }
}