using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRAFTHER.Backend.Models
{
    public class StockAdjustment
    {
        [Key]
        public Guid AdjustmentId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid OrganizationId { get; set; } // การปรับปรุงสต็อกขององค์กรใด
        [ForeignKey("OrganizationId")]
        public Organization? Organization { get; set; }

        public Guid? ComponentId { get; set; } // วัตถุดิบที่ถูกปรับปรุงสต็อก (Nullable)
        [ForeignKey("ComponentId")]
        public Component? Component { get; set; }

        public Guid? ProductId { get; set; } // ผลิตภัณฑ์ที่ถูกปรับปรุงสต็อก (สำหรับ Finished Goods) (Nullable)
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [Required]
        public Guid AdjustmentTypeId { get; set; } // ประเภทของการปรับปรุง (Receive, Issue, etc.)
        [ForeignKey("AdjustmentTypeId")]
        public StockAdjustmentType? AdjustmentType { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 4)")] // ปริมาณที่ปรับปรุง
        public decimal Quantity { get; set; }

        [Required]
        public Guid UnitOfMeasureId { get; set; } // หน่วยวัดของปริมาณที่ปรับปรุง
        [ForeignKey("UnitOfMeasureId")]
        public UnitOfMeasure? UnitOfMeasure { get; set; }

        [Required] // เพิ่ม field นี้
        [Column(TypeName = "decimal(18, 4)")]
        public decimal QuantityBeforeAdjustment { get; set; } // ยอดสต็อกของ Component ใน InventoryUnit ก่อนการปรับปรุง

        [Required] // เพิ่ม field นี้
        [Column(TypeName = "decimal(18, 4)")]
        public decimal QuantityAfterAdjustment { get; set; } // ยอดสต็อกของ Component ใน InventoryUnit หลังการปรับปรุง

        public string? Notes { get; set; } // หมายเหตุการปรับปรุง

        public DateTime AdjustmentDate { get; set; } = DateTime.UtcNow; // วันที่ทำการปรับปรุง
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}