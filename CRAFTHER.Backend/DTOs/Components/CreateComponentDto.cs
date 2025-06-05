using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.Components
{
    public class CreateComponentDto
    {
        [Required(ErrorMessage = "Component code is required.")]
        [StringLength(50, ErrorMessage = "Component code cannot exceed 50 characters.")]
        public string ComponentCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Component name is required.")]
        [StringLength(255, ErrorMessage = "Component name cannot exceed 255 characters.")]
        public string ComponentName { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters.")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Unit price is required.")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Unit price must be greater than 0.")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Purchase unit is required.")]
        public Guid PurchaseUnitId { get; set; }

        // *** เปลี่ยนชื่อตรงนี้: PurchaseToInventoryConversionFactor ***
        [Required(ErrorMessage = "Purchase to inventory conversion factor is required.")]
        [Range(0.000001, (double)decimal.MaxValue, ErrorMessage = "Conversion factor must be greater than 0.")]
        public decimal PurchaseToInventoryConversionFactor { get; set; }

        [Required(ErrorMessage = "Inventory unit is required.")]
        public Guid InventoryUnitId { get; set; }

        [Required(ErrorMessage = "Minimum stock level is required.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Minimum stock level cannot be negative.")]
        public decimal MinimumStockLevel { get; set; }

        [Required(ErrorMessage = "Organization ID is required.")]
        public Guid OrganizationId { get; set; }

        [Required(ErrorMessage = "Item Category ID is required.")]
        public Guid ItemCategoryId { get; set; }
    }
}