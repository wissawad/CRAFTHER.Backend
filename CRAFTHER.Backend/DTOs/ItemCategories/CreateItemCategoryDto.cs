// Path: CRAFTHER.Backend/DTOs/ItemCategories/CreateItemCategoryDto.cs
using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.ItemCategories
{
    public class CreateItemCategoryDto
    {
        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(100, ErrorMessage = "Category Name cannot exceed 100 characters.")]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }
    }
}