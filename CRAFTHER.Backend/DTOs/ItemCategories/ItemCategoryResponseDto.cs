// Path: CRAFTHER.Backend/DTOs/ItemCategories/ItemCategoryResponseDto.cs
using System;

namespace CRAFTHER.Backend.DTOs.ItemCategories
{
    public class ItemCategoryResponseDto
    {
        public Guid ItemCategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}