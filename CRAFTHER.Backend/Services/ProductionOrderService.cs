// Path: CRAFTHER.Backend/Services/ProductionOrderService.cs
using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.DTOs.ProductionOrders;
using CRAFTHER.Backend.DTOs.StockAdjustments;
using CRAFTHER.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public class ProductionOrderService : IProductionOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitConversionService _unitConversionService; // สำหรับแปลงหน่วย
        private readonly IProductCostingService _productCostingService; // สำหรับดึงต้นทุนสินค้า
        private readonly IStockAdjustmentService _stockAdjustmentService; // สำหรับปรับปรุงสต็อก
        private readonly IComponentService _componentService; // สำหรับดึงข้อมูล Component
        private readonly IProductService _productService; // สำหรับดึงข้อมูล Product (ในกรณี SubProduct)

        public ProductionOrderService(ApplicationDbContext context,
                                      IUnitConversionService unitConversionService,
                                      IProductCostingService productCostingService,
                                      IStockAdjustmentService stockAdjustmentService,
                                      IComponentService componentService,
                                      IProductService productService)
        {
            _context = context;
            _unitConversionService = unitConversionService;
            _productCostingService = productCostingService;
            _stockAdjustmentService = stockAdjustmentService;
            _componentService = componentService;
            _productService = productService;
        }

        // Helper method to map ProductionOrder Model to ProductionOrderResponseDto
        private async Task<ProductionOrderResponseDto?> MapProductionOrderToResponseDto(ProductionOrder? productionOrder)
        {
            if (productionOrder == null) return null;

            // Load related entities for DTO
            if (productionOrder.Organization == null) await _context.Entry(productionOrder).Reference(po => po.Organization).LoadAsync();
            if (productionOrder.Product == null) await _context.Entry(productionOrder).Reference(po => po.Product).LoadAsync();
            if (productionOrder.UnitOfMeasure == null) await _context.Entry(productionOrder).Reference(po => po.UnitOfMeasure).LoadAsync();

            var responseDto = new ProductionOrderResponseDto
            {
                ProductionOrderId = productionOrder.ProductionOrderId,
                ProductionOrderCode = productionOrder.ProductionOrderCode,
                OrganizationId = productionOrder.OrganizationId,
                OrganizationName = productionOrder.Organization?.OrganizationName ?? "N/A",
                ProductId = productionOrder.ProductId,
                ProductCode = productionOrder.Product?.ProductCode ?? "N/A",
                ProductName = productionOrder.Product?.ProductName ?? "N/A",
                QuantityToProduce = productionOrder.QuantityToProduce,
                UnitOfMeasureId = productionOrder.UnitOfMeasureId,
                UnitOfMeasureName = productionOrder.UnitOfMeasure?.UnitName ?? "N/A",
                UnitOfMeasureAbbreviation = productionOrder.UnitOfMeasure?.Abbreviation ?? "N/A",
                Status = productionOrder.Status,
                OrderDate = productionOrder.OrderDate,
                DueDate = productionOrder.DueDate,
                CompletionDate = productionOrder.CompletionDate,
                Notes = productionOrder.Notes,
                CreatedAt = productionOrder.CreatedAt,
                UpdatedAt = productionOrder.UpdatedAt
            };

            // Load and map ProductionOrderItems
            var productionOrderItems = await _context.ProductionOrderItems
                .Where(poi => poi.ProductionOrderId == productionOrder.ProductionOrderId)
                .Include(poi => poi.Component).ThenInclude(c => c!.InventoryUnit)
                .Include(poi => poi.SubProduct).ThenInclude(p => p!.ProductUnit)
                .Include(poi => poi.UsageUnit)
                .AsNoTracking()
                .ToListAsync();

            responseDto.ProductionOrderItems = new List<ProductionOrderItemResponseDto>();
            foreach (var item in productionOrderItems)
            {
                responseDto.ProductionOrderItems.Add((await MapProductionOrderItemToResponseDto(item))!);
            }

            return responseDto;
        }

        // Helper method to map ProductionOrderItem Model to ProductionOrderItemResponseDto
        private async Task<ProductionOrderItemResponseDto?> MapProductionOrderItemToResponseDto(ProductionOrderItem? item)
        {
            if (item == null) return null;

            // Load related entities for DTO if not already included
            if (item.UsageUnit == null) await _context.Entry(item).Reference(poi => poi.UsageUnit).LoadAsync();
            if (item.Component == null && item.ComponentId.HasValue)
            {
                await _context.Entry(item).Reference(poi => poi.Component).LoadAsync();
                if (item.Component?.InventoryUnit == null) await _context.Entry(item.Component).Reference(c => c.InventoryUnit).LoadAsync();
            }
            if (item.SubProduct == null && item.ProductId.HasValue)
            {
                await _context.Entry(item).Reference(poi => poi.SubProduct).LoadAsync();
                if (item.SubProduct?.ProductUnit == null) await _context.Entry(item.SubProduct).Reference(p => p.ProductUnit).LoadAsync();
            }

            return new ProductionOrderItemResponseDto
            {
                ProductionOrderItemId = item.ProductionOrderItemId,
                ProductionOrderId = item.ProductionOrderId,
                ComponentId = item.ComponentId,
                ComponentCode = item.Component?.ComponentCode,
                ComponentName = item.Component?.ComponentName,
                ComponentInventoryUnitAbbreviation = item.Component?.InventoryUnit?.Abbreviation,
                SubProductId = item.ProductId,
                SubProductCode = item.SubProduct?.ProductCode,
                SubProductName = item.SubProduct?.ProductName,
                SubProductUnitAbbreviation = item.SubProduct?.ProductUnit?.Abbreviation,
                ItemType = item.ItemType,
                QuantityUsed = item.QuantityUsed,
                UsageUnitId = item.UsageUnitId,
                UsageUnitName = item.UsageUnit?.UnitName ?? "N/A",
                UsageUnitAbbreviation = item.UsageUnit?.Abbreviation ?? "N/A",
                UnitCostAtProduction = item.UnitCostAtProduction,
                QuantityUsedInInventoryUnit = item.QuantityUsedInInventoryUnit,
                Notes = item.Notes,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            };
        }

        public async Task<IEnumerable<ProductionOrderResponseDto>> GetAllProductionOrdersAsync(Guid organizationId)
        {
            var orders = await _context.ProductionOrders
                .Where(po => po.OrganizationId == organizationId)
                .Include(po => po.Organization)
                .Include(po => po.Product)
                .Include(po => po.UnitOfMeasure)
                .AsNoTracking()
                .OrderByDescending(po => po.OrderDate)
                .ToListAsync();

            var dtoList = new List<ProductionOrderResponseDto>();
            foreach (var order in orders)
            {
                dtoList.Add((await MapProductionOrderToResponseDto(order))!);
            }
            return dtoList;
        }

        public async Task<ProductionOrderResponseDto?> GetProductionOrderByIdAsync(Guid productionOrderId, Guid organizationId)
        {
            var order = await _context.ProductionOrders
                .Where(po => po.ProductionOrderId == productionOrderId && po.OrganizationId == organizationId)
                .Include(po => po.Organization)
                .Include(po => po.Product)
                .Include(po => po.UnitOfMeasure)
                .FirstOrDefaultAsync(); // Do not use AsNoTracking if you plan to modify it later in the same context instance.

            return await MapProductionOrderToResponseDto(order);
        }

        public async Task<ProductionOrderResponseDto> CreateProductionOrderAsync(CreateProductionOrderDto createDto, Guid organizationId)
        {
            // 1. Verify Organization exists
            var organizationExists = await _context.Organizations.AnyAsync(o => o.OrganizationId == organizationId);
            if (!organizationExists)
            {
                throw new InvalidOperationException($"Organization with ID '{organizationId}' not found.");
            }

            // 2. Verify Product to produce exists and belongs to the organization
            var product = await _context.Products
                .Where(p => p.ProductId == createDto.ProductId && p.OrganizationId == organizationId)
                .Include(p => p.ProductUnit) // Eager load ProductUnit for conversion checks
                .FirstOrDefaultAsync();
            if (product == null)
            {
                throw new InvalidOperationException($"Product with ID '{createDto.ProductId}' not found or does not belong to your organization.");
            }

            // 3. Verify UnitOfMeasure for QuantityToProduce is valid and matches ProductUnit
            if (createDto.UnitOfMeasureId != product.ProductUnitId)
            {
                // Optionally allow conversion if needed, but for simplicity assume ProductUnit for QuantityToProduce
                throw new InvalidOperationException($"Quantity to produce must be in the product's primary unit ('{product.ProductUnit?.Abbreviation}'). Provided unit ID '{createDto.UnitOfMeasureId}' does not match product unit ID '{product.ProductUnitId}'.");
            }

            // 4. Generate Production Order Code if not provided (or ensure uniqueness)
            // Assuming ProductionOrderCode is provided and checked for uniqueness in controller/validation.

            var productionOrder = new ProductionOrder
            {
                ProductionOrderId = Guid.NewGuid(),
                ProductionOrderCode = createDto.ProductionOrderCode,
                OrganizationId = organizationId,
                ProductId = createDto.ProductId,
                QuantityToProduce = createDto.QuantityToProduce,
                UnitOfMeasureId = createDto.UnitOfMeasureId,
                Status = createDto.Status,
                OrderDate = DateTime.UtcNow, // Set to current UTC time
                DueDate = createDto.DueDate,
                Notes = createDto.Notes,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.ProductionOrders.Add(productionOrder);
            await _context.SaveChangesAsync();

            // After creating the Production Order, we don't automatically generate Production Order Items here.
            // Production Order Items will be added separately, possibly based on the BOM, as the order progresses.
            // Or a "Generate Production Items from BOM" action can be added.
            // For now, we just create the header.

            return (await MapProductionOrderToResponseDto(productionOrder))!;
        }


        public async Task<ProductionOrderResponseDto?> UpdateProductionOrderAsync(UpdateProductionOrderDto updateDto, Guid organizationId)
        {
            var productionOrder = await _context.ProductionOrders
                .Where(po => po.ProductionOrderId == updateDto.ProductionOrderId && po.OrganizationId == organizationId)
                .FirstOrDefaultAsync();

            if (productionOrder == null)
            {
                return null; // Not found or does not belong to the organization
            }

            // Apply updates
            if (updateDto.Status != null) productionOrder.Status = updateDto.Status;
            if (updateDto.QuantityToProduce.HasValue) productionOrder.QuantityToProduce = updateDto.QuantityToProduce.Value;
            if (updateDto.DueDate.HasValue) productionOrder.DueDate = updateDto.DueDate.Value;
            if (updateDto.CompletionDate.HasValue) productionOrder.CompletionDate = updateDto.CompletionDate.Value;
            if (updateDto.Notes != null) productionOrder.Notes = updateDto.Notes;

            productionOrder.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return (await MapProductionOrderToResponseDto(productionOrder))!;
        }

        public async Task<bool> DeleteProductionOrderAsync(Guid productionOrderId, Guid organizationId)
        {
            var productionOrder = await _context.ProductionOrders
                .Where(po => po.ProductionOrderId == productionOrderId && po.OrganizationId == organizationId)
                .FirstOrDefaultAsync();

            if (productionOrder == null)
            {
                return false; // Not found or does not belong to the organization
            }

            // Prevent deletion if already completed or in progress (business rule)
            if (productionOrder.Status == "Completed" || productionOrder.Status == "InProgress")
            {
                throw new InvalidOperationException($"Cannot delete Production Order '{productionOrder.ProductionOrderCode}' with status '{productionOrder.Status}'. Please cancel it first.");
            }
            // If the status is not "Completed" or "InProgress", it implies no stock adjustments have been made for it yet.
            // If ProductionOrderItems already exist, they will be cascade deleted by EF Core (configured in DbContext).

            _context.ProductionOrders.Remove(productionOrder);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ProductionOrderResponseDto?> CompleteProductionOrderAsync(Guid productionOrderId, Guid organizationId)
        {
            var productionOrder = await _context.ProductionOrders
                .Where(po => po.ProductionOrderId == productionOrderId && po.OrganizationId == organizationId)
                .Include(po => po.Product).ThenInclude(p => p!.ProductUnit) // Include Product and its ProductUnit
                .Include(po => po.ProductionOrderItems)
                    .ThenInclude(poi => poi.Component!).ThenInclude(c => c.InventoryUnit) // Load Component and its InventoryUnit
                .Include(po => po.ProductionOrderItems)
                    .ThenInclude(poi => poi.SubProduct!).ThenInclude(p => p.ProductUnit) // Load SubProduct and its ProductUnit
                .FirstOrDefaultAsync();

            if (productionOrder == null)
            {
                return null;
            }

            if (productionOrder.Status == "Completed")
            {
                throw new InvalidOperationException($"Production Order '{productionOrder.ProductionOrderCode}' is already completed.");
            }
            if (productionOrder.Status == "Cancelled")
            {
                throw new InvalidOperationException($"Production Order '{productionOrder.ProductionOrderCode}' is cancelled and cannot be completed.");
            }

            // 1. Consume Components/Sub-Products (Decrease Stock)
            if (productionOrder.ProductionOrderItems != null && productionOrder.ProductionOrderItems.Any())
            {
                foreach (var item in productionOrder.ProductionOrderItems)
                {
                    Guid consumptionTypeId = await _context.StockAdjustmentTypes
                        .Where(sat => sat.Name == "Consumption" && sat.Effect == "Decrease")
                        .Select(sat => sat.AdjustmentTypeId)
                        .FirstOrDefaultAsync();

                    if (consumptionTypeId == Guid.Empty)
                    {
                        throw new InvalidOperationException("Stock Adjustment Type 'Consumption' (Decrease) not found. Please ensure it's seeded correctly.");
                    }

                    // สร้าง CreateStockAdjustmentDto ตาม ItemType (Component หรือ Product)
                    CreateStockAdjustmentDto createStockAdjustmentDto;
                    Guid itemStockUnitId; // InventoryUnitId for Component, ProductUnitId for Product

                    if (item.ItemType.ToUpper() == "COMPONENT")
                    {
                        if (!item.ComponentId.HasValue || item.Component == null) continue;
                        itemStockUnitId = item.Component.InventoryUnitId;
                        createStockAdjustmentDto = new CreateStockAdjustmentDto
                        {
                            ComponentId = item.ComponentId.Value,
                            AdjustmentTypeId = consumptionTypeId,
                            Quantity = item.QuantityUsedInInventoryUnit, // ปริมาณที่ใช้ในหน่วย Inventory Unit
                            UnitOfMeasureId = itemStockUnitId, // หน่วยที่ใช้คือ InventoryUnit ของ Component
                            Notes = $"Consumption for Production Order: {productionOrder.ProductionOrderCode}"
                        };
                    }
                    else if (item.ItemType.ToUpper() == "PRODUCT") // SubProduct
                    {
                        if (!item.ProductId.HasValue || item.SubProduct == null) continue;
                        itemStockUnitId = item.SubProduct.ProductUnitId;
                        createStockAdjustmentDto = new CreateStockAdjustmentDto
                        {
                            ProductId = item.ProductId.Value,
                            AdjustmentTypeId = consumptionTypeId,
                            Quantity = item.QuantityUsedInInventoryUnit, // ปริมาณที่ใช้ในหน่วย Product Unit
                            UnitOfMeasureId = itemStockUnitId, // หน่วยที่ใช้คือ ProductUnit ของ SubProduct
                            Notes = $"Consumption for Production Order: {productionOrder.ProductionOrderCode}"
                        };
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unsupported ItemType '{item.ItemType}' in ProductionOrderItem.");
                    }

                    await _stockAdjustmentService.CreateStockAdjustmentAsync(createStockAdjustmentDto, organizationId);
                }
            }

            // 2. Increase Produced Product Stock (Increase Stock)
            if (productionOrder.Product == null)
            {
                throw new InvalidOperationException($"Produced Product with ID '{productionOrder.ProductId}' not found for Production Order '{productionOrder.ProductionOrderCode}'.");
            }

            Guid productionInTypeId = await _context.StockAdjustmentTypes
                .Where(sat => sat.Name == "Production In" && sat.Effect == "Increase")
                .Select(sat => sat.AdjustmentTypeId)
                .FirstOrDefaultAsync();

            if (productionInTypeId == Guid.Empty)
            {
                throw new InvalidOperationException("Stock Adjustment Type 'Production In' (Increase) not found. Please ensure it's seeded correctly.");
            }

            // สร้าง CreateStockAdjustmentDto สำหรับการเพิ่มสต็อก Product
            var createProductAdjustmentForOutputDto = new CreateStockAdjustmentDto
            {
                ProductId = productionOrder.ProductId, // ใช้ ProductId ที่ถูกต้อง
                AdjustmentTypeId = productionInTypeId,
                Quantity = productionOrder.QuantityToProduce, // ปริมาณที่ผลิตได้
                UnitOfMeasureId = productionOrder.Product.ProductUnitId, // หน่วยของ Product ที่ผลิต
                Notes = $"Production Output: {productionOrder.ProductionOrderCode}"
            };

            await _stockAdjustmentService.CreateStockAdjustmentAsync(createProductAdjustmentForOutputDto, organizationId);


            // 3. Update Production Order Status
            productionOrder.Status = "Completed";
            productionOrder.CompletionDate = DateTime.UtcNow;
            productionOrder.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return (await MapProductionOrderToResponseDto(productionOrder))!;
        }

        public async Task<IEnumerable<ProductionOrderItemResponseDto>> GetRequiredMaterialsForProductionAsync(Guid productId, decimal quantityToProduce, Guid organizationId)
        {
            // 1. Verify Product exists and belongs to the organization
            var product = await _context.Products
                .Where(p => p.ProductId == productId && p.OrganizationId == organizationId)
                .Include(p => p.ProductUnit)
                .FirstOrDefaultAsync();
            if (product == null)
            {
                throw new InvalidOperationException($"Product with ID '{productId}' not found or does not belong to your organization.");
            }

            // 2. Get BOM Items for the product
            var bomItems = await _context.BOMItems
                .Where(bi => bi.ParentProductId == productId)
                .Include(bi => bi.Component)
                    .ThenInclude(c => c!.InventoryUnit)
                .Include(bi => bi.SubProduct)
                    .ThenInclude(p => p!.ProductUnit)
                .Include(bi => bi.UsageUnit)
                .AsNoTracking()
                .ToListAsync();

            if (!bomItems.Any())
            {
                return Enumerable.Empty<ProductionOrderItemResponseDto>(); // No BOM, no required materials
            }

            var requiredItems = new List<ProductionOrderItemResponseDto>();

            foreach (var bomItem in bomItems)
            {
                decimal requiredQuantityInUsageUnit = bomItem.Quantity * quantityToProduce;
                decimal requiredQuantityAdjustedForWaste = requiredQuantityInUsageUnit * (1 + bomItem.WastePercentage / 100.0m);

                // Convert required quantity to the inventory unit of component/product unit of sub-product
                Guid targetUnitId;
                string itemType;
                decimal currentItemCost = 0.0m; // For UnitCostAtProduction
                Guid? componentId = null;
                Guid? subProductId = null;
                string? componentCode = null;
                string? componentName = null;
                string? componentInventoryUnitAbbreviation = null;
                string? subProductCode = null;
                string? subProductName = null;
                string? subProductUnitAbbreviation = null;

                if (bomItem.ComponentType.ToUpper() == "COMPONENT")
                {
                    if (bomItem.Component == null) throw new InvalidOperationException($"Component for BOM Item {bomItem.BOMItemId} not found.");
                    targetUnitId = bomItem.Component.InventoryUnitId;
                    itemType = "COMPONENT";
                    componentId = bomItem.ComponentId;
                    componentCode = bomItem.Component.ComponentCode;
                    componentName = bomItem.Component.ComponentName;
                    componentInventoryUnitAbbreviation = bomItem.Component.InventoryUnit?.Abbreviation;
                    // Get current unit price from component, convert to inventory unit cost
                    decimal purchaseUnitPrice = bomItem.Component.UnitPrice;
                    decimal purchaseToInventoryFactor = bomItem.Component.PurchaseToInventoryConversionFactor;
                    if (purchaseToInventoryFactor == 0) throw new InvalidOperationException($"Conversion factor for component '{bomItem.Component.ComponentName}' is zero.");
                    currentItemCost = purchaseUnitPrice * purchaseToInventoryFactor; // Cost per InventoryUnit
                }
                else if (bomItem.ComponentType.ToUpper() == "PRODUCT")
                {
                    if (bomItem.SubProduct == null) throw new InvalidOperationException($"SubProduct for BOM Item {bomItem.BOMItemId} not found.");
                    targetUnitId = bomItem.SubProduct.ProductUnitId;
                    itemType = "PRODUCT";
                    subProductId = bomItem.ProductId;
                    subProductCode = bomItem.SubProduct.ProductCode;
                    subProductName = bomItem.SubProduct.ProductName;
                    subProductUnitAbbreviation = bomItem.SubProduct.ProductUnit?.Abbreviation;
                    currentItemCost = bomItem.SubProduct.CalculatedCost; // Cost per ProductUnit
                }
                else
                {
                    throw new InvalidOperationException($"Unknown ItemType in BOMItem: {bomItem.ComponentType}");
                }

                decimal? conversionFactorFromUsageToTarget = await _unitConversionService.GetConversionFactorAsync(
                    bomItem.UsageUnitId, targetUnitId, organizationId);

                if (!conversionFactorFromUsageToTarget.HasValue || conversionFactorFromUsageToTarget.Value == 0)
                {
                    throw new InvalidOperationException($"No valid conversion factor found from BOM Item usage unit '{bomItem.UsageUnit?.Abbreviation}' to target unit '{targetUnitId}'.");
                }

                decimal finalQuantityInTargetUnit = requiredQuantityAdjustedForWaste * conversionFactorFromUsageToTarget.Value;

                requiredItems.Add(new ProductionOrderItemResponseDto
                {
                    ProductionOrderItemId = Guid.Empty, // This is a "required" calculation, not a saved item
                    ProductionOrderId = Guid.Empty, // This is a "required" calculation
                    ComponentId = componentId,
                    ComponentCode = componentCode,
                    ComponentName = componentName,
                    ComponentInventoryUnitAbbreviation = componentInventoryUnitAbbreviation,
                    SubProductId = subProductId,
                    SubProductCode = subProductCode,
                    SubProductName = subProductName,
                    SubProductUnitAbbreviation = subProductUnitAbbreviation,
                    ItemType = itemType,
                    QuantityUsed = requiredQuantityInUsageUnit, // Original quantity in usage unit for display
                    UsageUnitId = bomItem.UsageUnitId,
                    UsageUnitName = bomItem.UsageUnit?.UnitName ?? "N/A",
                    UsageUnitAbbreviation = bomItem.UsageUnit?.Abbreviation ?? "N/A",
                    UnitCostAtProduction = currentItemCost, // Current cost for estimation
                    QuantityUsedInInventoryUnit = finalQuantityInTargetUnit, // The key quantity for consumption
                    Notes = bomItem.Remarks,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            return requiredItems;
        }
    }
}