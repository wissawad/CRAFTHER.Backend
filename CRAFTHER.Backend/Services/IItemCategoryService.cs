// Path: CRAFTHER.Backend/Services/IItemCategoryService.cs
using CRAFTHER.Backend.DTOs.ItemCategories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Services
{
    public interface IItemCategoryService
    {
        Task<IEnumerable<ItemCategoryResponseDto>> GetAllItemCategoriesAsync();
        Task<ItemCategoryResponseDto?> GetItemCategoryByIdAsync(Guid itemCategoryId);
        Task<ItemCategoryResponseDto> CreateItemCategoryAsync(CreateItemCategoryDto createDto);
        Task<ItemCategoryResponseDto?> UpdateItemCategoryAsync(UpdateItemCategoryDto updateDto);
        Task<bool> DeleteItemCategoryAsync(Guid itemCategoryId);
    }
}