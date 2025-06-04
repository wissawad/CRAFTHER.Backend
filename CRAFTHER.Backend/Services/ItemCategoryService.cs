// Path: CRAFTHER.Backend/Services/ItemCategoryService.cs
using CRAFTHER.Backend.Data; // For ApplicationDbContext
using CRAFTHER.Backend.DTOs.ItemCategories;
using CRAFTHER.Backend.Models; // For ItemCategory
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public class ItemCategoryService : IItemCategoryService
    {
        private readonly ApplicationDbContext _context;

        public ItemCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper method to map ItemCategory Model to ItemCategoryResponseDto
        private ItemCategoryResponseDto MapItemCategoryToResponseDto(ItemCategory itemCategory)
        {
            return new ItemCategoryResponseDto
            {
                ItemCategoryId = itemCategory.ItemCategoryId,
                CategoryName = itemCategory.CategoryName,
                Description = itemCategory.Description,
                CreatedAt = itemCategory.CreatedAt,
                UpdatedAt = itemCategory.UpdatedAt
            };
        }

        public async Task<IEnumerable<ItemCategoryResponseDto>> GetAllItemCategoriesAsync()
        {
            var categories = await _context.ItemCategories
                .OrderBy(ic => ic.CategoryName)
                .AsNoTracking()
                .ToListAsync();

            return categories.Select(MapItemCategoryToResponseDto).ToList();
        }

        public async Task<ItemCategoryResponseDto?> GetItemCategoryByIdAsync(Guid itemCategoryId)
        {
            var category = await _context.ItemCategories
                .Where(ic => ic.ItemCategoryId == itemCategoryId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return category == null ? null : MapItemCategoryToResponseDto(category);
        }

        public async Task<ItemCategoryResponseDto> CreateItemCategoryAsync(CreateItemCategoryDto createDto)
        {
            // Check for duplicate category name
            var duplicateExists = await _context.ItemCategories
                .AnyAsync(ic => ic.CategoryName == createDto.CategoryName);
            if (duplicateExists)
            {
                throw new InvalidOperationException($"Item Category with name '{createDto.CategoryName}' already exists.");
            }

            var itemCategory = new ItemCategory
            {
                ItemCategoryId = Guid.NewGuid(),
                CategoryName = createDto.CategoryName,
                Description = createDto.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.ItemCategories.Add(itemCategory);
            await _context.SaveChangesAsync();

            return MapItemCategoryToResponseDto(itemCategory);
        }

        public async Task<ItemCategoryResponseDto?> UpdateItemCategoryAsync(UpdateItemCategoryDto updateDto)
        {
            var itemCategory = await _context.ItemCategories
                .Where(ic => ic.ItemCategoryId == updateDto.ItemCategoryId)
                .FirstOrDefaultAsync();

            if (itemCategory == null)
            {
                return null; // Item Category not found
            }

            // Check for duplicate name if CategoryName is being updated
            if (!string.IsNullOrEmpty(updateDto.CategoryName) && updateDto.CategoryName != itemCategory.CategoryName)
            {
                var duplicateExists = await _context.ItemCategories
                    .AnyAsync(ic => ic.CategoryName == updateDto.CategoryName &&
                                    ic.ItemCategoryId != updateDto.ItemCategoryId);
                if (duplicateExists)
                {
                    throw new InvalidOperationException($"Item Category with name '{updateDto.CategoryName}' already exists.");
                }
                itemCategory.CategoryName = updateDto.CategoryName;
            }

            if (updateDto.Description != null) itemCategory.Description = updateDto.Description;

            itemCategory.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return MapItemCategoryToResponseDto(itemCategory);
        }

        public async Task<bool> DeleteItemCategoryAsync(Guid itemCategoryId)
        {
            var itemCategory = await _context.ItemCategories
                .Where(ic => ic.ItemCategoryId == itemCategoryId)
                .FirstOrDefaultAsync();

            if (itemCategory == null)
            {
                return false; // Item Category not found
            }

            // Check for dependencies (if any Components or Products are linked to this category)
            var isUsedInComponents = await _context.Components.AnyAsync(c => c.ItemCategoryId == itemCategoryId); // Assume ItemCategoryId is added to Component
            var isUsedInProducts = await _context.Products.AnyAsync(p => p.ItemCategoryId == itemCategoryId); // Assume ItemCategoryId is added to Product

            if (isUsedInComponents || isUsedInProducts)
            {
                throw new InvalidOperationException("Cannot delete Item Category as it is currently in use by Components or Products.");
            }

            _context.ItemCategories.Remove(itemCategory);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}