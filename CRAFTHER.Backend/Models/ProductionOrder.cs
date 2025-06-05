// Path: CRAFTHER.Backend/Models/ProductionOrder.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRAFTHER.Backend.Models
{
    public class ProductionOrder
    {
        [Key]
        public Guid ProductionOrderId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string ProductionOrderCode { get; set; } = string.Empty; // รหัสคำสั่งผลิต

        [Required]
        public Guid OrganizationId { get; set; } // คำสั่งผลิตขององค์กรใด
        [ForeignKey(nameof(OrganizationId))]
        public Organization? Organization { get; set; }

        [Required]
        public Guid ProductId { get; set; } // ผลิตภัณฑ์ที่ต้องการผลิต (Parent Product จาก BOM)
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal QuantityToProduce { get; set; } // จำนวนที่ต้องการผลิต

        [Required]
        public Guid UnitOfMeasureId { get; set; } // หน่วยของ QuantityToProduce (ควรเป็น Product.ProductUnit)
        [ForeignKey(nameof(UnitOfMeasureId))]
        public UnitOfMeasure? UnitOfMeasure { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending"; // สถานะคำสั่งผลิต (เช่น Pending, InProgress, Completed, Cancelled)

        public DateTime OrderDate { get; set; } = DateTime.UtcNow; // วันที่สั่งผลิต
        public DateTime? DueDate { get; set; } // กำหนดแล้วเสร็จ
        public DateTime? CompletionDate { get; set; } // วันที่ผลิตเสร็จจริง

        [MaxLength(500)]
        public string? Notes { get; set; }

        // Navigation Property: รายละเอียดส่วนประกอบที่ใช้ในการผลิตจริง (BOMItems)
        public ICollection<ProductionOrderItem>? ProductionOrderItems { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}