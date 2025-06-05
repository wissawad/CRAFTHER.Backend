// Path: CRAFTHER.Backend/Services/ProductCostingService.cs
using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.Models;
using Microsoft.EntityFrameworkCore;
using CRAFTHER.Backend.DTOs.BOMItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public class ProductCostingService : IProductCostingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitConversionService _unitConversionService;
        //private readonly IComponentService _componentService; // ใช้สำหรับดึงข้อมูล Component (เช่น UnitPrice)
        //private readonly IBOMItemService _bomItemService; // ใช้สำหรับดึง BOM Items

        public ProductCostingService(ApplicationDbContext context,
                                     IUnitConversionService unitConversionService
                                     //IComponentService componentService,
                                     //IBOMItemService bomItemService
                                     )
        {
            _context = context;
            _unitConversionService = unitConversionService;
            //_componentService = componentService;
            //_bomItemService = bomItemService;
        }

        // Helper method สำหรับคำนวณต้นทุน BOM (ย้ายมาจาก ProductService)
        private async Task<decimal> CalculateBOMCostInternal(Guid productId, Guid organizationId, List<WhatIfBomItemDto>? whatIfItems = null)
        {
            var bomItems = await _context.BOMItems
                .Where(bi => bi.ParentProductId == productId)
                .Include(bi => bi.Component)
                .Include(bi => bi.SubProduct)
                    .ThenInclude(sp => sp!.ProductUnit)
                .Include(bi => bi.UsageUnit)
                .AsNoTracking()
                .ToListAsync();

            if (!bomItems.Any())
            {
                return 0.0m;
            }

            decimal totalCalculatedCost = 0.0m;

            foreach (var bomItem in bomItems)
            {
                decimal itemCost = 0.0m;
                decimal itemQuantity = bomItem.Quantity;
                Guid itemUsageUnitId = bomItem.UsageUnitId;
                decimal itemWastePercentage = bomItem.WastePercentage;

                if (whatIfItems != null)
                {
                    var whatIfOverride = whatIfItems.FirstOrDefault(wi => wi.BOMItemId == bomItem.BOMItemId);
                    if (whatIfOverride != null)
                    {
                        if (whatIfOverride.NewQuantity.HasValue) itemQuantity = whatIfOverride.NewQuantity.Value;
                        if (whatIfOverride.NewWastePercentage.HasValue)
                        {
                            itemWastePercentage = whatIfOverride.NewWastePercentage.Value;
                        }
                    }
                }

                if (bomItem.ComponentType.ToUpper() == "COMPONENT")
                {
                    if (bomItem.Component == null)
                    {
                        throw new InvalidOperationException($"Component with ID '{bomItem.ComponentId}' for BOM Item '{bomItem.BOMItemId}' not found.");
                    }

                    decimal currentComponentUnitPrice = bomItem.Component.UnitPrice;
                    Guid componentInventoryUnitId = bomItem.Component.InventoryUnitId;

                    if (whatIfItems != null)
                    {
                        var whatIfOverride = whatIfItems.FirstOrDefault(wi => wi.BOMItemId == bomItem.BOMItemId);
                        if (whatIfOverride != null && whatIfOverride.NewUnitCost.HasValue)
                        {
                            if (whatIfOverride.NewUnitId.HasValue)
                            {
                                decimal? conversionFactor = await _unitConversionService.GetConversionFactorAsync(
                                    whatIfOverride.NewUnitId.Value, componentInventoryUnitId, organizationId);
                                if (!conversionFactor.HasValue || conversionFactor.Value == 0)
                                {
                                    throw new InvalidOperationException($"No valid conversion factor found for What-If cost unit from '{whatIfOverride.NewUnitId.Value}' to component inventory unit '{componentInventoryUnitId}'.");
                                }
                                currentComponentUnitPrice = whatIfOverride.NewUnitCost.Value * conversionFactor.Value;
                            }
                            else
                            {
                                decimal purchaseToInventoryFactor = bomItem.Component.PurchaseToInventoryConversionFactor;
                                if (purchaseToInventoryFactor == 0)
                                {
                                    throw new InvalidOperationException($"Purchase to Inventory Conversion Factor for component '{bomItem.Component.ComponentName}' is zero, which is invalid for What-If without specific unit.");
                                }
                                currentComponentUnitPrice = whatIfOverride.NewUnitCost.Value * purchaseToInventoryFactor;
                            }
                        }
                    }
                    else
                    {
                        decimal purchaseToInventoryFactor = bomItem.Component.PurchaseToInventoryConversionFactor;
                        if (purchaseToInventoryFactor == 0)
                        {
                            throw new InvalidOperationException($"Purchase to Inventory Conversion Factor for component '{bomItem.Component.ComponentName}' is zero, which is invalid.");
                        }
                        currentComponentUnitPrice = currentComponentUnitPrice * purchaseToInventoryFactor;
                    }

                    decimal? conversionFactorFromUsageToInventory = await _unitConversionService.GetConversionFactorAsync(
                        itemUsageUnitId, componentInventoryUnitId, organizationId);

                    if (!conversionFactorFromUsageToInventory.HasValue || conversionFactorFromUsageToInventory.Value == 0)
                    {
                        throw new InvalidOperationException($"No valid conversion factor found from BOM Item usage unit '{bomItem.UsageUnit?.Abbreviation}' to component inventory unit '{bomItem.Component?.InventoryUnit?.Abbreviation}' for component '{bomItem.Component?.ComponentName}'.");
                    }

                    decimal quantityInInventoryUnit = itemQuantity * conversionFactorFromUsageToInventory.Value;
                    decimal quantityAdjustedForWaste = quantityInInventoryUnit * (1 + (itemWastePercentage / 100.0m));

                    itemCost = quantityAdjustedForWaste * currentComponentUnitPrice;

                }
                else if (bomItem.ComponentType.ToUpper() == "PRODUCT")
                {
                    if (bomItem.SubProduct == null)
                    {
                        throw new InvalidOperationException($"SubProduct with ID '{bomItem.ProductId}' for BOM Item '{bomItem.BOMItemId}' not found.");
                    }

                    decimal currentSubProductCost = bomItem.SubProduct.CalculatedCost;
                    Guid subProductUnitId = bomItem.SubProduct.ProductUnitId;

                    if (whatIfItems != null)
                    {
                        var whatIfOverride = whatIfItems.FirstOrDefault(wi => wi.BOMItemId == bomItem.BOMItemId);
                        if (whatIfOverride != null && whatIfOverride.NewUnitCost.HasValue)
                        {
                            currentSubProductCost = whatIfOverride.NewUnitCost.Value;
                            if (whatIfOverride.NewUnitId.HasValue)
                            {
                                decimal? conversionFactor = await _unitConversionService.GetConversionFactorAsync(
                                    whatIfOverride.NewUnitId.Value, subProductUnitId, organizationId);
                                if (!conversionFactor.HasValue || conversionFactor.Value == 0)
                                {
                                    throw new InvalidOperationException($"No valid conversion factor found for What-If cost unit from '{whatIfOverride.NewUnitId.Value}' to sub-product unit '{subProductUnitId}'.");
                                }
                                currentSubProductCost = whatIfOverride.NewUnitCost.Value * conversionFactor.Value;
                            }
                        }
                    }

                    decimal? conversionFactorFromUsageToSubProductUnit = await _unitConversionService.GetConversionFactorAsync(
                        itemUsageUnitId, subProductUnitId, organizationId);

                    if (!conversionFactorFromUsageToSubProductUnit.HasValue || conversionFactorFromUsageToSubProductUnit.Value == 0)
                    {
                        throw new InvalidOperationException($"No valid conversion factor found from BOM Item usage unit '{bomItem.UsageUnit?.Abbreviation}' to sub-product unit '{bomItem.SubProduct?.ProductUnit?.Abbreviation}' for sub-product '{bomItem.SubProduct?.ProductName}'.");
                    }

                    decimal quantityInSubProductUnit = itemQuantity * conversionFactorFromUsageToSubProductUnit.Value;
                    decimal quantityAdjustedForWaste = quantityInSubProductUnit * (1 + (itemWastePercentage / 100.0m));

                    itemCost = quantityAdjustedForWaste * currentSubProductCost;
                }
                else
                {
                    throw new InvalidOperationException($"Invalid ComponentType '{bomItem.ComponentType}' for BOM Item '{bomItem.BOMItemId}'.");
                }

                totalCalculatedCost += itemCost;
            }

            return totalCalculatedCost;
        }

        // เมธอดสำหรับ Trigger การคำนวณต้นทุนของ Product นั้นๆ ใหม่ (ย้ายมาจาก ProductService)
        public async Task RecalculateProductCostAsync(Guid productId, Guid organizationId)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == productId && p.OrganizationId == organizationId)
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return;
            }

            var hasBOMItems = await _context.BOMItems.AnyAsync(bi => bi.ParentProductId == productId);
            if (!hasBOMItems)
            {
                product.CalculatedCost = 0.0m;
            }
            else
            {
                product.CalculatedCost = await CalculateBOMCostInternal(productId, organizationId);
            }

            product.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            // --- Multi-level BOM: Trigger recalculation for any parent products that use this product as a sub-product ---
            var parentBOMItems = await _context.BOMItems
                .Where(bi => bi.ProductId == productId && bi.ComponentType.ToUpper() == "PRODUCT")
                .AsNoTracking()
                .Select(bi => new { bi.ParentProductId, bi.ParentProduct!.OrganizationId })
                .Distinct()
                .ToListAsync();

            foreach (var parentItem in parentBOMItems)
            {
                // Recursively call recalculate for parent products
                await RecalculateProductCostAsync(parentItem.ParentProductId, parentItem.OrganizationId);
            }
        }

        // เมธอดสำหรับคำนวณต้นทุนแบบจำลอง (What-If Analysis) (ย้ายมาจาก ProductService)
        public async Task<decimal?> GetWhatIfCalculatedCostAsync(Guid productId, Guid organizationId, List<WhatIfBomItemDto> whatIfItems)
        {
            var productExists = await _context.Products.AnyAsync(p => p.ProductId == productId && p.OrganizationId == organizationId);
            if (!productExists)
            {
                throw new InvalidOperationException($"Product with ID '{productId}' not found or does not belong to your organization.");
            }

            return await CalculateBOMCostInternal(productId, organizationId, whatIfItems);
        }

        // เมธอดสำหรับ Trigger การคำนวณต้นทุน Product ที่ได้รับผลกระทบจากการเปลี่ยนแปลงราคา Component
        public async Task RecalculateProductsAffectedByComponentPriceChange(Guid componentId, Guid organizationId)
        {
            var affectedParentProducts = await _context.BOMItems
                .Where(bi => bi.ComponentId == componentId && bi.ComponentType.ToUpper() == "COMPONENT")
                .AsNoTracking()
                .Select(bi => new { bi.ParentProductId, bi.ParentProduct!.OrganizationId })
                .Distinct()
                .ToListAsync();

            foreach (var parentProductInfo in affectedParentProducts)
            {
                // เรียก RecalculateProductCostAsync ของ ProductCostingService เอง
                await RecalculateProductCostAsync(parentProductInfo.ParentProductId, parentProductInfo.OrganizationId);
            }
        }
    }
}