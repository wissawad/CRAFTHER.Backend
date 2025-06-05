// Path: CRAFTHER.Backend/Services/ComponentService.cs
using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.DTOs.Components;
using CRAFTHER.Backend.DTOs; // For CurrentStockBalanceDto
using CRAFTHER.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRAFTHER.Backend.Services; // เพิ่มเข้ามาสำหรับ IProductCostingService
using Microsoft.AspNetCore.Http; // *** เพิ่มตรงนี้ ***
using System.Security.Claims; // *** เพิ่มตรงนี้ ***

namespace CRAFTHER.Backend.Services
{
    public class ComponentService : IComponentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductCostingService _productCostingService;
        private readonly IHttpContextAccessor _httpContextAccessor; // *** เพิ่มตรงนี้ ***

        public ComponentService(ApplicationDbContext context, IProductCostingService productCostingService, IHttpContextAccessor httpContextAccessor) // *** เปลี่ยน parameter ใน Constructor ***
        {
            _context = context;
            _productCostingService = productCostingService;
            _httpContextAccessor = httpContextAccessor; // *** Assign it ***
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
            if (component.ItemCategory == null) // *** เพิ่มการโหลด ItemCategory ***
            {
                await _context.Entry(component).Reference(c => c.ItemCategory).LoadAsync();
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
                PurchaseToInventoryConversionFactor = component.PurchaseToInventoryConversionFactor,
                InventoryUnitId = component.InventoryUnitId,
                InventoryUnitName = component.InventoryUnit?.UnitName ?? "N/A",
                InventoryUnitAbbreviation = component.InventoryUnit?.Abbreviation ?? "N/A",
                CurrentStockQuantity = component.CurrentStockQuantity,
                MinimumStockLevel = component.MinimumStockLevel,
                OrganizationId = component.OrganizationId,
                OrganizationName = component.Organization?.OrganizationName ?? "N/A",
                ItemCategoryId = component.ItemCategoryId, // *** เพิ่ม ItemCategoryId ***
                ItemCategoryName = component.ItemCategory?.CategoryName ?? "N/A", // *** เพิ่ม ItemCategoryName ***
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
                .Include(c => c.ItemCategory) // *** เพิ่มการ Include ItemCategory ***
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
                .Include(c => c.ItemCategory) // *** เพิ่มการ Include ItemCategory ***
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return await MapComponentToResponseDto(component);
        }

        public async Task<ComponentResponseDto> CreateComponentAsync(CreateComponentDto createComponentDto)
        {
            // Note: ItemCategoryId is Required in Component model, so it should be in CreateComponentDto too.
            // Assuming this is handled in DTO validation.
            var existingComponent = await _context.Components
                .AnyAsync(c => c.OrganizationId == createComponentDto.OrganizationId &&
                               c.ComponentCode == createComponentDto.ComponentCode);
            if (existingComponent)
            {
                throw new InvalidOperationException($"Component with code '{createComponentDto.ComponentCode}' already exists for this organization.");
            }

            // *** Verify ItemCategory exists ***
            var itemCategoryExists = await _context.ItemCategories.AnyAsync(ic => ic.ItemCategoryId == createComponentDto.ItemCategoryId);
            if (!itemCategoryExists)
            {
                throw new InvalidOperationException($"Item Category with ID '{createComponentDto.ItemCategoryId}' not found.");
            }
            // *** สิ้นสุดการตรวจสอบ ***

            var component = new Component
            {
                ComponentId = Guid.NewGuid(),
                ComponentCode = createComponentDto.ComponentCode,
                ComponentName = createComponentDto.ComponentName,
                Description = createComponentDto.Description,
                ImageUrl = createComponentDto.ImageUrl,
                UnitPrice = createComponentDto.UnitPrice,
                PurchaseUnitId = createComponentDto.PurchaseUnitId,
                PurchaseToInventoryConversionFactor = createComponentDto.PurchaseToInventoryConversionFactor,
                InventoryUnitId = createComponentDto.InventoryUnitId,
                CurrentStockQuantity = 0,
                MinimumStockLevel = createComponentDto.MinimumStockLevel,
                OrganizationId = createComponentDto.OrganizationId,
                ItemCategoryId = createComponentDto.ItemCategoryId, // *** ตั้งค่า ItemCategoryId ***
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Components.Add(component);
            await _context.SaveChangesAsync();

            await _context.Entry(component).Reference(c => c.PurchaseUnit).LoadAsync();
            await _context.Entry(component).Reference(c => c.InventoryUnit).LoadAsync();
            await _context.Entry(component).Reference(c => c.Organization).LoadAsync();
            await _context.Entry(component).Reference(c => c.ItemCategory).LoadAsync(); // *** Load ItemCategory ***

            return (await MapComponentToResponseDto(component))!;
        }

        public async Task<ComponentResponseDto?> UpdateComponentAsync(UpdateComponentDto updateComponentDto)
        {
            var component = await _context.Components
                .Where(c => c.ComponentId == updateComponentDto.ComponentId && c.OrganizationId == updateComponentDto.OrganizationId)
                .FirstOrDefaultAsync(); // ไม่ใช้ AsNoTracking() เพราะเราจะ Update Entity นี้

            if (component == null)
            {
                return null;
            }

            bool unitPriceChanged = false;

            // *** Logic สำหรับบันทึก ComponentPriceHistory ***
            decimal oldUnitPrice = component.UnitPrice; // บันทึกราคาเดิม
            Guid? changedByUserId = null;
            // ดึง UserId จาก Claims
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userIdClaim, out Guid parsedUserId))
            {
                changedByUserId = parsedUserId;
            }

            if (updateComponentDto.UnitPrice.HasValue && updateComponentDto.UnitPrice.Value != oldUnitPrice)
            {
                unitPriceChanged = true;

                var priceHistory = new ComponentPriceHistory
                {
                    ComponentId = component.ComponentId,
                    OldUnitPrice = oldUnitPrice,
                    NewUnitPrice = updateComponentDto.UnitPrice.Value,
                    ChangeDate = DateTime.UtcNow,
                    ChangedByUserId = changedByUserId, // User ID ที่ทำการเปลี่ยนแปลง
                    OrganizationId = component.OrganizationId, // ผูกกับ Organization ของ Component
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                _context.ComponentPriceHistories.Add(priceHistory);
            }
            // *** สิ้นสุด Logic บันทึก ComponentPriceHistory ***


            if (updateComponentDto.ComponentName != null) component.ComponentName = updateComponentDto.ComponentName;
            if (updateComponentDto.Description != null) component.Description = updateComponentDto.Description;
            if (updateComponentDto.ImageUrl != null) component.ImageUrl = updateComponentDto.ImageUrl;
            if (updateComponentDto.UnitPrice.HasValue) component.UnitPrice = updateComponentDto.UnitPrice.Value; // อัปเดตราคาใหม่
            if (updateComponentDto.PurchaseUnitId.HasValue) component.PurchaseUnitId = updateComponentDto.PurchaseUnitId.Value;
            if (updateComponentDto.PurchaseToInventoryConversionFactor.HasValue) component.PurchaseToInventoryConversionFactor = updateComponentDto.PurchaseToInventoryConversionFactor.Value;
            if (updateComponentDto.InventoryUnitId.HasValue) component.InventoryUnitId = updateComponentDto.InventoryUnitId.Value;
            if (updateComponentDto.MinimumStockLevel.HasValue) component.MinimumStockLevel = updateComponentDto.MinimumStockLevel.Value;

            // Optional: ถ้ามีการเปลี่ยน ItemCategoryId ใน UpdateComponentDto
            // (ต้องเพิ่ม ItemCategoryId ใน UpdateComponentDto ก่อน)
            // if (updateComponentDto.ItemCategoryId.HasValue && updateComponentDto.ItemCategoryId.Value != component.ItemCategoryId)
            // {
            //     var newItemCategoryExists = await _context.ItemCategories.AnyAsync(ic => ic.ItemCategoryId == updateComponentDto.ItemCategoryId.Value);
            //     if (!newItemCategoryExists)
            //     {
            //         throw new InvalidOperationException($"New Item Category with ID '{updateComponentDto.ItemCategoryId.Value}' not found.");
            //     }
            //     component.ItemCategoryId = updateComponentDto.ItemCategoryId.Value;
            // }

            component.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Trigger recalculation of affected products' costs if UnitPrice changed
            if (unitPriceChanged)
            {
                await _productCostingService.RecalculateProductsAffectedByComponentPriceChange(component.ComponentId, component.OrganizationId); // เรียกใช้ ProductCostingService
            }

            await _context.Entry(component).Reference(c => c.PurchaseUnit).LoadAsync();
            await _context.Entry(component).Reference(c => c.InventoryUnit).LoadAsync();
            await _context.Entry(component).Reference(c => c.Organization).LoadAsync();
            await _context.Entry(component).Reference(c => c.ItemCategory).LoadAsync(); // *** Load ItemCategory ***

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

            // Optional: Check if used in ComponentPriceHistory (Cascade Delete is configured)
            // If you want to prevent deletion, you can add this check
            // var hasPriceHistory = await _context.ComponentPriceHistories.AnyAsync(cph => cph.ComponentId == componentId);
            // if (hasPriceHistory)
            // {
            //     throw new InvalidOperationException("Cannot delete Component as it has price history records.");
            // }

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
                    UnitAbbreviation = c.InventoryUnit != null ? c.InventoryUnit.Abbreviation : "N/A",
                    EntityType = "Component" // เพิ่มประเภท
                })
                .FirstOrDefaultAsync();

            return component;
        }

        // --- ลบเมธอด RecalculateComponentCostImpactOnProductsAsync ออกจาก ComponentService ---
        // (ย้ายไปที่ ProductCostingService แล้ว)
    }
}