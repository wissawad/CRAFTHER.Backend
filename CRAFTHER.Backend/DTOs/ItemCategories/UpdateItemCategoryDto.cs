// Path: CRAFTHER.Backend/DTOs/ItemCategories/UpdateItemCategoryDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.ItemCategories
{
    public class UpdateItemCategoryDto
    {
        [Required(ErrorMessage = "Item Category ID is required for update.")]
        public Guid ItemCategoryId { get; set; }

        [StringLength(100, ErrorMessage = "Category Name cannot exceed 100 characters.")]
        public string? CategoryName { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }
    }
}