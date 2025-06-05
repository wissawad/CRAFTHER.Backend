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
            var organization = await _context.Organizations.FindAsync(organizationId);
            if (organization == null)
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
            // (หรือสามารถแปลงได้ ถ้า ProductUnit กับ UnitOfMeasureId ที่ส่งมาไม่ตรงกัน)
            if (createDto.UnitOfMeasureId != product.ProductUnitId)
            {
                // ลองตรวจสอบ Conversion Factor เพื่อให้ยืดหยุ่นมากขึ้น
                var conversionFactorFromProduceUnitToProductUnit = await _unitConversionService.GetConversionFactorAsync(
                    createDto.UnitOfMeasureId, product.ProductUnitId, organizationId);

                if (!conversionFactorFromProduceUnitToProductUnit.HasValue || conversionFactorFromProduceUnitToProductUnit.Value == 0)
                {
                    throw new InvalidOperationException($"Quantity to produce must be in the product's primary unit ('{product.ProductUnit?.Abbreviation}') or a convertible unit. No valid conversion found from unit '{createDto.UnitOfMeasureId}' to '{product.ProductUnitId}'.");
                }
                // ถ้ามีการแปลง หน่วยที่ใช้ในการผลิตจะถูกแปลงเป็นหน่วยของ Product.ProductUnit
                createDto.QuantityToProduce *= conversionFactorFromProduceUnitToProductUnit.Value;
                createDto.UnitOfMeasureId = product.ProductUnitId; // อัปเดตให้เป็นหน่วยของ Product
            }

            // 4. Generate Production Order Code (ถ้าไม่มีการส่งมา หรือ ต้องการให้ Gen อัตโนมัติ)
            // ณ ตอนนี้ DTO บังคับให้ส่ง ProductionOrderCode มาแล้ว ดังนั้นเราจะใช้ค่าจาก DTO
            // ถ้าอยากให้ Gen อัตโนมัติ สามารถเพิ่ม Logic นับเลขที่ต่อจากรหัสสุดท้ายใน DB หรือใช้ Guid.NewGuid().ToString("N").Substring(0, 8)
            // แต่เนื่องจาก DTO กำหนด [Required] ไว้แล้ว เราจะใช้ค่าที่ส่งมา
            var productionOrderCode = createDto.ProductionOrderCode; // ใช้ค่าที่ส่งมาจาก DTO
            // Optional: ตรวจสอบความซ้ำซ้อนของ ProductionOrderCode
            var codeExists = await _context.ProductionOrders.AnyAsync(po => po.OrganizationId == organizationId && po.ProductionOrderCode == productionOrderCode);
            if (codeExists)
            {
                throw new InvalidOperationException($"Production Order Code '{productionOrderCode}' already exists for this organization.");
            }

            var productionOrder = new ProductionOrder
            {
                ProductionOrderId = Guid.NewGuid(),
                ProductionOrderCode = productionOrderCode, // ใช้ Code จาก DTO
                OrganizationId = organizationId,
                ProductId = createDto.ProductId,
                QuantityToProduce = createDto.QuantityToProduce,
                UnitOfMeasureId = createDto.UnitOfMeasureId,
                Status = createDto.Status,
                OrderDate = DateTime.UtcNow,
                DueDate = createDto.DueDate,
                Notes = createDto.Notes,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.ProductionOrders.Add(productionOrder);
            await _context.SaveChangesAsync(); // บันทึก Production Order Header ก่อน

            // 5. สร้าง Production Order Items จาก BOM ของ Product ที่ผลิต
            var bomItems = await _context.BOMItems
                .Where(bi => bi.ParentProductId == product.ProductId)
                .Include(bi => bi.Component).ThenInclude(c => c!.InventoryUnit) // Eager load for Component
                .Include(bi => bi.SubProduct).ThenInclude(p => p!.ProductUnit)   // Eager load for SubProduct
                .Include(bi => bi.UsageUnit) // Eager load for UsageUnit
                .AsNoTracking()
                .ToListAsync();

            if (!bomItems.Any())
            {
                // ถ้าไม่มี BOM ให้ Product นี้ อาจจะอนุญาตให้สร้าง Production Order ได้ (ถ้า Product นั้นไม่จำเป็นต้องมี BOM)
                // หรืออาจจะ Throw Error ถ้า Product ต้องมี BOM เสมอ
                // สำหรับตอนนี้ เราจะถือว่าถ้าไม่มี BOM ก็สร้างได้ แต่จะไม่มี ProductionOrderItems
                // หรืออาจจะโยน Exception: throw new InvalidOperationException($"Product '{product.ProductName}' does not have a Bill of Materials defined.");
            }

            var productionOrderItems = new List<ProductionOrderItem>();
            foreach (var bomItem in bomItems)
            {
                // คำนวณปริมาณที่ต้องใช้สำหรับ Production Order ทั้งหมด
                decimal quantityNeededForOrder = bomItem.Quantity * createDto.QuantityToProduce;
                decimal quantityNeededAdjustedForWaste = quantityNeededForOrder * (1 + bomItem.WastePercentage / 100.0m);

                Guid itemStockUnitId; // InventoryUnitId for Component, ProductUnitId for SubProduct
                decimal currentItemCost; // ต้นทุน ณ ปัจจุบันของวัตถุดิบ/SubProduct
                Guid? componentId = null;
                Guid? subProductId = null;
                string itemType;

                if (bomItem.ComponentType.ToUpper() == "COMPONENT")
                {
                    if (bomItem.Component == null)
                        throw new InvalidOperationException($"Component for BOM Item '{bomItem.BOMItemId}' not found during Production Order creation.");
                    itemStockUnitId = bomItem.Component.InventoryUnitId;
                    itemType = "COMPONENT";
                    componentId = bomItem.ComponentId;
                    // ต้นทุนของ Component คือ UnitPrice * PurchaseToInventoryConversionFactor
                    currentItemCost = bomItem.Component.UnitPrice * bomItem.Component.PurchaseToInventoryConversionFactor;
                }
                else if (bomItem.ComponentType.ToUpper() == "PRODUCT") // SubProduct
                {
                    if (bomItem.SubProduct == null)
                        throw new InvalidOperationException($"SubProduct for BOM Item '{bomItem.BOMItemId}' not found during Production Order creation.");
                    itemStockUnitId = bomItem.SubProduct.ProductUnitId;
                    itemType = "PRODUCT";
                    subProductId = bomItem.ProductId;
                    // ต้นทุนของ SubProduct คือ CalculatedCost
                    currentItemCost = bomItem.SubProduct.CalculatedCost;
                }
                else
                {
                    throw new InvalidOperationException($"Unsupported ItemType '{bomItem.ComponentType}' in BOMItem for Production Order creation.");
                }

                // แปลงปริมาณที่ต้องใช้จาก UsageUnit ของ BOMItem ไปยังหน่วยสต็อกหลัก (Inventory/Product Unit) ของ Item
                decimal? conversionFactorFromUsageToStockUnit = await _unitConversionService.GetConversionFactorAsync(
                    bomItem.UsageUnitId, itemStockUnitId, organizationId);

                if (!conversionFactorFromUsageToStockUnit.HasValue || conversionFactorFromUsageToStockUnit.Value == 0)
                {
                    throw new InvalidOperationException($"No valid conversion factor found from BOM Item usage unit '{bomItem.UsageUnit?.Abbreviation}' to item's stock unit.");
                }

                decimal finalQuantityInStockUnit = quantityNeededAdjustedForWaste * conversionFactorFromUsageToStockUnit.Value;

                // ตรวจสอบสต็อกว่าเพียงพอหรือไม่
                if (itemType == "COMPONENT" && bomItem.Component!.CurrentStockQuantity < finalQuantityInStockUnit)
                {
                    throw new InvalidOperationException($"Insufficient stock for component '{bomItem.Component.ComponentName}'. Available: {bomItem.Component.CurrentStockQuantity} {bomItem.Component.InventoryUnit?.Abbreviation}, Required: {finalQuantityInStockUnit} {bomItem.Component.InventoryUnit?.Abbreviation}.");
                }
                if (itemType == "PRODUCT" && bomItem.SubProduct!.CurrentStockQuantity < finalQuantityInStockUnit)
                {
                    throw new InvalidOperationException($"Insufficient stock for sub-product '{bomItem.SubProduct.ProductName}'. Available: {bomItem.SubProduct.CurrentStockQuantity} {bomItem.SubProduct.ProductUnit?.Abbreviation}, Required: {finalQuantityInStockUnit} {bomItem.SubProduct.ProductUnit?.Abbreviation}.");
                }


                productionOrderItems.Add(new ProductionOrderItem
                {
                    ProductionOrderItemId = Guid.NewGuid(),
                    ProductionOrderId = productionOrder.ProductionOrderId,
                    ComponentId = componentId,
                    ProductId = subProductId,
                    ItemType = itemType,
                    QuantityUsed = quantityNeededForOrder, // ปริมาณตามสูตรก่อนปรับ Waste
                    UsageUnitId = bomItem.UsageUnitId,
                    UnitCostAtProduction = currentItemCost, // ต้นทุน ณ เวลาที่สร้าง PO
                    QuantityUsedInInventoryUnit = finalQuantityInStockUnit, // ปริมาณที่ใช้จริงรวม Waste และแปลงหน่วยแล้ว
                    Notes = bomItem.Remarks,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            if (productionOrderItems.Any())
            {
                _context.ProductionOrderItems.AddRange(productionOrderItems);
                await _context.SaveChangesAsync(); // บันทึก Production Order Items
            }

            return (await MapProductionOrderToResponseDto(productionOrder))!;
        }


        public async Task<ProductionOrderResponseDto?> UpdateProductionOrderAsync(UpdateProductionOrderDto updateDto, Guid organizationId)
        {
            var productionOrder = await _context.ProductionOrders
                .Where(po => po.ProductionOrderId == updateDto.ProductionOrderId && po.OrganizationId == organizationId)
                .Include(po => po.Product).ThenInclude(p => p!.ProductUnit) // Include Product and its ProductUnit
                .Include(po => po.ProductionOrderItems) // Include items if needed for business rules or recalculations
                    .ThenInclude(poi => poi.Component!).ThenInclude(c => c.InventoryUnit)
                .Include(po => po.ProductionOrderItems)
                    .ThenInclude(poi => poi.SubProduct!).ThenInclude(p => p.ProductUnit)
                .FirstOrDefaultAsync(); // ไม่ใช้ AsNoTracking() เพราะเราจะ Update Entity นี้

            if (productionOrder == null)
            {
                return null; // Not found or does not belong to the organization
            }

            // Business Rule: ห้ามแก้ไข Production Order ที่มีสถานะ Completed หรือ Cancelled
            if (productionOrder.Status == "Completed" || productionOrder.Status == "Cancelled")
            {
                throw new InvalidOperationException($"Cannot update Production Order '{productionOrder.ProductionOrderCode}' because it is already in '{productionOrder.Status}' status.");
            }

            // Apply updates if values are provided in DTO
            bool quantityChanged = false;
            if (updateDto.QuantityToProduce.HasValue && updateDto.QuantityToProduce.Value != productionOrder.QuantityToProduce)
            {
                if (updateDto.QuantityToProduce.Value <= 0)
                {
                    throw new ArgumentException("Quantity to produce must be greater than zero.");
                }
                // ตรวจสอบหน่วยของ QuantityToProduce ถ้ามีการเปลี่ยนแปลง DTO อาจจะส่งหน่วยมาด้วยก็ได้
                // แต่ตาม DTO ปัจจุบัน QuantityToProduce และ UnitOfMeasureId ไม่ควรเปลี่ยนหลังจากสร้าง
                // ถ้า DTO อนุญาตให้เปลี่ยน UnitOfMeasureId ด้วย จะต้องทำการแปลงหน่วยตรงนี้ด้วย
                // สำหรับตอนนี้ เราจะถือว่า QuantityToProduce คือหน่วยของ Product.ProductUnit
                productionOrder.QuantityToProduce = updateDto.QuantityToProduce.Value;
                quantityChanged = true;
            }

            if (updateDto.DueDate.HasValue) productionOrder.DueDate = updateDto.DueDate.Value;
            if (updateDto.CompletionDate.HasValue) productionOrder.CompletionDate = updateDto.CompletionDate.Value; // ตรงนี้จะใช้เมื่อเรียก CompleteProductionOrderAsync
            if (updateDto.Notes != null) productionOrder.Notes = updateDto.Notes;

            // การเปลี่ยนสถานะ: ควรมี Logic ในการตรวจสอบสถานะที่ถูกต้อง
            if (updateDto.Status != null && updateDto.Status != productionOrder.Status)
            {
                // ตัวอย่าง Business Rules สำหรับการเปลี่ยนสถานะ
                if (productionOrder.Status == "Pending" && (updateDto.Status == "InProgress" || updateDto.Status == "Cancelled"))
                {
                    productionOrder.Status = updateDto.Status;
                }
                else if (productionOrder.Status == "InProgress" && (updateDto.Status == "Completed" || updateDto.Status == "Cancelled"))
                {
                    productionOrder.Status = updateDto.Status;
                }
                else
                {
                    throw new InvalidOperationException($"Invalid status transition from '{productionOrder.Status}' to '{updateDto.Status}'.");
                }
            }

            productionOrder.UpdatedAt = DateTime.UtcNow; // อัปเดต timestamp
            await _context.SaveChangesAsync();

            // ถ้า QuantityToProduce เปลี่ยนแปลง อาจจะต้อง recalculate ProductionOrderItems
            // สำหรับ MVP, เราอาจจะไม่อนุญาตให้อัปเดต ProductionOrderItems ผ่าน Update ProductionOrder Header โดยตรง
            // แต่จะให้มี API แยกสำหรับการจัดการ ProductionOrderItems หรือ Recalculate BOM
            // หรือ ถ้าอยากให้ recalculate อัตโนมัติเมื่อ QuantityToProduce เปลี่ยน
            if (quantityChanged && productionOrder.ProductionOrderItems != null)
            {
                // Logic สำหรับ Recalculate/Re-create ProductionOrderItems หาก QuantityToProduce เปลี่ยน
                // ณ ตอนนี้ เราจะปล่อยให้เป็นไปตามสถานะปัจจุบัน และคาดว่าถ้ามีการเปลี่ยนแปลงปริมาณ จะมีการปรับ ProductionOrderItem เอง
                // หรืออาจจะเรียกเมธอด GetRequiredMaterialsForProductionAsync เพื่อแสดงผลใหม่
                // หรือลบ ProductionOrderItems เดิมทิ้ง แล้วสร้างใหม่ทั้งหมด (ซึ่งอาจจะอันตรายถ้ามีการบันทึก Actuals แล้ว)
                // สำหรับ MVP, เราจะเน้นที่การอัปเดต Header และอนุญาตให้ Logic ของ ProductionOrderItem ทำงานแยกกัน
            }

            return (await MapProductionOrderToResponseDto(productionOrder))!;
        }

        public async Task<bool> DeleteProductionOrderAsync(Guid productionOrderId, Guid organizationId)
        {
            var productionOrder = await _context.ProductionOrders
                .Where(po => po.ProductionOrderId == productionOrderId && po.OrganizationId == organizationId)
                .Include(po => po.Product).ThenInclude(p => p!.ProductUnit) // Include Product and its ProductUnit
                .Include(po => po.ProductionOrderItems) // Include items to check if any consumption/production occurred
                    .ThenInclude(poi => poi.Component!).ThenInclude(c => c.InventoryUnit)
                .Include(po => po.ProductionOrderItems)
                    .ThenInclude(poi => poi.SubProduct!).ThenInclude(p => p.ProductUnit)
                .FirstOrDefaultAsync();

            if (productionOrder == null)
            {
                return false; // Not found or does not belong to the organization
            }

            // Business Rule: ไม่อนุญาตให้ลบ Production Order ที่มีสถานะ "Completed" หรือ "InProgress"
            // หากต้องการลบ ต้องเปลี่ยนสถานะเป็น "Cancelled" ก่อน และจัดการเรื่อง Revert Stock ด้วยมือ (หากจำเป็น)
            // หรือสร้าง Logic Revert Stock อัตโนมัติเมื่อเปลี่ยนเป็น Cancelled
            if (productionOrder.Status == "Completed" || productionOrder.Status == "InProgress")
            {
                throw new InvalidOperationException($"Cannot delete Production Order '{productionOrder.ProductionOrderCode}' with status '{productionOrder.Status}'. It must be 'Pending' or 'Cancelled' to be deleted.");
            }

            // If the status is "Pending" or "Cancelled", we assume no stock adjustments have been permanently made yet.
            // If ProductionOrderItems already exist and are linked to actual stock movements (e.g., if we allowed partial completion),
            // then a more complex revert logic would be needed here.
            // For MVP simplicity, we assume 'Pending' or 'Cancelled' status means no stock impact yet.

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