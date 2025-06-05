// Path: CRAFTHER.Backend/DTOs/ProductionOrders/UpdateProductionOrderDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.ProductionOrders
{
    public class UpdateProductionOrderDto
    {
        [Required(ErrorMessage = "Production Order ID is required for update.")]
        public Guid ProductionOrderId { get; set; }

        // OrganizationId จะถูกดึงจาก JWT Claim ใน Controller และ Service
        // ไม่จำเป็นต้องให้ Client ส่งมาโดยตรงใน DTO นี้ เพื่อป้องกันการปลอมแปลง

        // ProductId ไม่ควรเปลี่ยนแปลงหลังจากสร้าง Production Order แล้ว
        // public Guid? ProductId { get; set; } // ไม่ควรอนุญาตให้อัปเดต

        [Range(0.0001, (double)decimal.MaxValue, ErrorMessage = "Quantity to produce must be greater than zero.")]
        public decimal? QuantityToProduce { get; set; }

        // UnitOfMeasureId ไม่ควรเปลี่ยนแปลงหลังจากสร้าง Production Order แล้ว
        // public Guid? UnitOfMeasureId { get; set; } // ไม่ควรอนุญาตให้อัปเดต

        [StringLength(20, ErrorMessage = "Status cannot exceed 20 characters.")]
        // ค่าที่เป็นไปได้: Pending, InProgress, Completed, Cancelled
        public string? Status { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? CompletionDate { get; set; } // สามารถอัปเดตเมื่อผลิตเสร็จ

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; }
    }
}