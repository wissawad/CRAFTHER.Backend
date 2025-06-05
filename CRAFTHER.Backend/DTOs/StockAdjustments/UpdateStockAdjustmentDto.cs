// Path: CRAFTHER.Backend/DTOs/StockAdjustments/UpdateStockAdjustmentDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.StockAdjustments
{
    public class UpdateStockAdjustmentDto
    {
        [Required(ErrorMessage = "Adjustment ID is required for update.")]
        public Guid AdjustmentId { get; set; }

        // OrganizationId จะถูกดึงจาก JWT Claim ใน Controller และ Service
        // ไม่จำเป็นต้องให้ Client ส่งมาโดยตรงใน DTO นี้ เพื่อป้องกันการปลอมแปลง

        public Guid? ComponentId { get; set; } // สามารถเปลี่ยนแปลง Component ได้ (แต่ต้องระมัดระวัง Logic)
        public Guid? ProductId { get; set; }   // สามารถเปลี่ยนแปลง Product ได้ (แต่ต้องระมัดระวัง Logic)
        public Guid? AdjustmentTypeId { get; set; }

        [Range(0.0001, (double)decimal.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public decimal? Quantity { get; set; }

        public Guid? UnitOfMeasureId { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; }

        // --- Custom Validation ---
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // สำหรับ Update, เราจะตรวจสอบว่าถ้ามีการระบุ ComponentId หรือ ProductId มา
            // จะต้องมีอย่างใดอย่างหนึ่งเท่านั้น
            // ถ้าทั้งคู่เป็น null หมายถึงไม่ได้อัปเดต Field นี้ ซึ่งสามารถทำได้
            if (ComponentId.HasValue && ProductId.HasValue)
            {
                yield return new ValidationResult(
                    "Cannot provide both Component ID and Product ID for a single stock adjustment. Choose one.",
                    new[] { nameof(ComponentId), nameof(ProductId) });
            }
        }
    }
}