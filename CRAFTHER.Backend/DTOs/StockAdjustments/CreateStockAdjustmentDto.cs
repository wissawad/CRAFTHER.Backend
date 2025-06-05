// Path: CRAFTHER.Backend/DTOs/StockAdjustments/CreateStockAdjustmentDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.StockAdjustments
{
    public class CreateStockAdjustmentDto
    {
        // OrganizationId จะถูกดึงจาก JWT Claim ใน Controller และ Service
        // ไม่จำเป็นต้องให้ Client ส่งมาโดยตรงใน DTO นี้ เพื่อป้องกันการปลอมแปลง

        public Guid? ComponentId { get; set; } // ID ของ Component ที่ถูกปรับสต็อก (Nullable)
        public Guid? ProductId { get; set; }   // ID ของ Product ที่ถูกปรับสต็อก (Nullable)

        [Required(ErrorMessage = "Adjustment Type ID is required.")]
        public Guid AdjustmentTypeId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0.0001, (double)decimal.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Unit of Measure ID is required.")]
        public Guid UnitOfMeasureId { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; }

        // --- Custom Validation ---
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // ต้องมี ComponentId หรือ ProductId อย่างใดอย่างหนึ่งเท่านั้น
            if (!ComponentId.HasValue && !ProductId.HasValue)
            {
                yield return new ValidationResult(
                    "Either Component ID or Product ID must be provided for a stock adjustment.",
                    new[] { nameof(ComponentId), nameof(ProductId) });
            }

            if (ComponentId.HasValue && ProductId.HasValue)
            {
                yield return new ValidationResult(
                    "Cannot provide both Component ID and Product ID for a single stock adjustment. Choose one.",
                    new[] { nameof(ComponentId), nameof(ProductId) });
            }
        }
    }
}