// Path: CRAFTHER.Backend/DTOs/ProductionOrders/UpdateProductionOrderItemDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.ProductionOrders
{
    public class UpdateProductionOrderItemDto : IValidatableObject
    {
        [Required(ErrorMessage = "Production Order Item ID is required for update.")]
        public Guid ProductionOrderItemId { get; set; }

        // ProductionOrderId, ComponentId, SubProductId, ItemType ไม่ควรเปลี่ยนแปลงหลังจากสร้างแล้ว
        // public Guid? ProductionOrderId { get; set; }
        // public Guid? ComponentId { get; set; }
        // public Guid? SubProductId { get; set; }
        // public string? ItemType { get; set; }

        [Range(0.0001, (double)decimal.MaxValue, ErrorMessage = "Quantity used must be greater than zero.")]
        public decimal? QuantityUsed { get; set; }

        public Guid? UsageUnitId { get; set; }

        [StringLength(255, ErrorMessage = "Notes cannot exceed 255 characters.")]
        public string? Notes { get; set; }

        // Custom validation logic (ถ้าจำเป็น ต้องพิจารณาว่าการอัปเดตจะกระทบ ItemType เดิมหรือไม่)
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // ในการอัปเดต ProductionOrderItem, ItemType และ Component/SubProduct ID ไม่ควรเปลี่ยน
            // ถ้ามีการพยายามส่งค่า ComponentId หรือ SubProductId ที่ไม่ใช่ค่าปัจจุบัน ควรมีการตรวจสอบ
            // แต่ ณ ที่นี้ เราจะไม่รับ ComponentId/SubProductId ใน DTO สำหรับ Update เพื่อบังคับไม่ให้เปลี่ยน
            return Enumerable.Empty<ValidationResult>();
        }
    }
}