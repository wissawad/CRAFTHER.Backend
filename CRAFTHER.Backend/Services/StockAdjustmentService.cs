// Path: CRAFTHER.Backend/Services/StockAdjustmentService.cs

using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.DTOs;
using CRAFTHER.Backend.DTOs.StockAdjustments;
using CRAFTHER.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public class StockAdjustmentService : IStockAdjustmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitConversionService _unitConversionService;

        public StockAdjustmentService(ApplicationDbContext context, IUnitConversionService unitConversionService)
        {
            _context = context;
            _unitConversionService = unitConversionService;
        }

        // Helper method to map StockAdjustment Model to StockAdjustmentResponseDto
        private async Task<StockAdjustmentResponseDto?> MapStockAdjustmentToResponseDto(StockAdjustment? stockAdjustment)
        {
            if (stockAdjustment == null) return null;

            // Ensure related entities are loaded for the DTO
            if (stockAdjustment.Organization == null)
            {
                await _context.Entry(stockAdjustment).Reference(sa => sa.Organization).LoadAsync();
            }
            // *** Load Component หรือ Product ตามค่าที่มีอยู่ ***
            if (stockAdjustment.Component == null && stockAdjustment.ComponentId.HasValue)
            {
                await _context.Entry(stockAdjustment).Reference(sa => sa.Component).LoadAsync();
                if (stockAdjustment.Component?.InventoryUnit == null) await _context.Entry(stockAdjustment.Component).Reference(c => c.InventoryUnit).LoadAsync();
            }
            if (stockAdjustment.Product == null && stockAdjustment.ProductId.HasValue)
            {
                await _context.Entry(stockAdjustment).Reference(sa => sa.Product).LoadAsync();
                if (stockAdjustment.Product?.ProductUnit == null) await _context.Entry(stockAdjustment.Product).Reference(p => p.ProductUnit).LoadAsync();
            }
            // *** สิ้นสุดการ Load ***

            if (stockAdjustment.AdjustmentType == null)
            {
                await _context.Entry(stockAdjustment).Reference(sa => sa.AdjustmentType).LoadAsync();
            }
            if (stockAdjustment.UnitOfMeasure == null)
            {
                await _context.Entry(stockAdjustment).Reference(sa => sa.UnitOfMeasure).LoadAsync();
            }

            var responseDto = new StockAdjustmentResponseDto
            {
                AdjustmentId = stockAdjustment.AdjustmentId,
                OrganizationId = stockAdjustment.OrganizationId,
                OrganizationName = stockAdjustment.Organization?.OrganizationName ?? "N/A",

                // *** ตั้งค่า Component/Product ID/Code/Name/Unit ตามค่าที่มีอยู่ ***
                ComponentId = stockAdjustment.ComponentId,
                ComponentCode = stockAdjustment.Component?.ComponentCode,
                ComponentName = stockAdjustment.Component?.ComponentName,
                ComponentInventoryUnitAbbreviation = stockAdjustment.Component?.InventoryUnit?.Abbreviation,

                ProductId = stockAdjustment.ProductId,
                ProductCode = stockAdjustment.Product?.ProductCode,
                ProductName = stockAdjustment.Product?.ProductName,
                ProductUnitAbbreviation = stockAdjustment.Product?.ProductUnit?.Abbreviation,
                // *** สิ้นสุดการตั้งค่า ***

                AdjustmentTypeId = stockAdjustment.AdjustmentTypeId,
                AdjustmentTypeName = stockAdjustment.AdjustmentType?.Name ?? "N/A",
                AdjustmentTypeEffect = stockAdjustment.AdjustmentType?.Effect ?? "N/A",
                Quantity = stockAdjustment.Quantity,
                UnitOfMeasureId = stockAdjustment.UnitOfMeasureId,
                UnitOfMeasureName = stockAdjustment.UnitOfMeasure?.UnitName ?? "N/A",
                UnitOfMeasureAbbreviation = stockAdjustment.UnitOfMeasure?.Abbreviation ?? "N/A",
                QuantityBeforeAdjustment = stockAdjustment.QuantityBeforeAdjustment,
                QuantityAfterAdjustment = stockAdjustment.QuantityAfterAdjustment,
                Notes = stockAdjustment.Notes,
                AdjustmentDate = stockAdjustment.AdjustmentDate,
                CreatedAt = stockAdjustment.CreatedAt,
                UpdatedAt = stockAdjustment.UpdatedAt
            };

            // *** ตั้งค่า ComponentCurrentStockQuantity หรือ ProductCurrentStockQuantity ***
            if (stockAdjustment.ComponentId.HasValue)
            {
                responseDto.ItemCurrentStockQuantity = stockAdjustment.Component?.CurrentStockQuantity ?? 0;
            }
            else if (stockAdjustment.ProductId.HasValue)
            {
                // ถ้าเป็น Product, ใช้ CurrentStockQuantity ของ Product
                responseDto.ItemCurrentStockQuantity = stockAdjustment.Product?.CurrentStockQuantity ?? 0;
            }
            // *** สิ้นสุดการตั้งค่า ***

            return responseDto;
        }

        public async Task<IEnumerable<StockAdjustmentResponseDto>> GetAllStockAdjustmentsAsync(Guid organizationId)
        {
            var adjustments = await _context.StockAdjustments
                .Where(sa => sa.OrganizationId == organizationId)
                .Include(sa => sa.Component).ThenInclude(c => c!.InventoryUnit) // Eager load for Component
                .Include(sa => sa.Product).ThenInclude(p => p!.ProductUnit)   // Eager load for Product
                .Include(sa => sa.AdjustmentType)
                .Include(sa => sa.UnitOfMeasure)
                .Include(sa => sa.Organization)
                .OrderByDescending(sa => sa.AdjustmentDate)
                .AsNoTracking()
                .ToListAsync();

            var dtoList = new List<StockAdjustmentResponseDto>();
            foreach (var adjustment in adjustments)
            {
                dtoList.Add((await MapStockAdjustmentToResponseDto(adjustment))!);
            }
            return dtoList;
        }

        public async Task<StockAdjustmentResponseDto?> GetStockAdjustmentByIdAsync(Guid adjustmentId, Guid organizationId)
        {
            var adjustment = await _context.StockAdjustments
                .Where(sa => sa.AdjustmentId == adjustmentId && sa.OrganizationId == organizationId)
                .Include(sa => sa.Component).ThenInclude(c => c!.InventoryUnit)
                .Include(sa => sa.Product).ThenInclude(p => p!.ProductUnit)
                .Include(sa => sa.AdjustmentType)
                .Include(sa => sa.UnitOfMeasure)
                .Include(sa => sa.Organization)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await MapStockAdjustmentToResponseDto(adjustment);
        }

        public async Task<StockAdjustmentResponseDto> CreateStockAdjustmentAsync(CreateStockAdjustmentDto createDto, Guid organizationId)
        {
            // 1. Verify Organization exists
            var organizationExists = await _context.Organizations.AnyAsync(o => o.OrganizationId == organizationId);
            if (!organizationExists)
            {
                throw new InvalidOperationException($"Organization with ID '{organizationId}' not found.");
            }

            // 2. Retrieve the actual item (Component or Product)
            Component? component = null;
            Product? product = null;
            Guid currentStockUnitId; // InventoryUnitId for component, ProductUnitId for product
            decimal currentStockQuantity; // CurrentStockQuantity of the component or product

            if (createDto.ComponentId.HasValue)
            {
                component = await _context.Components
                                          .Include(c => c.InventoryUnit)
                                          .FirstOrDefaultAsync(c => c.ComponentId == createDto.ComponentId.Value && c.OrganizationId == organizationId);
                if (component == null)
                {
                    throw new InvalidOperationException($"Component with ID '{createDto.ComponentId.Value}' not found or does not belong to your organization.");
                }
                currentStockUnitId = component.InventoryUnitId;
                currentStockQuantity = component.CurrentStockQuantity;
            }
            else if (createDto.ProductId.HasValue)
            {
                product = await _context.Products
                                        .Include(p => p.ProductUnit)
                                        .FirstOrDefaultAsync(p => p.ProductId == createDto.ProductId.Value && p.OrganizationId == organizationId);
                if (product == null)
                {
                    throw new InvalidOperationException($"Product with ID '{createDto.ProductId.Value}' not found or does not belong to your organization.");
                }
                currentStockUnitId = product.ProductUnitId;
                currentStockQuantity = product.CurrentStockQuantity;
            }
            else
            {
                // This case should be caught by DTO validation, but as a safeguard
                throw new InvalidOperationException("Either Component ID or Product ID must be provided.");
            }


            // 3. Retrieve Adjustment Type
            var adjustmentType = await _context.StockAdjustmentTypes.FindAsync(createDto.AdjustmentTypeId);
            if (adjustmentType == null)
            {
                throw new InvalidOperationException($"Adjustment Type with ID '{createDto.AdjustmentTypeId}' not found.");
            }

            // 4. Retrieve Unit of Measure for the adjustment
            var adjustmentUnit = await _context.UnitsOfMeasures.FindAsync(createDto.UnitOfMeasureId);
            if (adjustmentUnit == null)
            {
                throw new InvalidOperationException($"Unit of Measure with ID '{createDto.UnitOfMeasureId}' not found.");
            }

            // 5. Calculate quantity in the item's (component/product) primary stock unit
            decimal quantityInStockUnit;
            try
            {
                // ใช้ currentStockUnitId ของ Component หรือ Product ในการแปลง
                quantityInStockUnit = await _unitConversionService.GetConversionFactorAsync(
                                                createDto.UnitOfMeasureId,
                                                currentStockUnitId,
                                                organizationId
                                            ) ?? throw new InvalidOperationException("No valid conversion factor found.");

                quantityInStockUnit *= createDto.Quantity; // Apply the quantity from DTO
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Failed to convert quantity to stock unit: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Conversion calculation error: {ex.Message}");
            }

            // Store current stock quantity before adjustment
            decimal quantityBeforeAdjustment = currentStockQuantity;

            // 6. Update Component's or Product's CurrentStockQuantity based on adjustment type
            if (adjustmentType.Effect == "Increase")
            {
                if (component != null) component.CurrentStockQuantity += quantityInStockUnit;
                if (product != null) product.CurrentStockQuantity += quantityInStockUnit;
            }
            else if (adjustmentType.Effect == "Decrease")
            {
                if (component != null)
                {
                    if (component.CurrentStockQuantity < quantityInStockUnit)
                    {
                        throw new InvalidOperationException($"Insufficient stock for '{component.ComponentName}'. Current stock: {component.CurrentStockQuantity} {component.InventoryUnit?.Abbreviation}. Attempted decrease: {quantityInStockUnit} {component.InventoryUnit?.Abbreviation}.");
                    }
                    component.CurrentStockQuantity -= quantityInStockUnit;
                }
                if (product != null)
                {
                    if (product.CurrentStockQuantity < quantityInStockUnit)
                    {
                        throw new InvalidOperationException($"Insufficient stock for '{product.ProductName}'. Current stock: {product.CurrentStockQuantity} {product.ProductUnit?.Abbreviation}. Attempted decrease: {quantityInStockUnit} {product.ProductUnit?.Abbreviation}.");
                    }
                    product.CurrentStockQuantity -= quantityInStockUnit;
                }
            }
            else
            {
                throw new InvalidOperationException($"Unsupported adjustment type effect: '{adjustmentType.Effect}'.");
            }

            // Create new StockAdjustment record
            var stockAdjustment = new StockAdjustment
            {
                AdjustmentId = Guid.NewGuid(),
                OrganizationId = organizationId,
                ComponentId = createDto.ComponentId, // Set ComponentId if exists
                ProductId = createDto.ProductId,     // Set ProductId if exists
                AdjustmentTypeId = createDto.AdjustmentTypeId,
                Quantity = createDto.Quantity,
                UnitOfMeasureId = createDto.UnitOfMeasureId,
                QuantityBeforeAdjustment = quantityBeforeAdjustment,
                QuantityAfterAdjustment = (component != null ? component.CurrentStockQuantity : (product != null ? product.CurrentStockQuantity : 0)), // Stock after this adjustment
                Notes = createDto.Notes,
                AdjustmentDate = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.StockAdjustments.Add(stockAdjustment);
            if (component != null) _context.Components.Update(component); // Mark component as updated
            if (product != null) _context.Products.Update(product); // Mark product as updated
            await _context.SaveChangesAsync();

            return (await MapStockAdjustmentToResponseDto(stockAdjustment))!;
        }

        public async Task<StockAdjustmentResponseDto?> UpdateStockAdjustmentAsync(UpdateStockAdjustmentDto updateDto, Guid organizationId)
        {
            var stockAdjustment = await _context.StockAdjustments
                .Include(sa => sa.Component).ThenInclude(c => c!.InventoryUnit)
                .Include(sa => sa.Product).ThenInclude(p => p!.ProductUnit)
                .Include(sa => sa.AdjustmentType)
                .Include(sa => sa.UnitOfMeasure)
                .FirstOrDefaultAsync(sa => sa.AdjustmentId == updateDto.AdjustmentId && sa.OrganizationId == organizationId);

            if (stockAdjustment == null)
            {
                return null; // Not found or does not belong to the organization
            }

            // Determine which item (Component or Product) this adjustment is for
            Component? affectedComponent = null;
            Product? affectedProduct = null;
            Guid originalItemStockUnitId; // Unit where original stock quantity is tracked

            if (stockAdjustment.ComponentId.HasValue)
            {
                affectedComponent = await _context.Components.Include(c => c.InventoryUnit).FirstOrDefaultAsync(c => c.ComponentId == stockAdjustment.ComponentId.Value && c.OrganizationId == organizationId);
                if (affectedComponent == null) throw new InvalidOperationException("Associated component not found.");
                originalItemStockUnitId = affectedComponent.InventoryUnitId;
            }
            else if (stockAdjustment.ProductId.HasValue)
            {
                affectedProduct = await _context.Products.Include(p => p.ProductUnit).FirstOrDefaultAsync(p => p.ProductId == stockAdjustment.ProductId.Value && p.OrganizationId == organizationId);
                if (affectedProduct == null) throw new InvalidOperationException("Associated product not found.");
                originalItemStockUnitId = affectedProduct.ProductUnitId;
            }
            else
            {
                throw new InvalidOperationException("Stock adjustment is not linked to a valid Component or Product.");
            }

            // Store original quantities and types to revert their effect
            decimal originalQuantity = stockAdjustment.Quantity;
            Guid originalUnitId = stockAdjustment.UnitOfMeasureId;
            string originalEffect = stockAdjustment.AdjustmentType?.Effect ?? "Unknown";

            // Revert the effect of the original adjustment first
            decimal originalQuantityInStockUnit;
            try
            {
                originalQuantityInStockUnit = await _unitConversionService.GetConversionFactorAsync(
                                                    originalUnitId,
                                                    originalItemStockUnitId,
                                                    organizationId
                                                ) ?? throw new InvalidOperationException("No valid conversion factor found for original unit to stock unit.");
                originalQuantityInStockUnit *= originalQuantity;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Failed to revert original quantity due to conversion issue: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Conversion calculation error for original quantity: {ex.Message}");
            }

            // Revert stock based on original effect
            if (originalEffect == "Increase")
            {
                if (affectedComponent != null) affectedComponent.CurrentStockQuantity -= originalQuantityInStockUnit;
                if (affectedProduct != null) affectedProduct.CurrentStockQuantity -= originalQuantityInStockUnit;
            }
            else if (originalEffect == "Decrease")
            {
                if (affectedComponent != null) affectedComponent.CurrentStockQuantity += originalQuantityInStockUnit;
                if (affectedProduct != null) affectedProduct.CurrentStockQuantity += originalQuantityInStockUnit;
            }


            // --- Apply updates from DTO ---
            Guid? newComponentId = updateDto.ComponentId ?? stockAdjustment.ComponentId;
            Guid? newProductId = updateDto.ProductId ?? stockAdjustment.ProductId;
            Guid newAdjustmentTypeId = updateDto.AdjustmentTypeId ?? stockAdjustment.AdjustmentTypeId;
            decimal newQuantity = updateDto.Quantity ?? stockAdjustment.Quantity;
            Guid newUnitOfMeasureId = updateDto.UnitOfMeasureId ?? stockAdjustment.UnitOfMeasureId;
            string? newNotes = updateDto.Notes ?? stockAdjustment.Notes;

            // Validate and fetch the new item (Component or Product) if changed
            if (newComponentId != stockAdjustment.ComponentId || newProductId != stockAdjustment.ProductId)
            {
                if (newComponentId.HasValue)
                {
                    affectedComponent = await _context.Components.Include(c => c.InventoryUnit).FirstOrDefaultAsync(c => c.ComponentId == newComponentId.Value && c.OrganizationId == organizationId);
                    if (affectedComponent == null) throw new InvalidOperationException($"New Component with ID '{newComponentId.Value}' not found or does not belong to your organization.");
                    affectedProduct = null; // Ensure only one is active
                }
                else if (newProductId.HasValue)
                {
                    affectedProduct = await _context.Products.Include(p => p.ProductUnit).FirstOrDefaultAsync(p => p.ProductId == newProductId.Value && p.OrganizationId == organizationId);
                    if (affectedProduct == null) throw new InvalidOperationException($"New Product with ID '{newProductId.Value}' not found or does not belong to your organization.");
                    affectedComponent = null; // Ensure only one is active
                }
                else
                {
                    throw new InvalidOperationException("Updated stock adjustment must be linked to a Component or Product.");
                }
            }
            // If neither ComponentId nor ProductId changed, affectedComponent/affectedProduct are already loaded from original query.

            // Get the stock unit ID of the (potentially new) affected item
            Guid newItemStockUnitId = (affectedComponent != null) ? affectedComponent.InventoryUnitId : (affectedProduct != null ? affectedProduct.ProductUnitId : Guid.Empty);
            if (newItemStockUnitId == Guid.Empty) throw new InvalidOperationException("Could not determine stock unit for the affected item.");


            // Validate new Adjustment Type
            var newAdjustmentType = await _context.StockAdjustmentTypes.FindAsync(newAdjustmentTypeId);
            if (newAdjustmentType == null)
            {
                throw new InvalidOperationException($"New Adjustment Type with ID '{newAdjustmentTypeId}' not found.");
            }

            // Validate new Unit of Measure
            var newUnitOfMeasure = await _context.UnitsOfMeasures.FindAsync(newUnitOfMeasureId);
            if (newUnitOfMeasure == null)
            {
                throw new InvalidOperationException($"New Unit of Measure with ID '{newUnitOfMeasureId}' not found.");
            }

            // Calculate new quantity in item's (component/product) primary stock unit
            decimal newQuantityInStockUnit;
            try
            {
                newQuantityInStockUnit = await _unitConversionService.GetConversionFactorAsync(
                                                newUnitOfMeasureId,
                                                newItemStockUnitId,
                                                organizationId
                                            ) ?? throw new InvalidOperationException("No valid conversion factor found for new unit to stock unit.");
                newQuantityInStockUnit *= newQuantity;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Failed to convert new quantity to stock unit: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Conversion calculation error for new quantity: {ex.Message}");
            }

            // Apply the effect of the updated adjustment
            // Store current stock quantity before new adjustment
            decimal quantityBeforeNewAdjustment = (affectedComponent != null ? affectedComponent.CurrentStockQuantity : (affectedProduct != null ? affectedProduct.CurrentStockQuantity : 0));

            if (newAdjustmentType.Effect == "Increase")
            {
                if (affectedComponent != null) affectedComponent.CurrentStockQuantity += newQuantityInStockUnit;
                if (affectedProduct != null) affectedProduct.CurrentStockQuantity += newQuantityInStockUnit;
            }
            else if (newAdjustmentType.Effect == "Decrease")
            {
                if (affectedComponent != null)
                {
                    if (affectedComponent.CurrentStockQuantity < newQuantityInStockUnit)
                    {
                        throw new InvalidOperationException($"Insufficient stock for updated decrease adjustment for '{affectedComponent.ComponentName}'. Current stock: {affectedComponent.CurrentStockQuantity} {affectedComponent.InventoryUnit?.Abbreviation}. Attempted decrease: {newQuantityInStockUnit} {affectedComponent.InventoryUnit?.Abbreviation}.");
                    }
                    affectedComponent.CurrentStockQuantity -= newQuantityInStockUnit;
                }
                if (affectedProduct != null)
                {
                    if (affectedProduct.CurrentStockQuantity < newQuantityInStockUnit)
                    {
                        throw new InvalidOperationException($"Insufficient stock for updated decrease adjustment for '{affectedProduct.ProductName}'. Current stock: {affectedProduct.CurrentStockQuantity} {affectedProduct.ProductUnit?.Abbreviation}. Attempted decrease: {newQuantityInStockUnit} {affectedProduct.ProductUnit?.Abbreviation}.");
                    }
                    affectedProduct.CurrentStockQuantity -= newQuantityInStockUnit;
                }
            }
            else
            {
                throw new InvalidOperationException($"Unsupported new adjustment type effect: '{newAdjustmentType.Effect}'.");
            }

            // Update StockAdjustment record
            stockAdjustment.ComponentId = newComponentId;
            stockAdjustment.ProductId = newProductId;
            stockAdjustment.AdjustmentTypeId = newAdjustmentTypeId;
            stockAdjustment.Quantity = newQuantity;
            stockAdjustment.UnitOfMeasureId = newUnitOfMeasureId;
            stockAdjustment.Notes = newNotes;
            stockAdjustment.QuantityBeforeAdjustment = quantityBeforeNewAdjustment; // Recalculate based on current state before new adjustment
            stockAdjustment.QuantityAfterAdjustment = (affectedComponent != null ? affectedComponent.CurrentStockQuantity : (affectedProduct != null ? affectedProduct.CurrentStockQuantity : 0)); // Current stock after new adjustment
            stockAdjustment.UpdatedAt = DateTime.UtcNow;

            _context.StockAdjustments.Update(stockAdjustment);
            if (affectedComponent != null) _context.Components.Update(affectedComponent); // Mark component as updated
            if (affectedProduct != null) _context.Products.Update(affectedProduct); // Mark product as updated
            await _context.SaveChangesAsync();

            return (await MapStockAdjustmentToResponseDto(stockAdjustment))!;
        }

        public async Task<bool> DeleteStockAdjustmentAsync(Guid adjustmentId, Guid organizationId)
        {
            var stockAdjustment = await _context.StockAdjustments
                .Include(sa => sa.Component).ThenInclude(c => c!.InventoryUnit) // For component conversion
                .Include(sa => sa.Product).ThenInclude(p => p!.ProductUnit)   // For product conversion
                .Include(sa => sa.AdjustmentType)
                .FirstOrDefaultAsync(sa => sa.AdjustmentId == adjustmentId && sa.OrganizationId == organizationId);

            if (stockAdjustment == null)
            {
                return false; // Not found or does not belong to the organization
            }

            // Determine which item (Component or Product) this adjustment is for
            Component? affectedComponent = null;
            Product? affectedProduct = null;
            Guid originalItemStockUnitId; // Unit where original stock quantity is tracked

            if (stockAdjustment.ComponentId.HasValue)
            {
                affectedComponent = await _context.Components.Include(c => c.InventoryUnit).FirstOrDefaultAsync(c => c.ComponentId == stockAdjustment.ComponentId.Value && c.OrganizationId == organizationId);
                if (affectedComponent == null) throw new InvalidOperationException("Associated component not found.");
                originalItemStockUnitId = affectedComponent.InventoryUnitId;
            }
            else if (stockAdjustment.ProductId.HasValue)
            {
                affectedProduct = await _context.Products.Include(p => p.ProductUnit).FirstOrDefaultAsync(p => p.ProductId == stockAdjustment.ProductId.Value && p.OrganizationId == organizationId);
                if (affectedProduct == null) throw new InvalidOperationException("Associated product not found.");
                originalItemStockUnitId = affectedProduct.ProductUnitId;
            }
            else
            {
                throw new InvalidOperationException("Stock adjustment is not linked to a valid Component or Product.");
            }

            if (stockAdjustment.AdjustmentType == null)
            {
                throw new InvalidOperationException("Associated adjustment type not found for this stock adjustment.");
            }

            // Revert the effect of the adjustment on item's current stock quantity
            decimal quantityToRevertInStockUnit;
            try
            {
                quantityToRevertInStockUnit = await _unitConversionService.GetConversionFactorAsync(
                                                    stockAdjustment.UnitOfMeasureId,
                                                    originalItemStockUnitId,
                                                    organizationId
                                                ) ?? throw new InvalidOperationException("No valid conversion factor found for reverting unit.");
                quantityToRevertInStockUnit *= stockAdjustment.Quantity;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Failed to revert stock due to conversion issue: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Conversion calculation error for reverting quantity: {ex.Message}");
            }


            if (stockAdjustment.AdjustmentType.Effect == "Increase")
            {
                // If original effect was Increase, to revert, we decrease
                if (affectedComponent != null) stockAdjustment.Component!.CurrentStockQuantity -= quantityToRevertInStockUnit;
                if (affectedProduct != null) stockAdjustment.Product!.CurrentStockQuantity -= quantityToRevertInStockUnit;
            }
            else if (stockAdjustment.AdjustmentType.Effect == "Decrease")
            {
                // If original effect was Decrease, to revert, we increase
                if (affectedComponent != null) stockAdjustment.Component!.CurrentStockQuantity += quantityToRevertInStockUnit;
                if (affectedProduct != null) stockAdjustment.Product!.CurrentStockQuantity += quantityToRevertInStockUnit;
            }
            else
            {
                throw new InvalidOperationException($"Unsupported adjustment type effect during deletion: '{stockAdjustment.AdjustmentType.Effect}'.");
            }

            _context.StockAdjustments.Remove(stockAdjustment);
            if (affectedComponent != null) _context.Components.Update(affectedComponent); // Mark component as updated
            if (affectedProduct != null) _context.Products.Update(affectedProduct); // Mark product as updated
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<StockAdjustmentType>> GetAllStockAdjustmentTypesAsync()
        {
            return await _context.StockAdjustmentTypes.AsNoTracking().ToListAsync();
        }

        // --- เพิ่ม/ปรับปรุง GetCurrentStockBalancesAsync เพื่อรองรับทั้ง Component และ Product ---
        public async Task<IEnumerable<CurrentStockBalanceDto>> GetCurrentStockBalancesAsync(Guid organizationId)
        {
            var componentBalances = await _context.Components
                                      .Where(c => c.OrganizationId == organizationId)
                                      .Include(c => c.InventoryUnit)
                                      .Select(c => new CurrentStockBalanceDto
                                      {
                                          EntityId = c.ComponentId,
                                          EntityCode = c.ComponentCode,
                                          EntityName = c.ComponentName,
                                          CurrentStockQuantity = c.CurrentStockQuantity,
                                          UnitId = c.InventoryUnitId,
                                          UnitName = c.InventoryUnit != null ? c.InventoryUnit.UnitName : "N/A",
                                          UnitAbbreviation = c.InventoryUnit != null ? c.InventoryUnit.Abbreviation : "N/A",
                                          EntityType = "Component" // เพิ่มประเภท
                                      })
                                      .OrderBy(dto => dto.EntityName)
                                      .AsNoTracking()
                                      .ToListAsync();

            var productBalances = await _context.Products
                                      .Where(p => p.OrganizationId == organizationId)
                                      .Include(p => p.ProductUnit)
                                      .Select(p => new CurrentStockBalanceDto
                                      {
                                          EntityId = p.ProductId,
                                          EntityCode = p.ProductCode,
                                          EntityName = p.ProductName,
                                          CurrentStockQuantity = p.CurrentStockQuantity,
                                          UnitId = p.ProductUnitId,
                                          UnitName = p.ProductUnit != null ? p.ProductUnit.UnitName : "N/A",
                                          UnitAbbreviation = p.ProductUnit != null ? p.ProductUnit.Abbreviation : "N/A",
                                          EntityType = "Product" // เพิ่มประเภท
                                      })
                                      .OrderBy(dto => dto.EntityName)
                                      .AsNoTracking()
                                      .ToListAsync();

            return componentBalances.Concat(productBalances).ToList(); // รวมรายการทั้งสอง
        }
        // --- สิ้นสุดการปรับปรุง ---
    }
}