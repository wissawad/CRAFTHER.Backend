using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.Products
{
    public class UpdateProductDto
    {
        [Required(ErrorMessage = "Product ID is required for update.")]
        public Guid ProductId { get; set; }

        // Optionally, include OrganizationId for security/scoping checks in the service
        [Required(ErrorMessage = "Organization ID is required for update.")]
        public Guid OrganizationId { get; set; }

        [StringLength(255, ErrorMessage = "Product name cannot exceed 255 characters.")]
        public string? ProductName { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters.")]
        public string? ImageUrl { get; set; }

        public Guid? ProductUnitId { get; set; }

        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Selling price must be greater than 0.")]
        public decimal? SellingPrice { get; set; }

        public bool? IsSubProduct { get; set; }

        public Guid? SaleUnitId { get; set; }
    }
}