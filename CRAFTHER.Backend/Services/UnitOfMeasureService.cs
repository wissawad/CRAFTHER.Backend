using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.DTOs.UnitOfMeasures;
using CRAFTHER.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public class UnitOfMeasureService : IUnitOfMeasureService
    {
        private readonly ApplicationDbContext _context;

        public UnitOfMeasureService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper method to map UnitOfMeasure Model to UnitOfMeasureResponseDto
        private UnitOfMeasureResponseDto MapUnitOfMeasureToResponseDto(UnitOfMeasure unitOfMeasure)
        {
            return new UnitOfMeasureResponseDto
            {
                UnitId = unitOfMeasure.UnitId,
                UnitName = unitOfMeasure.UnitName,
                Abbreviation = unitOfMeasure.Abbreviation,
                IsBaseUnit = unitOfMeasure.IsBaseUnit,
                ConversionFactorToBaseUnit = unitOfMeasure.ConversionFactorToBaseUnit,
                UnitGroupId = unitOfMeasure.UnitGroupId,
                UnitGroupName = unitOfMeasure.UnitGroup?.UnitGroupName ?? "N/A", // Fetch group name
                UnitGroupDescription = unitOfMeasure.UnitGroup?.Description, // Fetch group description
                CreatedAt = unitOfMeasure.CreatedAt,
                UpdatedAt = unitOfMeasure.UpdatedAt
            };
        }

        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetAllUnitsOfMeasureAsync()
        {
            var units = await _context.UnitsOfMeasures
                .Include(u => u.UnitGroup) // Include UnitGroup for response DTO
                .OrderBy(u => u.UnitName)
                .AsNoTracking()
                .ToListAsync();

            return units.Select(MapUnitOfMeasureToResponseDto).ToList();
        }

        public async Task<UnitOfMeasureResponseDto?> GetUnitOfMeasureByIdAsync(Guid unitId)
        {
            var unit = await _context.UnitsOfMeasures
                .Include(u => u.UnitGroup) // Include UnitGroup for response DTO
                .Where(u => u.UnitId == unitId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return unit == null ? null : MapUnitOfMeasureToResponseDto(unit);
        }

        public async Task<IEnumerable<UnitOfMeasureResponseDto>> GetUnitsOfMeasureByGroupIdAsync(Guid unitGroupId)
        {
            var units = await _context.UnitsOfMeasures
                .Include(u => u.UnitGroup)
                .Where(u => u.UnitGroupId == unitGroupId)
                .OrderBy(u => u.UnitName)
                .AsNoTracking()
                .ToListAsync();

            return units.Select(MapUnitOfMeasureToResponseDto).ToList();
        }


        public async Task<UnitOfMeasureResponseDto> CreateUnitOfMeasureAsync(CreateUnitOfMeasureDto createUnitOfMeasureDto)
        {
            // 1. Verify UnitGroup exists
            var unitGroupExists = await _context.UnitGroups
                .AnyAsync(ug => ug.UnitGroupId == createUnitOfMeasureDto.UnitGroupId);
            if (!unitGroupExists)
            {
                throw new InvalidOperationException($"Unit Group with ID '{createUnitOfMeasureDto.UnitGroupId}' not found.");
            }

            // 2. Check for duplicate UnitName or Abbreviation within the same UnitGroup
            var duplicateExists = await _context.UnitsOfMeasures
                .AnyAsync(u => (u.UnitName == createUnitOfMeasureDto.UnitName || u.Abbreviation == createUnitOfMeasureDto.Abbreviation) &&
                               u.UnitGroupId == createUnitOfMeasureDto.UnitGroupId);
            if (duplicateExists)
            {
                throw new InvalidOperationException($"A Unit of Measure with the same name or abbreviation already exists in this Unit Group.");
            }

            // 3. If IsBaseUnit is true, ensure no other base unit exists for this group
            if (createUnitOfMeasureDto.IsBaseUnit)
            {
                var existingBaseUnit = await _context.UnitsOfMeasures
                    .AnyAsync(u => u.UnitGroupId == createUnitOfMeasureDto.UnitGroupId && u.IsBaseUnit);
                if (existingBaseUnit)
                {
                    throw new InvalidOperationException($"A base unit already exists for Unit Group '{createUnitOfMeasureDto.UnitGroupId}'. Only one base unit is allowed per group.");
                }
            }

            var unitOfMeasure = new UnitOfMeasure
            {
                UnitId = Guid.NewGuid(),
                UnitName = createUnitOfMeasureDto.UnitName,
                Abbreviation = createUnitOfMeasureDto.Abbreviation,
                IsBaseUnit = createUnitOfMeasureDto.IsBaseUnit,
                ConversionFactorToBaseUnit = createUnitOfMeasureDto.ConversionFactorToBaseUnit,
                UnitGroupId = createUnitOfMeasureDto.UnitGroupId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.UnitsOfMeasures.Add(unitOfMeasure);
            await _context.SaveChangesAsync();

            // Reload with UnitGroup to get the name for the response DTO
            await _context.Entry(unitOfMeasure).Reference(u => u.UnitGroup).LoadAsync();

            return MapUnitOfMeasureToResponseDto(unitOfMeasure);
        }

        public async Task<UnitOfMeasureResponseDto?> UpdateUnitOfMeasureAsync(UpdateUnitOfMeasureDto updateUnitOfMeasureDto)
        {
            var unitOfMeasure = await _context.UnitsOfMeasures
                .Where(u => u.UnitId == updateUnitOfMeasureDto.UnitId)
                .FirstOrDefaultAsync();

            if (unitOfMeasure == null)
            {
                return null; // Unit Of Measure not found
            }

            // If UnitGroupId is being changed, verify new UnitGroup exists
            if (updateUnitOfMeasureDto.UnitGroupId.HasValue &&
                updateUnitOfMeasureDto.UnitGroupId.Value != unitOfMeasure.UnitGroupId)
            {
                var newUnitGroupExists = await _context.UnitGroups
                    .AnyAsync(ug => ug.UnitGroupId == updateUnitOfMeasureDto.UnitGroupId.Value);
                if (!newUnitGroupExists)
                {
                    throw new InvalidOperationException($"New Unit Group with ID '{updateUnitOfMeasureDto.UnitGroupId.Value}' not found.");
                }
            }

            // Check for duplicate name or abbreviation within the (possibly new) UnitGroup
            // Only perform this check if UnitName or Abbreviation is being updated or UnitGroupId is changing
            if ((!string.IsNullOrEmpty(updateUnitOfMeasureDto.UnitName) && updateUnitOfMeasureDto.UnitName != unitOfMeasure.UnitName) ||
                (!string.IsNullOrEmpty(updateUnitOfMeasureDto.Abbreviation) && updateUnitOfMeasureDto.Abbreviation != unitOfMeasure.Abbreviation) ||
                (updateUnitOfMeasureDto.UnitGroupId.HasValue && updateUnitOfMeasureDto.UnitGroupId.Value != unitOfMeasure.UnitGroupId))
            {
                Guid targetUnitGroupId = updateUnitOfMeasureDto.UnitGroupId ?? unitOfMeasure.UnitGroupId;
                string targetUnitName = updateUnitOfMeasureDto.UnitName ?? unitOfMeasure.UnitName;
                string targetAbbreviation = updateUnitOfMeasureDto.Abbreviation ?? unitOfMeasure.Abbreviation;

                var duplicateExists = await _context.UnitsOfMeasures
                    .AnyAsync(u => (u.UnitName == targetUnitName || u.Abbreviation == targetAbbreviation) &&
                                   u.UnitGroupId == targetUnitGroupId &&
                                   u.UnitId != updateUnitOfMeasureDto.UnitId);
                if (duplicateExists)
                {
                    throw new InvalidOperationException($"A Unit of Measure with the same name or abbreviation already exists in the target Unit Group.");
                }
            }

            // If IsBaseUnit is changed to true, ensure no other base unit exists for this group
            if (updateUnitOfMeasureDto.IsBaseUnit.HasValue && updateUnitOfMeasureDto.IsBaseUnit.Value)
            {
                Guid targetUnitGroupId = updateUnitOfMeasureDto.UnitGroupId ?? unitOfMeasure.UnitGroupId;
                var existingBaseUnit = await _context.UnitsOfMeasures
                    .AnyAsync(u => u.UnitGroupId == targetUnitGroupId && u.IsBaseUnit && u.UnitId != unitOfMeasure.UnitId);
                if (existingBaseUnit)
                {
                    throw new InvalidOperationException($"A base unit already exists for Unit Group '{targetUnitGroupId}'. Only one base unit is allowed per group.");
                }
            }

            // Update properties
            if (updateUnitOfMeasureDto.UnitName != null) unitOfMeasure.UnitName = updateUnitOfMeasureDto.UnitName;
            if (updateUnitOfMeasureDto.Abbreviation != null) unitOfMeasure.Abbreviation = updateUnitOfMeasureDto.Abbreviation;
            if (updateUnitOfMeasureDto.IsBaseUnit.HasValue) unitOfMeasure.IsBaseUnit = updateUnitOfMeasureDto.IsBaseUnit.Value;
            if (updateUnitOfMeasureDto.ConversionFactorToBaseUnit.HasValue) unitOfMeasure.ConversionFactorToBaseUnit = updateUnitOfMeasureDto.ConversionFactorToBaseUnit.Value;
            if (updateUnitOfMeasureDto.UnitGroupId.HasValue) unitOfMeasure.UnitGroupId = updateUnitOfMeasureDto.UnitGroupId.Value;

            unitOfMeasure.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Reload with UnitGroup to get the name for the response DTO if it wasn't already loaded or changed
            await _context.Entry(unitOfMeasure).Reference(u => u.UnitGroup).LoadAsync();

            return MapUnitOfMeasureToResponseDto(unitOfMeasure);
        }

        public async Task<bool> DeleteUnitOfMeasureAsync(Guid unitId)
        {
            var unitOfMeasure = await _context.UnitsOfMeasures
                .Where(u => u.UnitId == unitId)
                // Need to check for usages in other models that reference UnitOfMeasure
                // Example: Component.PurchaseUnit, Component.InventoryUnit, Product.ProductUnit, BOMItem.UsageUnit, UnitConversion
                .FirstOrDefaultAsync();

            if (unitOfMeasure == null)
            {
                return false; // Unit Of Measure not found
            }

            // Check for dependencies in other tables (e.g., Component, Product, BOMItem, UnitConversion)
            // If any of these exist, prevent deletion.
            // This is a critical part to prevent referential integrity violations.
            var isUsedInComponents = await _context.Components.AnyAsync(c => c.PurchaseUnitId == unitId || c.InventoryUnitId == unitId);
            var isUsedInProducts = await _context.Products.AnyAsync(p => p.ProductUnitId == unitId);
            var isUsedInBOMItems = await _context.BOMItems.AnyAsync(b => b.UsageUnitId == unitId);
            var isUsedInUnitConversions = await _context.UnitConversions.AnyAsync(uc => uc.FromUnitId == unitId || uc.ToUnitId == unitId);
            var isUsedInStockAdjustments = await _context.StockAdjustments.AnyAsync(sa => sa.UnitOfMeasureId == unitId); // Assuming StockAdjustment also has UnitOfMeasureId

            if (isUsedInComponents || isUsedInProducts || isUsedInBOMItems || isUsedInUnitConversions || isUsedInStockAdjustments)
            {
                throw new InvalidOperationException("Cannot delete Unit of Measure as it is currently in use by other entities (e.g., Components, Products, BOM Items, Unit Conversions, Stock Adjustments).");
            }


            _context.UnitsOfMeasures.Remove(unitOfMeasure);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}