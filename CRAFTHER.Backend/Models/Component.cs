using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRAFTHER.Backend.Models
{
    public class Component
    {
        [Key]
        public Guid ComponentId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)] // กำหนดความยาวสูงสุดสำหรับรหัส (ปรับได้ตามต้องการ)
        public string ComponentCode { get; set; } = string.Empty; // เพิ่ม Field รหัสวัตถุดิบ

        [Required]
        [MaxLength(255)]
        public string ComponentName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal UnitPrice { get; set; }

        [Required]
        public Guid PurchaseUnitId { get; set; }
        [ForeignKey(nameof(PurchaseUnitId))]
        public UnitOfMeasure? PurchaseUnit { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")]
        public decimal PurchaseToInventoryConversionFactor { get; set; }

        [Required]
        public Guid InventoryUnitId { get; set; }
        [ForeignKey(nameof(InventoryUnitId))]
        public UnitOfMeasure? InventoryUnit { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal CurrentStockQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal MinimumStockLevel { get; set; }

        [Required]
        public Guid ItemCategoryId { get; set; }
        [ForeignKey(nameof(ItemCategoryId))]
        public ItemCategory? ItemCategory { get; set; }
        
        [Required]
        public Guid OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public Organization? Organization { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}