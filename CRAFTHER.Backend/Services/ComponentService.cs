using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.DTOs.Components;
using CRAFTHER.Backend.DTOs; // For CurrentStockBalanceDto
using CRAFTHER.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public class ComponentService : IComponentService
    {
        private readonly ApplicationDbContext _context;

        public ComponentService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper method to map Component Model to ComponentResponseDto
        private async Task<ComponentResponseDto?> MapComponentToResponseDto(Component? component)
        {
            if (component == null) return null;

            if (component.PurchaseUnit == null)
            {
                await _context.Entry(component).Reference(c => c.PurchaseUnit).LoadAsync();
            }
            if (component.InventoryUnit == null)
            {
                await _context.Entry(component).Reference(c => c.InventoryUnit).LoadAsync();
            }
            if (component.Organization == null)
            {
                await _context.Entry(component).Reference(c => c.Organization).LoadAsync();
            }

            return new ComponentResponseDto
            {
                ComponentId = component.ComponentId,
                ComponentCode = component.ComponentCode,
                ComponentName = component.ComponentName,
                Description = component.Description,
                ImageUrl = component.ImageUrl,
                UnitPrice = component.UnitPrice,
                PurchaseUnitId = component.PurchaseUnitId,
                PurchaseUnitName = component.PurchaseUnit?.UnitName ?? "N/A",
                PurchaseUnitAbbreviation = component.PurchaseUnit?.Abbreviation ?? "N/A",
                // *** เปลี่ยนชื่อตรงนี้: PurchaseToInventoryConversionFactor ***
                PurchaseToInventoryConversionFactor = component.PurchaseToInventoryConversionFactor,
                InventoryUnitId = component.InventoryUnitId,
                InventoryUnitName = component.InventoryUnit?.UnitName ?? "N/A",
                InventoryUnitAbbreviation = component.InventoryUnit?.Abbreviation ?? "N/A",
                CurrentStockQuantity = component.CurrentStockQuantity,
                MinimumStockLevel = component.MinimumStockLevel,
                OrganizationId = component.OrganizationId,
                OrganizationName = component.Organization?.OrganizationName ?? "N/A",
                CreatedAt = component.CreatedAt,
                UpdatedAt = component.UpdatedAt
            };
        }

        public async Task<IEnumerable<ComponentResponseDto>> GetAllComponentsAsync(Guid organizationId)
        {
            var components = await _context.Components
                .Where(c => c.OrganizationId == organizationId)
                .Include(c => c.PurchaseUnit)
                .Include(c => c.InventoryUnit)
                .Include(c => c.Organization)
                .AsNoTracking()
                .ToListAsync();

            var componentDtos = new List<ComponentResponseDto>();
            foreach (var component in components)
            {
                componentDtos.Add((await MapComponentToResponseDto(component))!);
            }
            return componentDtos;
        }

        public async Task<ComponentResponseDto?> GetComponentByIdAsync(Guid componentId, Guid organizationId)
        {
            var component = await _context.Components
                .Where(c => c.ComponentId == componentId && c.OrganizationId == organizationId)
                .Include(c => c.PurchaseUnit)
                .Include(c => c.InventoryUnit)
                .Include(c => c.Organization)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await MapComponentToResponseDto(component);
        }

        public async Task<ComponentResponseDto> CreateComponentAsync(CreateComponentDto createComponentDto)
        {
            var existingComponent = await _context.Components
                .AnyAsync(c => c.OrganizationId == createComponentDto.OrganizationId &&
                               c.ComponentCode == createComponentDto.ComponentCode);
            if (existingComponent)
            {
                throw new InvalidOperationException($"Component with code '{createComponentDto.ComponentCode}' already exists for this organization.");
            }

            var component = new Component
            {
                ComponentId = Guid.NewGuid(),
                ComponentCode = createComponentDto.ComponentCode,
                ComponentName = createComponentDto.ComponentName,
                Description = createComponentDto.Description,
                ImageUrl = createComponentDto.ImageUrl,
                UnitPrice = createComponentDto.UnitPrice,
                PurchaseUnitId = createComponentDto.PurchaseUnitId,
                // *** เปลี่ยนชื่อตรงนี้: PurchaseToInventoryConversionFactor ***
                PurchaseToInventoryConversionFactor = createComponentDto.PurchaseToInventoryConversionFactor,
                InventoryUnitId = createComponentDto.InventoryUnitId,
                CurrentStockQuantity = 0,
                MinimumStockLevel = createComponentDto.MinimumStockLevel,
                OrganizationId = createComponentDto.OrganizationId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Components.Add(component);
            await _context.SaveChangesAsync();

            await _context.Entry(component).Reference(c => c.PurchaseUnit).LoadAsync();
            await _context.Entry(component).Reference(c => c.InventoryUnit).LoadAsync();
            await _context.Entry(component).Reference(c => c.Organization).LoadAsync();

            return (await MapComponentToResponseDto(component))!;
        }

        public async Task<ComponentResponseDto?> UpdateComponentAsync(UpdateComponentDto updateComponentDto)
        {
            var component = await _context.Components
                .Where(c => c.ComponentId == updateComponentDto.ComponentId && c.OrganizationId == updateComponentDto.OrganizationId)
                .FirstOrDefaultAsync();

            if (component == null)
            {
                return null;
            }

            if (updateComponentDto.ComponentName != null) component.ComponentName = updateComponentDto.ComponentName;
            if (updateComponentDto.Description != null) component.Description = updateComponentDto.Description;
            if (updateComponentDto.ImageUrl != null) component.ImageUrl = updateComponentDto.ImageUrl;
            if (updateComponentDto.UnitPrice.HasValue) component.UnitPrice = updateComponentDto.UnitPrice.Value;
            if (updateComponentDto.PurchaseUnitId.HasValue) component.PurchaseUnitId = updateComponentDto.PurchaseUnitId.Value;
            // *** เปลี่ยนชื่อตรงนี้: PurchaseToInventoryConversionFactor ***
            if (updateComponentDto.PurchaseToInventoryConversionFactor.HasValue) component.PurchaseToInventoryConversionFactor = updateComponentDto.PurchaseToInventoryConversionFactor.Value;
            if (updateComponentDto.InventoryUnitId.HasValue) component.InventoryUnitId = updateComponentDto.InventoryUnitId.Value;
            if (updateComponentDto.MinimumStockLevel.HasValue) component.MinimumStockLevel = updateComponentDto.MinimumStockLevel.Value;

            component.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            await _context.Entry(component).Reference(c => c.PurchaseUnit).LoadAsync();
            await _context.Entry(component).Reference(c => c.InventoryUnit).LoadAsync();
            await _context.Entry(component).Reference(c => c.Organization).LoadAsync();

            return (await MapComponentToResponseDto(component))!;
        }

        public async Task<bool> DeleteComponentAsync(Guid componentId, Guid organizationId)
        {
            var component = await _context.Components
                .Where(c => c.ComponentId == componentId && c.OrganizationId == organizationId)
                .FirstOrDefaultAsync();

            if (component == null)
            {
                return false;
            }

            var isUsedInBOMs = await _context.BOMItems.AnyAsync(bi => bi.ComponentId == componentId);
            if (isUsedInBOMs)
            {
                throw new InvalidOperationException("Component cannot be deleted as it is used in a Bill of Material.");
            }

            _context.Components.Remove(component);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CurrentStockBalanceDto?> GetComponentStockBalanceAsync(Guid componentId, Guid organizationId)
        {
            var component = await _context.Components
                .Where(c => c.ComponentId == componentId && c.OrganizationId == organizationId)
                .Include(c => c.InventoryUnit)
                .AsNoTracking()
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
                .FirstOrDefaultAsync();

            return component;
        }
    }
}