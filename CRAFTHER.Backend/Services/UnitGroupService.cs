using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.DTOs.UnitGroups;
using CRAFTHER.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public class UnitGroupService : IUnitGroupService
    {
        private readonly ApplicationDbContext _context;

        public UnitGroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper method to map UnitGroup Model to UnitGroupResponseDto
        private UnitGroupResponseDto MapUnitGroupToResponseDto(UnitGroup unitGroup)
        {
            return new UnitGroupResponseDto
            {
                UnitGroupId = unitGroup.UnitGroupId,
                UnitGroupName = unitGroup.UnitGroupName,
                Description = unitGroup.Description,
                // OrganizationId ถูกลบออกแล้ว
                CreatedAt = unitGroup.CreatedAt,
                UpdatedAt = unitGroup.UpdatedAt
            };
        }

        public async Task<IEnumerable<UnitGroupResponseDto>> GetAllUnitGroupsAsync()
        {
            // ลบการกรองด้วย organizationId ออก
            var unitGroups = await _context.UnitGroups
                .OrderBy(ug => ug.UnitGroupName)
                .AsNoTracking()
                .ToListAsync();

            return unitGroups.Select(MapUnitGroupToResponseDto).ToList();
        }

        public async Task<UnitGroupResponseDto?> GetUnitGroupByIdAsync(Guid unitGroupId)
        {
            // ลบการกรองด้วย organizationId ออก
            var unitGroup = await _context.UnitGroups
                .Where(ug => ug.UnitGroupId == unitGroupId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return unitGroup == null ? null : MapUnitGroupToResponseDto(unitGroup);
        }

        public async Task<UnitGroupResponseDto> CreateUnitGroupAsync(CreateUnitGroupDto createUnitGroupDto)
        {
            // ลบการตรวจสอบ OrganizationId เพราะเป็น Global แล้ว

            // 1. Check for duplicate UnitGroupName (now globally unique)
            var duplicateExists = await _context.UnitGroups
                .AnyAsync(ug => ug.UnitGroupName == createUnitGroupDto.UnitGroupName);
            if (duplicateExists)
            {
                throw new InvalidOperationException($"Unit Group with name '{createUnitGroupDto.UnitGroupName}' already exists.");
            }

            var unitGroup = new UnitGroup
            {
                UnitGroupId = Guid.NewGuid(),
                UnitGroupName = createUnitGroupDto.UnitGroupName,
                Description = createUnitGroupDto.Description,
                // OrganizationId ถูกลบออกแล้ว
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.UnitGroups.Add(unitGroup);
            await _context.SaveChangesAsync();

            return MapUnitGroupToResponseDto(unitGroup);
        }

        public async Task<UnitGroupResponseDto?> UpdateUnitGroupAsync(UpdateUnitGroupDto updateUnitGroupDto)
        {
            // ลบการกรองด้วย organizationId ออก
            var unitGroup = await _context.UnitGroups
                .Where(ug => ug.UnitGroupId == updateUnitGroupDto.UnitGroupId)
                .FirstOrDefaultAsync();

            if (unitGroup == null)
            {
                return null; // Unit Group not found
            }

            // Check for duplicate name if UnitGroupName is being updated (globally unique)
            if (!string.IsNullOrEmpty(updateUnitGroupDto.UnitGroupName) &&
                updateUnitGroupDto.UnitGroupName != unitGroup.UnitGroupName)
            {
                var duplicateExists = await _context.UnitGroups
                    .AnyAsync(ug => ug.UnitGroupName == updateUnitGroupDto.UnitGroupName &&
                                    ug.UnitGroupId != updateUnitGroupDto.UnitGroupId);
                if (duplicateExists)
                {
                    throw new InvalidOperationException($"Unit Group with name '{updateUnitGroupDto.UnitGroupName}' already exists.");
                }
                unitGroup.UnitGroupName = updateUnitGroupDto.UnitGroupName;
            }

            if (updateUnitGroupDto.Description != null) unitGroup.Description = updateUnitGroupDto.Description;

            unitGroup.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return MapUnitGroupToResponseDto(unitGroup);
        }

        public async Task<bool> DeleteUnitGroupAsync(Guid unitGroupId)
        {
            // ลบการกรองด้วย organizationId ออก
            var unitGroup = await _context.UnitGroups
                .Where(ug => ug.UnitGroupId == unitGroupId)
                .Include(ug => ug.UnitsOfMeasure) // Include UnitsOfMeasure to check for dependencies
                .FirstOrDefaultAsync();

            if (unitGroup == null)
            {
                return false; // Unit Group not found
            }

            // Check if there are any associated UnitOfMeasures
            if (unitGroup.UnitsOfMeasure != null && unitGroup.UnitsOfMeasure.Any())
            {
                throw new InvalidOperationException("Cannot delete Unit Group because it has associated Units of Measure.");
            }

            _context.UnitGroups.Remove(unitGroup);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}