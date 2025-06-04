using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CRAFTHER.Backend.Models
{
    public class BOMItem
    {
        [Key]
        public Guid BOMItemId { get; set; } = Guid.NewGuid();

        // Foreign Key สำหรับ Product หลักที่รายการนี้เป็นส่วนประกอบ
        [Required]
        public Guid ParentProductId { get; set; }
        [ForeignKey(nameof(ParentProductId))]
        [JsonIgnore]
        public Product? ParentProduct { get; set; }

        // หนึ่งในสองตัวนี้ต้องมีค่า และอีกตัวต้องเป็น null
        public Guid? ComponentId { get; set; } // FK to Component (Nullable)
        [ForeignKey(nameof(ComponentId))]
        public Component? Component { get; set; } // Navigation Property

        public Guid? ProductId { get; set; }   // FK to Product (as sub-product, Nullable)
        [ForeignKey(nameof(ProductId))]
        public Product? SubProduct { get; set; } // Navigation Property (เปลี่ยนชื่อเป็น SubProduct เพื่อไม่ให้ซ้ำกับ ParentProduct)

        [Required] // ยังคง ComponentType ไว้เพื่อช่วยในการแยกแยะและ validation
        [MaxLength(10)]
        // ระบุชนิดของส่วนประกอบ: "COMPONENT" (วัตถุดิบ) หรือ "PRODUCT" (สูตรย่อย)
        public string ComponentType { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Quantity { get; set; } // ปริมาณที่ใช้ของส่วนประกอบนั้นๆ ใน UsageUnit

        // Foreign Key สำหรับหน่วยที่ใช้ระบุปริมาณในสูตร (เช่น ml, g, ชิ้น)
        [Required]
        public Guid UsageUnitId { get; set; }
        [ForeignKey(nameof(UsageUnitId))]
        public UnitOfMeasure? UsageUnit { get; set; }

        [MaxLength(255)]
        public string? Remarks { get; set; } // หมายเหตุเพิ่มเติมสำหรับส่วนประกอบนี้

        public int SortOrder { get; set; } // ลำดับการแสดงผล (เช่น อยากให้เรียงลำดับส่วนผสมในสูตร)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}