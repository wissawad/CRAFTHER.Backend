// Path: CRAFTHER.Backend/Models/ProductionOrderItem.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRAFTHER.Backend.Models
{
    public class ProductionOrderItem
    {
        [Key]
        public Guid ProductionOrderItemId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid ProductionOrderId { get; set; } // FK ไปยัง ProductionOrder หลัก
        [ForeignKey(nameof(ProductionOrderId))]
        public ProductionOrder? ProductionOrder { get; set; }

        // หนึ่งในสองตัวนี้ต้องมีค่า และอีกตัวต้องเป็น null (คล้าย BOMItem)
        public Guid? ComponentId { get; set; } // FK to Component (วัตถุดิบ)
        [ForeignKey(nameof(ComponentId))]
        public Component? Component { get; set; }

        public Guid? ProductId { get; set; }   // FK to Product (Sub-product)
        [ForeignKey(nameof(ProductId))]
        public Product? SubProduct { get; set; } // เปลี่ยนชื่อเป็น SubProduct เพื่อไม่ให้ซ้ำกับ Product ใน ProductionOrder

        [Required]
        [MaxLength(10)]
        // ระบุชนิดของส่วนประกอบ: "COMPONENT" หรือ "PRODUCT" (สูตรย่อย)
        public string ItemType { get; set; } = string.Empty; // ใช้ ItemType แทน ComponentType เพื่อให้ครอบคลุม Product ด้วย

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal QuantityUsed { get; set; } // ปริมาณที่ใช้ไปจริง (ใน UsageUnit)

        [Required]
        public Guid UsageUnitId { get; set; } // หน่วยที่ใช้สำหรับ QuantityUsed
        [ForeignKey(nameof(UsageUnitId))]
        public UnitOfMeasure? UsageUnit { get; set; }

        // ข้อมูลต้นทุน ณ เวลาที่ผลิต (สำหรับ Actual Costing)
        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal UnitCostAtProduction { get; set; } // ต้นทุนต่อหน่วยของวัตถุดิบ/SubProduct ณ วันที่ผลิต (ในหน่วย Inventory/Product Unit)

        // ข้อมูลปริมาณที่ใช้ (รวม Waste) ในหน่วย Inventory/Product Unit
        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal QuantityUsedInInventoryUnit { get; set; } // ปริมาณที่ใช้ไปจริงในหน่วย Inventory/Product Unit ของวัตถุดิบ/SubProduct นั้นๆ (รวม Waste และการแปลงหน่วย)

        [MaxLength(255)]
        public string? Notes { get; set; } // หมายเหตุเพิ่มเติมสำหรับรายการนี้

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}