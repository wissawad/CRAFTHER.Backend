// Path: CRAFTHER.Backend/Services/UnitConversionService.cs
using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.DTOs.UnitConversions;
using CRAFTHER.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public class UnitConversionService : IUnitConversionService
    {
        private readonly ApplicationDbContext _context;

        public UnitConversionService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper method to map UnitConversion Model to UnitConversionResponseDto
        private async Task<UnitConversionResponseDto?> MapUnitConversionToResponseDto(UnitConversion? unitConversion)
        {
            if (unitConversion == null) return null;

            // Ensure related entities are loaded for the DTO
            // ถ้าใช้ AsNoTracking() ใน Query ต้อง Load Navigation Properties แบบ Explicit
            // หรือใช้ .Include() ใน Query ต้นทาง
            if (unitConversion.FromUnit == null)
            {
                await _context.Entry(unitConversion).Reference(uc => uc.FromUnit).LoadAsync();
            }
            if (unitConversion.ToUnit == null)
            {
                await _context.Entry(unitConversion).Reference(uc => uc.ToUnit).LoadAsync();
            }
            if (unitConversion.Organization == null)
            {
                await _context.Entry(unitConversion).Reference(uc => uc.Organization).LoadAsync();
            }

            return new UnitConversionResponseDto
            {
                UnitConversionId = unitConversion.ConversionId,
                OrganizationId = unitConversion.OrganizationId,
                OrganizationName = unitConversion.Organization?.OrganizationName ?? "N/A",
                FromUnitId = unitConversion.FromUnitId,
                FromUnitName = unitConversion.FromUnit?.UnitName ?? "N/A",
                FromUnitAbbreviation = unitConversion.FromUnit?.Abbreviation ?? "N/A",
                ToUnitId = unitConversion.ToUnitId,
                ToUnitName = unitConversion.ToUnit?.UnitName ?? "N/A",
                ToUnitAbbreviation = unitConversion.ToUnit?.Abbreviation ?? "N/A",
                ConversionFactor = unitConversion.ConversionFactor,
                Remarks = unitConversion.Remarks,
                CreatedAt = unitConversion.CreatedAt,
                UpdatedAt = unitConversion.UpdatedAt
            };
        }

        public async Task<IEnumerable<UnitConversionResponseDto>> GetAllUnitConversionsAsync(Guid organizationId)
        {
            var conversions = await _context.UnitConversions
                .Where(uc => uc.OrganizationId == organizationId)
                .Include(uc => uc.FromUnit)
                .Include(uc => uc.ToUnit)
                .Include(uc => uc.Organization)
                .AsNoTracking()
                .ToListAsync();

            var dtoList = new List<UnitConversionResponseDto>();
            foreach (var conversion in conversions)
            {
                dtoList.Add((await MapUnitConversionToResponseDto(conversion))!);
            }
            return dtoList;
        }

        public async Task<UnitConversionResponseDto?> GetUnitConversionByIdAsync(Guid unitConversionId, Guid organizationId)
        {
            var conversion = await _context.UnitConversions
                .Where(uc => uc.ConversionId == unitConversionId && uc.OrganizationId == organizationId)
                .Include(uc => uc.FromUnit)
                .Include(uc => uc.ToUnit)
                .Include(uc => uc.Organization)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await MapUnitConversionToResponseDto(conversion);
        }

        public async Task<UnitConversionResponseDto> CreateUnitConversionAsync(CreateUnitConversionDto createUnitConversionDto, Guid organizationId)
        {
            // 1. Verify Organization exists
            var organizationExists = await _context.Organizations.AnyAsync(o => o.OrganizationId == organizationId);
            if (!organizationExists)
            {
                throw new InvalidOperationException($"Organization with ID '{organizationId}' not found.");
            }

            // 2. Verify FromUnit and ToUnit exist (global units)
            var fromUnit = await _context.UnitsOfMeasures.FindAsync(createUnitConversionDto.FromUnitId);
            if (fromUnit == null)
            {
                throw new InvalidOperationException($"From Unit with ID '{createUnitConversionDto.FromUnitId}' not found.");
            }
            var toUnit = await _context.UnitsOfMeasures.FindAsync(createUnitConversionDto.ToUnitId);
            if (toUnit == null)
            {
                throw new InvalidOperationException($"To Unit with ID '{createUnitConversionDto.ToUnitId}' not found.");
            }

            // 3. Prevent conversion to/from the same unit
            if (createUnitConversionDto.FromUnitId == createUnitConversionDto.ToUnitId)
            {
                throw new InvalidOperationException("Cannot create a conversion from a unit to itself.");
            }

            // 4. Check for duplicate conversion (FromUnitId, ToUnitId) for the same organization
            // Ensure unique conversion rule in both directions (A->B and B->A should not coexist)
            var duplicateExists = await _context.UnitConversions
                .AnyAsync(uc => uc.OrganizationId == organizationId &&
                                ((uc.FromUnitId == createUnitConversionDto.FromUnitId && uc.ToUnitId == createUnitConversionDto.ToUnitId) ||
                                 (uc.FromUnitId == createUnitConversionDto.ToUnitId && uc.ToUnitId == createUnitConversionDto.FromUnitId)));
            if (duplicateExists)
            {
                throw new InvalidOperationException("A conversion rule between these two units already exists for this organization (or its reverse).");
            }

            // 5. Ensure ConversionFactor is positive
            if (createUnitConversionDto.ConversionFactor <= 0)
            {
                throw new ArgumentException("Conversion Factor must be greater than zero.");
            }

            var unitConversion = new UnitConversion
            {
                ConversionId = Guid.NewGuid(),
                OrganizationId = organizationId, // Set OrganizationId from authenticated user
                FromUnitId = createUnitConversionDto.FromUnitId,
                ToUnitId = createUnitConversionDto.ToUnitId,
                ConversionFactor = createUnitConversionDto.ConversionFactor,
                Remarks = createUnitConversionDto.Remarks,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.UnitConversions.Add(unitConversion);
            await _context.SaveChangesAsync();

            return (await MapUnitConversionToResponseDto(unitConversion))!;
        }

        public async Task<UnitConversionResponseDto?> UpdateUnitConversionAsync(UpdateUnitConversionDto updateUnitConversionDto, Guid organizationId)
        {
            var unitConversion = await _context.UnitConversions
                .Where(uc => uc.ConversionId == updateUnitConversionDto.UnitConversionId && uc.OrganizationId == organizationId)
                .FirstOrDefaultAsync();

            if (unitConversion == null)
            {
                return null; // Unit Conversion not found or does not belong to the specified organization
            }

            // Update FromUnitId if provided and different
            if (updateUnitConversionDto.FromUnitId.HasValue && updateUnitConversionDto.FromUnitId.Value != unitConversion.FromUnitId)
            {
                var newFromUnitExists = await _context.UnitsOfMeasures.AnyAsync(u => u.UnitId == updateUnitConversionDto.FromUnitId.Value);
                if (!newFromUnitExists)
                {
                    throw new InvalidOperationException($"From Unit with ID '{updateUnitConversionDto.FromUnitId.Value}' not found.");
                }
                unitConversion.FromUnitId = updateUnitConversionDto.FromUnitId.Value;
            }

            // Update ToUnitId if provided and different
            if (updateUnitConversionDto.ToUnitId.HasValue && updateUnitConversionDto.ToUnitId.Value != unitConversion.ToUnitId)
            {
                var newToUnitExists = await _context.UnitsOfMeasures.AnyAsync(u => u.UnitId == updateUnitConversionDto.ToUnitId.Value);
                if (!newToUnitExists)
                {
                    throw new InvalidOperationException($"To Unit with ID '{updateUnitConversionDto.ToUnitId.Value}' not found.");
                }
                unitConversion.ToUnitId = updateUnitConversionDto.ToUnitId.Value;
            }

            // Prevent conversion to/from the same unit after updates
            if (unitConversion.FromUnitId == unitConversion.ToUnitId)
            {
                throw new InvalidOperationException("Cannot set a conversion from a unit to itself.");
            }

            // Check for duplicate conversion after potential FromUnitId/ToUnitId changes
            var duplicateExists = await _context.UnitConversions
                .AnyAsync(uc => uc.OrganizationId == organizationId &&
                                uc.ConversionId != unitConversion.ConversionId && // Exclude the current record being updated
                                ((uc.FromUnitId == unitConversion.FromUnitId && uc.ToUnitId == unitConversion.ToUnitId) ||
                                 (uc.FromUnitId == unitConversion.ToUnitId && uc.ToUnitId == unitConversion.FromUnitId)));
            if (duplicateExists)
            {
                throw new InvalidOperationException("A conversion rule between these two units already exists for this organization (or its reverse).");
            }

            // Update ConversionFactor if provided and positive
            if (updateUnitConversionDto.ConversionFactor.HasValue)
            {
                if (updateUnitConversionDto.ConversionFactor.Value <= 0)
                {
                    throw new ArgumentException("Conversion Factor must be greater than zero.");
                }
                unitConversion.ConversionFactor = updateUnitConversionDto.ConversionFactor.Value;
            }

            // Update Remarks if provided
            if (updateUnitConversionDto.Remarks != null)
            {
                unitConversion.Remarks = updateUnitConversionDto.Remarks;
            }

            unitConversion.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return (await MapUnitConversionToResponseDto(unitConversion))!;
        }

        public async Task<bool> DeleteUnitConversionAsync(Guid unitConversionId, Guid organizationId)
        {
            var unitConversion = await _context.UnitConversions
                .Where(uc => uc.ConversionId == unitConversionId && uc.OrganizationId == organizationId)
                .FirstOrDefaultAsync();

            if (unitConversion == null)
            {
                return false; // Unit Conversion not found or does not belong to the specified organization
            }

            // ในอนาคต อาจจะต้องเพิ่ม Business Rule เช่น ห้ามลบ Conversion Rule ที่ถูกใช้ใน StockAdjustment หรือ Production Order
            // แต่สำหรับตอนนี้ สามารถลบได้โดยตรง

            _context.UnitConversions.Remove(unitConversion);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal?> GetConversionFactorAsync(Guid fromUnitId, Guid toUnitId, Guid organizationId)
        {
            if (fromUnitId == toUnitId)
            {
                return 1.0m; // If units are the same, factor is 1
            }

            // 1. Try direct conversion for the organization
            var directConversion = await _context.UnitConversions
                .AsNoTracking()
                .Where(uc => uc.OrganizationId == organizationId &&
                             uc.FromUnitId == fromUnitId &&
                             uc.ToUnitId == toUnitId)
                .Select(uc => uc.ConversionFactor)
                .FirstOrDefaultAsync();

            if (directConversion != 0)
            {
                return directConversion;
            }

            // 2. Try reverse conversion for the organization
            var reverseConversion = await _context.UnitConversions
                .AsNoTracking()
                .Where(uc => uc.OrganizationId == organizationId &&
                             uc.FromUnitId == toUnitId &&
                             uc.ToUnitId == fromUnitId)
                .Select(uc => uc.ConversionFactor)
                .FirstOrDefaultAsync();

            if (reverseConversion != 0)
            {
                return 1 / reverseConversion;
            }

            // 3. Fallback to global UnitOfMeasure base unit conversions (if they belong to the same UnitGroup)
            var fromUnit = await _context.UnitsOfMeasures.AsNoTracking().FirstOrDefaultAsync(u => u.UnitId == fromUnitId);
            var toUnit = await _context.UnitsOfMeasures.AsNoTracking().FirstOrDefaultAsync(u => u.UnitId == toUnitId);

            if (fromUnit == null || toUnit == null)
            {
                return null; // One of the units does not exist
            }

            // Check if both units are in the same UnitGroup
            if (fromUnit.UnitGroupId == toUnit.UnitGroupId && fromUnit.UnitGroupId != Guid.Empty)
            {
                // Calculate conversion through the base unit of their common UnitGroup
                // (Value in FromUnit) * (Factor to base from FromUnit) / (Factor to base from ToUnit)
                if (toUnit.ConversionFactorToBaseUnit == 0)
                {
                    // This should ideally not happen if data is well-seeded/validated, but as a safeguard.
                    throw new InvalidOperationException($"ToUnit '{toUnit.UnitName}' has a zero ConversionFactorToBaseUnit, which is invalid.");
                }

                decimal factor = fromUnit.ConversionFactorToBaseUnit / toUnit.ConversionFactorToBaseUnit;
                return factor;
            }

            return null; // No conversion path found
        }
    }
}