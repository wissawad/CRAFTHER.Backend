using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.Products
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Product code is required.")]
        [StringLength(50, ErrorMessage = "Product code cannot exceed 50 characters.")]
        public string ProductCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(255, ErrorMessage = "Product name cannot exceed 255 characters.")]
        public string ProductName { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters.")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Product unit is required.")]
        public Guid ProductUnitId { get; set; }

        [Required(ErrorMessage = "Selling price is required.")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Selling price must be greater than 0.")]
        public decimal SellingPrice { get; set; }

        public bool IsSubProduct { get; set; } // Indicates if this product can be used as a sub-product in BOMs

        [Required(ErrorMessage = "Organization ID is required.")]
        public Guid OrganizationId { get; set; }

        // Added based on our previous discussion
        public Guid? SaleUnitId { get; set; } // Optional: For products that might have a different sale unit
    }
}