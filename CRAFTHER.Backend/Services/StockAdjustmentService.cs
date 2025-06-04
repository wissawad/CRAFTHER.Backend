// Path: CRAFTHER.Backend/Services/StockAdjustmentService.cs
using CRAFTHER.Backend.Data; // For ApplicationDbContext
using CRAFTHER.Backend.DTOs;
using CRAFTHER.Backend.DTOs.StockAdjustments;
using CRAFTHER.Backend.Models; // For StockAdjustment, Component, UnitOfMeasure, etc.
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
        private readonly IUnitConversionService _unitConversionService; // Inject UnitConversionService

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
            if (stockAdjustment.Component == null)
            {
                await _context.Entry(stockAdjustment).Reference(sa => sa.Component).LoadAsync();
            }
            if (stockAdjustment.AdjustmentType == null)
            {
                await _context.Entry(stockAdjustment).Reference(sa => sa.AdjustmentType).LoadAsync();
            }
            if (stockAdjustment.UnitOfMeasure == null)
            {
                await _context.Entry(stockAdjustment).Reference(sa => sa.UnitOfMeasure).LoadAsync();
            }

            return new StockAdjustmentResponseDto
            {
                AdjustmentId = stockAdjustment.AdjustmentId,
                OrganizationId = stockAdjustment.OrganizationId,
                OrganizationName = stockAdjustment.Organization?.OrganizationName ?? "N/A",
                ComponentId = stockAdjustment.ComponentId,
                ComponentCode = stockAdjustment.Component?.ComponentCode ?? "N/A",
                ComponentName = stockAdjustment.Component?.ComponentName ?? "N/A",
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
        }

        public async Task<IEnumerable<StockAdjustmentResponseDto>> GetAllStockAdjustmentsAsync(Guid organizationId)
        {
            var adjustments = await _context.StockAdjustments
                .Where(sa => sa.OrganizationId == organizationId)
                .Include(sa => sa.Component)
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
                .Include(sa => sa.Component)
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

            // 2. Retrieve Component and related units
            var component = await _context.Components
                                          .Include(c => c.InventoryUnit) // Load InventoryUnit for conversion
                                          .Include(c => c.PurchaseUnit) // Load PurchaseUnit for component-specific conversion
                                          .FirstOrDefaultAsync(c => c.ComponentId == createDto.ComponentId && c.OrganizationId == organizationId);
            if (component == null)
            {
                throw new InvalidOperationException($"Component with ID '{createDto.ComponentId}' not found or does not belong to your organization.");
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

            // 5. Calculate quantity in the component's InventoryUnit
            decimal quantityInInventoryUnit;
            try
            {
                quantityInInventoryUnit = await _unitConversionService.GetConversionFactorAsync(
                                                createDto.UnitOfMeasureId,
                                                component.InventoryUnitId,
                                                organizationId
                                            ) ?? throw new InvalidOperationException("No valid conversion factor found.");

                quantityInInventoryUnit *= createDto.Quantity; // Apply the quantity from DTO
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Failed to convert quantity to inventory unit: {ex.Message}");
            }
            catch (ArgumentException ex) // Catch ArgumentException from GetConversionFactorAsync
            {
                throw new ArgumentException($"Conversion calculation error: {ex.Message}");
            }

            // Store current stock quantity before adjustment
            decimal quantityBeforeAdjustment = component.CurrentStockQuantity;

            // 6. Update Component's CurrentStockQuantity based on adjustment type
            if (adjustmentType.Effect == "Increase")
            {
                component.CurrentStockQuantity += quantityInInventoryUnit;
            }
            else if (adjustmentType.Effect == "Decrease")
            {
                if (component.CurrentStockQuantity < quantityInInventoryUnit)
                {
                    throw new InvalidOperationException($"Insufficient stock for '{component.ComponentName}'. Current stock: {component.CurrentStockQuantity} {component.InventoryUnit?.Abbreviation}. Attempted decrease: {quantityInInventoryUnit} {component.InventoryUnit?.Abbreviation}.");
                }
                component.CurrentStockQuantity -= quantityInInventoryUnit;
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
                ComponentId = createDto.ComponentId,
                AdjustmentTypeId = createDto.AdjustmentTypeId,
                Quantity = createDto.Quantity,
                UnitOfMeasureId = createDto.UnitOfMeasureId,
                QuantityBeforeAdjustment = quantityBeforeAdjustment,
                QuantityAfterAdjustment = component.CurrentStockQuantity, // Stock after this adjustment
                Notes = createDto.Notes,
                AdjustmentDate = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.StockAdjustments.Add(stockAdjustment);
            _context.Components.Update(component); // Mark component as updated
            await _context.SaveChangesAsync();

            return (await MapStockAdjustmentToResponseDto(stockAdjustment))!;
        }

        public async Task<StockAdjustmentResponseDto?> UpdateStockAdjustmentAsync(UpdateStockAdjustmentDto updateDto, Guid organizationId)
        {
            var stockAdjustment = await _context.StockAdjustments
                .Include(sa => sa.Component)
                    .ThenInclude(c => c!.InventoryUnit)
                .Include(sa => sa.Component)
                    .ThenInclude(c => c!.PurchaseUnit) // Include for conversion helper
                .Include(sa => sa.AdjustmentType)
                .Include(sa => sa.UnitOfMeasure)
                .FirstOrDefaultAsync(sa => sa.AdjustmentId == updateDto.AdjustmentId && sa.OrganizationId == organizationId);

            if (stockAdjustment == null)
            {
                return null; // Not found or does not belong to the organization
            }

            // Store original quantities and types to revert their effect
            decimal originalQuantity = stockAdjustment.Quantity;
            Guid originalUnitId = stockAdjustment.UnitOfMeasureId;
            string originalEffect = stockAdjustment.AdjustmentType?.Effect ?? "Unknown";
            Guid originalComponentId = stockAdjustment.ComponentId;

            // Get the component (current state)
            var component = await _context.Components
                                          .Include(c => c.InventoryUnit)
                                          .Include(c => c.PurchaseUnit)
                                          .FirstOrDefaultAsync(c => c.ComponentId == originalComponentId && c.OrganizationId == organizationId);
            if (component == null)
            {
                throw new InvalidOperationException($"Component with ID '{originalComponentId}' associated with this adjustment not found or does not belong to your organization.");
            }

            // *** Important: Revert the effect of the original adjustment first ***
            decimal originalQuantityInInventoryUnit;
            try
            {
                originalQuantityInInventoryUnit = await _unitConversionService.GetConversionFactorAsync(
                                                    originalUnitId,
                                                    component.InventoryUnitId,
                                                    organizationId
                                                ) ?? throw new InvalidOperationException("No valid conversion factor found for original unit.");
                originalQuantityInInventoryUnit *= originalQuantity;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Failed to revert original quantity due to conversion issue: {ex.Message}");
            }

            // Store current stock quantity before adjustment
            decimal quantityBeforeAdjustment = component.CurrentStockQuantity;

            if (originalEffect == "Increase")
            {
                component.CurrentStockQuantity -= originalQuantityInInventoryUnit;
            }
            else if (originalEffect == "Decrease")
            {
                component.CurrentStockQuantity += originalQuantityInInventoryUnit;
            }

            // --- Apply updates from DTO ---
            Guid newComponentId = updateDto.ComponentId ?? stockAdjustment.ComponentId;
            Guid newAdjustmentTypeId = updateDto.AdjustmentTypeId ?? stockAdjustment.AdjustmentTypeId;
            decimal newQuantity = updateDto.Quantity ?? stockAdjustment.Quantity;
            Guid newUnitOfMeasureId = updateDto.UnitOfMeasureId ?? stockAdjustment.UnitOfMeasureId;
            string? newNotes = updateDto.Notes ?? stockAdjustment.Notes;

            // Validate new Component if changed
            if (newComponentId != stockAdjustment.ComponentId)
            {
                // If component ID changes, fetch the new component
                var newComponent = await _context.Components
                                                 .Include(c => c.InventoryUnit)
                                                 .Include(c => c.PurchaseUnit)
                                                 .FirstOrDefaultAsync(c => c.ComponentId == newComponentId && c.OrganizationId == organizationId);
                if (newComponent == null)
                {
                    throw new InvalidOperationException($"New Component with ID '{newComponentId}' not found or does not belong to your organization.");
                }
                component = newComponent; // Switch to the new component
                stockAdjustment.ComponentId = newComponentId;
            }

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

            // Calculate new quantity in component's InventoryUnit
            decimal newQuantityInInventoryUnit;
            try
            {
                newQuantityInInventoryUnit = await _unitConversionService.GetConversionFactorAsync(
                                                newUnitOfMeasureId,
                                                component.InventoryUnitId,
                                                organizationId
                                            ) ?? throw new InvalidOperationException("No valid conversion factor found for new unit.");
                newQuantityInInventoryUnit *= newQuantity;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Failed to convert new quantity to inventory unit: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Conversion calculation error for new quantity: {ex.Message}");
            }

            // Apply the effect of the updated adjustment
            if (newAdjustmentType.Effect == "Increase")
            {
                component.CurrentStockQuantity += newQuantityInInventoryUnit;
            }
            else if (newAdjustmentType.Effect == "Decrease")
            {
                if (component.CurrentStockQuantity < newQuantityInInventoryUnit)
                {
                    throw new InvalidOperationException($"Insufficient stock for updated decrease adjustment for '{component.ComponentName}'. Current stock: {component.CurrentStockQuantity} {component.InventoryUnit?.Abbreviation}. Attempted decrease: {newQuantityInInventoryUnit} {component.InventoryUnit?.Abbreviation}.");
                }
                component.CurrentStockQuantity -= newQuantityInInventoryUnit;
            }
            else
            {
                throw new InvalidOperationException($"Unsupported new adjustment type effect: '{newAdjustmentType.Effect}'.");
            }

            // Update StockAdjustment record
            stockAdjustment.AdjustmentTypeId = newAdjustmentTypeId;
            stockAdjustment.Quantity = newQuantity;
            stockAdjustment.UnitOfMeasureId = newUnitOfMeasureId;
            stockAdjustment.Notes = newNotes;
            stockAdjustment.QuantityBeforeAdjustment = quantityBeforeAdjustment; // Recalculate based on current state before new adjustment
            stockAdjustment.QuantityAfterAdjustment = component.CurrentStockQuantity; // Current stock after new adjustment
            stockAdjustment.UpdatedAt = DateTime.UtcNow;

            _context.StockAdjustments.Update(stockAdjustment);
            _context.Components.Update(component); // Mark component as updated
            await _context.SaveChangesAsync();

            return (await MapStockAdjustmentToResponseDto(stockAdjustment))!;
        }

        public async Task<bool> DeleteStockAdjustmentAsync(Guid adjustmentId, Guid organizationId)
        {
            var stockAdjustment = await _context.StockAdjustments
                .Include(sa => sa.Component)
                    .ThenInclude(c => c!.InventoryUnit) // For conversion
                .Include(sa => sa.Component)
                    .ThenInclude(c => c!.PurchaseUnit) // For conversion
                .Include(sa => sa.AdjustmentType)
                .FirstOrDefaultAsync(sa => sa.AdjustmentId == adjustmentId && sa.OrganizationId == organizationId);

            if (stockAdjustment == null)
            {
                return false; // Not found or does not belong to the organization
            }

            if (stockAdjustment.Component == null || stockAdjustment.AdjustmentType == null)
            {
                // This scenario should ideally not happen if data integrity is maintained
                throw new InvalidOperationException("Associated component or adjustment type not found for this stock adjustment.");
            }

            // *** Revert the effect of the adjustment on component's current stock quantity ***
            decimal quantityToRevertInInventoryUnit;
            try
            {
                quantityToRevertInInventoryUnit = await _unitConversionService.GetConversionFactorAsync(
                                                    stockAdjustment.UnitOfMeasureId,
                                                    stockAdjustment.Component.InventoryUnitId,
                                                    organizationId
                                                ) ?? throw new InvalidOperationException("No valid conversion factor found for reverting unit.");
                quantityToRevertInInventoryUnit *= stockAdjustment.Quantity;
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
                stockAdjustment.Component.CurrentStockQuantity -= quantityToRevertInInventoryUnit;
            }
            else if (stockAdjustment.AdjustmentType.Effect == "Decrease")
            {
                // If original effect was Decrease, to revert, we increase
                stockAdjustment.Component.CurrentStockQuantity += quantityToRevertInInventoryUnit;
            }
            else
            {
                throw new InvalidOperationException($"Unsupported adjustment type effect during deletion: '{stockAdjustment.AdjustmentType.Effect}'.");
            }

            _context.StockAdjustments.Remove(stockAdjustment);
            _context.Components.Update(stockAdjustment.Component); // Mark component as updated
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<StockAdjustmentType>> GetAllStockAdjustmentTypesAsync()
        {
            return await _context.StockAdjustmentTypes.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<CurrentStockBalanceDto>> GetCurrentStockBalancesAsync(Guid organizationId)
        {
            var stockBalances = await _context.Components
                                      .Where(c => c.OrganizationId == organizationId)
                                      .Include(c => c.InventoryUnit) // Include InventoryUnit to get its Name and Abbreviation
                                      .Select(c => new CurrentStockBalanceDto
                                      {
                                          EntityId = c.ComponentId,
                                          EntityCode = c.ComponentCode,
                                          EntityName = c.ComponentName,
                                          CurrentStockQuantity = c.CurrentStockQuantity,
                                          UnitId = c.InventoryUnitId,
                                          UnitName = c.InventoryUnit != null ? c.InventoryUnit.UnitName : "N/A",
                                          UnitAbbreviation = c.InventoryUnit != null ? c.InventoryUnit.Abbreviation : "N/A"
                                      })
                                      .OrderBy(dto => dto.EntityName)
                                      .AsNoTracking()
                                      .ToListAsync();

            return stockBalances;
        }
    }
}