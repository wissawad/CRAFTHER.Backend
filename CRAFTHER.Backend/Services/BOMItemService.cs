// Path: CRAFTHER.Backend/Services/BOMItemService.cs
using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.DTOs.BOMItems;
using CRAFTHER.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public class BOMItemService : IBOMItemService
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductCostingService _productCostingService; // Inject IProductCostingService แทน IProductService

        public BOMItemService(ApplicationDbContext context, IProductCostingService productCostingService) // เปลี่ยน parameter ใน Constructor
        {
            _context = context;
            _productCostingService = productCostingService; // Assign it
        }

        // Helper method to map BOMItem Model to BOMItemResponseDto
        private async Task<BOMItemResponseDto?> MapBOMItemToResponseDto(BOMItem? bomItem)
        {
            if (bomItem == null) return null;

            // Explicitly load related entities if not already included in the query
            // ParentProduct
            if (bomItem.ParentProduct == null)
            {
                await _context.Entry(bomItem).Reference(bi => bi.ParentProduct).LoadAsync();
            }
            // UsageUnit
            if (bomItem.UsageUnit == null)
            {
                await _context.Entry(bomItem).Reference(bi => bi.UsageUnit).LoadAsync();
            }

            // Load Component or SubProduct based on ComponentType
            if (bomItem.ComponentType.ToUpper() == "COMPONENT" && bomItem.ComponentId.HasValue)
            {
                if (bomItem.Component == null)
                {
                    await _context.Entry(bomItem).Reference(bi => bi.Component).LoadAsync();
                    // Also load InventoryUnit of the Component if it's not already there
                    if (bomItem.Component?.InventoryUnit == null)
                    {
                        await _context.Entry(bomItem.Component!).Reference(c => c.InventoryUnit).LoadAsync();
                    }
                }
            }
            else if (bomItem.ComponentType.ToUpper() == "PRODUCT" && bomItem.ProductId.HasValue)
            {
                if (bomItem.SubProduct == null)
                {
                    await _context.Entry(bomItem).Reference(bi => bi.SubProduct).LoadAsync();
                    // Also load ProductUnit of the SubProduct if it's not already there
                    if (bomItem.SubProduct?.ProductUnit == null)
                    {
                        await _context.Entry(bomItem.SubProduct!).Reference(p => p.ProductUnit).LoadAsync();
                    }
                }
            }

            return new BOMItemResponseDto
            {
                BOMItemId = bomItem.BOMItemId,
                ParentProductId = bomItem.ParentProductId,
                ParentProductCode = bomItem.ParentProduct?.ProductCode ?? "N/A",
                ParentProductName = bomItem.ParentProduct?.ProductName ?? "N/A",

                ComponentId = bomItem.ComponentId,
                ComponentCode = bomItem.Component?.ComponentCode,
                ComponentName = bomItem.Component?.ComponentName,
                ComponentInventoryUnitAbbreviation = bomItem.Component?.InventoryUnit?.Abbreviation,

                SubProductId = bomItem.ProductId, // Map ProductId from model to SubProductId in DTO
                SubProductCode = bomItem.SubProduct?.ProductCode,
                SubProductName = bomItem.SubProduct?.ProductName,
                SubProductUnitAbbreviation = bomItem.SubProduct?.ProductUnit?.Abbreviation,

                ComponentType = bomItem.ComponentType,
                Quantity = bomItem.Quantity,
                WastePercentage = bomItem.WastePercentage, // เพิ่ม WastePercentage เข้ามาใน DTO Response

                UsageUnitId = bomItem.UsageUnitId,
                UsageUnitName = bomItem.UsageUnit?.UnitName ?? "N/A",
                UsageUnitAbbreviation = bomItem.UsageUnit?.Abbreviation ?? "N/A",

                Remarks = bomItem.Remarks,
                SortOrder = bomItem.SortOrder,
                CreatedAt = bomItem.CreatedAt,
                UpdatedAt = bomItem.UpdatedAt
            };
        }


        public async Task<IEnumerable<BOMItemResponseDto>> GetAllBOMItemsByParentProductIdAsync(Guid parentProductId, Guid organizationId)
        {
            // First, verify the ParentProduct belongs to the organization
            var parentProductExists = await _context.Products
                .AnyAsync(p => p.ProductId == parentProductId && p.OrganizationId == organizationId);
            if (!parentProductExists)
            {
                // This means the parent product either doesn't exist or doesn't belong to the organization
                return Enumerable.Empty<BOMItemResponseDto>(); // Return empty list instead of throwing for GetAll
            }

            var bomItems = await _context.BOMItems
                .Where(bi => bi.ParentProductId == parentProductId)
                // Include necessary related data for DTO mapping
                .Include(bi => bi.ParentProduct)
                .Include(bi => bi.UsageUnit)
                .Include(bi => bi.Component).ThenInclude(c => c!.InventoryUnit) // Include Component and its InventoryUnit
                .Include(bi => bi.SubProduct).ThenInclude(p => p!.ProductUnit) // Include SubProduct and its ProductUnit
                .AsNoTracking()
                .OrderBy(bi => bi.SortOrder)
                .ToListAsync();

            var bomItemDtos = new List<BOMItemResponseDto>();
            foreach (var item in bomItems)
            {
                bomItemDtos.Add((await MapBOMItemToResponseDto(item))!);
            }
            return bomItemDtos;
        }

        public async Task<BOMItemResponseDto?> GetBOMItemByIdAsync(Guid bomItemId, Guid parentProductId, Guid organizationId)
        {
            // First, verify the ParentProduct belongs to the organization
            var parentProductExists = await _context.Products
                .AnyAsync(p => p.ProductId == parentProductId && p.OrganizationId == organizationId);
            if (!parentProductExists)
            {
                return null; // Parent product not found or doesn't belong to organization
            }

            var bomItem = await _context.BOMItems
                .Where(bi => bi.BOMItemId == bomItemId && bi.ParentProductId == parentProductId)
                .Include(bi => bi.ParentProduct)
                .Include(bi => bi.UsageUnit)
                .Include(bi => bi.Component).ThenInclude(c => c!.InventoryUnit)
                .Include(bi => bi.SubProduct).ThenInclude(p => p!.ProductUnit)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await MapBOMItemToResponseDto(bomItem);
        }

        public async Task<BOMItemResponseDto> CreateBOMItemAsync(CreateBOMItemDto createBOMItemDto)
        {
            // 1. Verify ParentProduct exists and belongs to the organization
            // TODO: Ensure organizationId is from authenticated user (original code already had this note)
            var parentProduct = await _context.Products
                .Where(p => p.ProductId == createBOMItemDto.ParentProductId && p.OrganizationId == createBOMItemDto.ParentProductId)
                .FirstOrDefaultAsync();
            if (parentProduct == null)
            {
                throw new InvalidOperationException($"Parent product with ID '{createBOMItemDto.ParentProductId}' not found or does not belong to the organization.");
            }

            // 2. Validate ComponentType and corresponding ID
            if (createBOMItemDto.ComponentType.ToUpper() == "COMPONENT")
            {
                if (!createBOMItemDto.ComponentId.HasValue || createBOMItemDto.SubProductId.HasValue)
                {
                    throw new ArgumentException("For 'COMPONENT' type, ComponentId must be provided and SubProductId must be null.");
                }
                // Verify Component exists and belongs to the same organization
                var componentExists = await _context.Components
                    .AnyAsync(c => c.ComponentId == createBOMItemDto.ComponentId.Value && c.OrganizationId == parentProduct.OrganizationId);
                if (!componentExists)
                {
                    throw new InvalidOperationException($"Component with ID '{createBOMItemDto.ComponentId}' not found or does not belong to the organization.");
                }
            }
            else if (createBOMItemDto.ComponentType.ToUpper() == "PRODUCT")
            {
                if (!createBOMItemDto.SubProductId.HasValue || createBOMItemDto.ComponentId.HasValue)
                {
                    throw new ArgumentException("For 'PRODUCT' type, SubProductId must be provided and ComponentId must be null.");
                }
                // Verify SubProduct exists, belongs to the same organization, and is marked as IsSubProduct (optional but good practice)
                var subProduct = await _context.Products
                    .Where(p => p.ProductId == createBOMItemDto.SubProductId.Value && p.OrganizationId == parentProduct.OrganizationId)
                    .FirstOrDefaultAsync();
                if (subProduct == null)
                {
                    throw new InvalidOperationException($"Sub-product with ID '{createBOMItemDto.SubProductId}' not found or does not belong to the organization.");
                }
                // Prevent circular dependency
                if (createBOMItemDto.SubProductId.Value == createBOMItemDto.ParentProductId)
                {
                    throw new InvalidOperationException("A product cannot be a sub-product of itself in a BOM.");
                }
            }
            else
            {
                throw new ArgumentException("ComponentType must be 'COMPONENT' or 'PRODUCT'.");
            }

            var bomItem = new BOMItem
            {
                BOMItemId = Guid.NewGuid(),
                ParentProductId = createBOMItemDto.ParentProductId,
                ComponentId = createBOMItemDto.ComponentId,
                ProductId = createBOMItemDto.SubProductId,
                ComponentType = createBOMItemDto.ComponentType.ToUpper(),
                Quantity = createBOMItemDto.Quantity,
                WastePercentage = createBOMItemDto.WastePercentage,
                UsageUnitId = createBOMItemDto.UsageUnitId,
                Remarks = createBOMItemDto.Remarks,
                SortOrder = createBOMItemDto.SortOrder,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.BOMItems.Add(bomItem);
            await _context.SaveChangesAsync();

            // Trigger recalculation of Parent Product's cost after BOM Item is created
            await _productCostingService.RecalculateProductCostAsync(bomItem.ParentProductId, parentProduct.OrganizationId); // เรียกใช้ ProductCostingService แทน ProductService

            return (await MapBOMItemToResponseDto(bomItem))!;
        }

        public async Task<BOMItemResponseDto?> UpdateBOMItemAsync(UpdateBOMItemDto updateBOMItemDto)
        {
            var bomItem = await _context.BOMItems
                .Where(bi => bi.BOMItemId == updateBOMItemDto.BOMItemId && bi.ParentProductId == updateBOMItemDto.ParentProductId)
                .FirstOrDefaultAsync();

            if (bomItem == null)
            {
                return null; // BOM Item not found or does not belong to the specified parent product
            }

            // Verify the ParentProduct belongs to the organization
            // TODO: Ensure organizationId is from authenticated user (original code already had this note)
            var parentProduct = await _context.Products
                .Where(p => p.ProductId == updateBOMItemDto.ParentProductId && p.OrganizationId == updateBOMItemDto.ParentProductId)
                .FirstOrDefaultAsync();
            if (parentProduct == null)
            {
                throw new InvalidOperationException($"Parent product with ID '{updateBOMItemDto.ParentProductId}' not found or does not belong to the organization.");
            }

            // --- Handle ComponentType and ID changes ---
            string effectiveComponentType = updateBOMItemDto.ComponentType?.ToUpper() ?? bomItem.ComponentType.ToUpper();

            if (updateBOMItemDto.ComponentType != null)
            {
                // If ComponentType is changing, enforce strict ID rules
                if (effectiveComponentType == "COMPONENT")
                {
                    if (!updateBOMItemDto.ComponentId.HasValue || updateBOMItemDto.SubProductId.HasValue)
                    {
                        throw new ArgumentException("When updating ComponentType to 'COMPONENT', ComponentId must be provided and SubProductId must be null.");
                    }
                    bomItem.ComponentId = updateBOMItemDto.ComponentId.Value;
                    bomItem.ProductId = null; // Ensure the other FK is null
                }
                else if (effectiveComponentType == "PRODUCT")
                {
                    if (!updateBOMItemDto.SubProductId.HasValue || updateBOMItemDto.ComponentId.HasValue)
                    {
                        throw new ArgumentException("When updating ComponentType to 'PRODUCT', SubProductId must be provided and ComponentId must be null.");
                    }
                    bomItem.ProductId = updateBOMItemDto.SubProductId.Value;
                    bomItem.ComponentId = null; // Ensure the other FK is null
                }
                else
                {
                    throw new ArgumentException("ComponentType must be 'COMPONENT' or 'PRODUCT'.");
                }
                bomItem.ComponentType = effectiveComponentType; // Update the type in the model
            }
            else // ComponentType is not being updated, but ComponentId/SubProductId might be
            {
                // If ComponentId is provided in DTO, update it. Ensure SubProductId is null.
                if (updateBOMItemDto.ComponentId.HasValue)
                {
                    if (updateBOMItemDto.SubProductId.HasValue)
                    {
                        throw new ArgumentException("Only one of ComponentId or SubProductId can be provided.");
                    }
                    if (effectiveComponentType != "COMPONENT")
                    {
                        throw new ArgumentException("Cannot update ComponentId when ComponentType is 'PRODUCT'.");
                    }
                    bomItem.ComponentId = updateBOMItemDto.ComponentId.Value;
                    bomItem.ProductId = null; // Ensure the other is null
                }
                // If SubProductId is provided in DTO, update it. Ensure ComponentId is null.
                else if (updateBOMItemDto.SubProductId.HasValue)
                {
                    if (effectiveComponentType != "PRODUCT")
                    {
                        throw new ArgumentException("Cannot update SubProductId when ComponentType is 'COMPONENT'.");
                    }
                    bomItem.ProductId = updateBOMItemDto.SubProductId.Value;
                    bomItem.ComponentId = null; // Ensure the other is null
                }
            }
            // --- End of ComponentType and ID changes ---

            // Apply other updates if value is provided
            if (updateBOMItemDto.Quantity.HasValue) bomItem.Quantity = updateBOMItemDto.Quantity.Value;
            if (updateBOMItemDto.WastePercentage.HasValue) bomItem.WastePercentage = updateBOMItemDto.WastePercentage.Value; // Map WastePercentage
            if (updateBOMItemDto.UsageUnitId.HasValue) bomItem.UsageUnitId = updateBOMItemDto.UsageUnitId.Value;
            if (updateBOMItemDto.Remarks != null) bomItem.Remarks = updateBOMItemDto.Remarks;
            if (updateBOMItemDto.SortOrder.HasValue) bomItem.SortOrder = updateBOMItemDto.SortOrder.Value;

            bomItem.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Trigger recalculation of Parent Product's cost after BOM Item is updated
            await _productCostingService.RecalculateProductCostAsync(bomItem.ParentProductId, parentProduct.OrganizationId); // เรียกใช้ ProductCostingService แทน ProductService

            return (await MapBOMItemToResponseDto(bomItem))!;
        }

        public async Task<bool> DeleteBOMItemAsync(Guid bomItemId, Guid parentProductId, Guid organizationId)
        {
            // First, verify the ParentProduct belongs to the organization
            var parentProductExists = await _context.Products
                .AnyAsync(p => p.ProductId == parentProductId && p.OrganizationId == organizationId);
            if (!parentProductExists)
            {
                return false; // Parent product not found or doesn't belong to organization
            }

            var bomItem = await _context.BOMItems
                .Where(bi => bi.BOMItemId == bomItemId && bi.ParentProductId == parentProductId)
                .FirstOrDefaultAsync();

            if (bomItem == null)
            {
                return false; // BOM Item not found or does not belong to the specified parent product
            }

            _context.BOMItems.Remove(bomItem);
            await _context.SaveChangesAsync();

            // Trigger recalculation of Parent Product's cost after BOM Item is deleted
            await _productCostingService.RecalculateProductCostAsync(bomItem.ParentProductId, organizationId); // เรียกใช้ ProductCostingService แทน ProductService

            return true;
        }
    }
}