// Path: CRAFTHER.Backend/DTOs/BOMItems/UpdateBOMItemDto.cs
using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.BOMItems
{
    public class UpdateBOMItemDto : IValidatableObject
    {
        [Required(ErrorMessage = "BOM Item ID is required for update.")]
        public Guid BOMItemId { get; set; }

        [Required(ErrorMessage = "Parent Product ID is required for update.")]
        public Guid ParentProductId { get; set; } // Crucial for security/scoping

        public Guid? ComponentId { get; set; }
        public Guid? SubProductId { get; set; }

        [StringLength(10, ErrorMessage = "Component Type cannot exceed 10 characters.")]
        public string? ComponentType { get; set; } // Nullable because it might not be updated

        [Range(0.000001, (double)decimal.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public decimal? Quantity { get; set; }

        // เพิ่ม WastePercentage เข้ามาใน Update DTO (เป็น Nullable เพราะอาจจะไม่ได้อัปเดตทุกครั้ง)
        [Range(0.00, 100.00, ErrorMessage = "Waste Percentage must be between 0 and 100.")]
        public decimal? WastePercentage { get; set; } // Nullable

        public Guid? UsageUnitId { get; set; }

        [StringLength(255, ErrorMessage = "Remarks cannot exceed 255 characters.")]
        public string? Remarks { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Sort Order cannot be negative.")]
        public int? SortOrder { get; set; }

        // Custom validation logic to ensure only one of ComponentId or SubProductId is set
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Only apply validation if ComponentType is provided
            if (!string.IsNullOrEmpty(ComponentType))
            {
                if (ComponentType.ToUpper() == "COMPONENT")
                {
                    if (!ComponentId.HasValue && !SubProductId.HasValue)
                    {
                        yield return new ValidationResult("ComponentId is required and SubProductId must be null when ComponentType is 'COMPONENT'.", new[] { nameof(ComponentId), nameof(SubProductId) });
                    }
                    if (ComponentId.HasValue && SubProductId.HasValue)
                    {
                        yield return new ValidationResult("Only one of ComponentId or SubProductId can be set.", new[] { nameof(ComponentId), nameof(SubProductId) });
                    }
                    else if (!ComponentId.HasValue && SubProductId.HasValue) // Trying to set ProductId when type is Component
                    {
                        yield return new ValidationResult("SubProductId must be null when ComponentType is 'COMPONENT'.", new[] { nameof(SubProductId) });
                    }
                }
                else if (ComponentType.ToUpper() == "PRODUCT")
                {
                    if (!SubProductId.HasValue && !ComponentId.HasValue)
                    {
                        yield return new ValidationResult("SubProductId is required and ComponentId must be null when ComponentType is 'PRODUCT'.", new[] { nameof(SubProductId), nameof(ComponentId) });
                    }
                    if (ComponentId.HasValue && SubProductId.HasValue)
                    {
                        yield return new ValidationResult("Only one of ComponentId or SubProductId can be set.", new[] { nameof(ComponentId), nameof(SubProductId) });
                    }
                    else if (ComponentId.HasValue && !SubProductId.HasValue) // Trying to set ComponentId when type is Product
                    {
                        yield return new ValidationResult("ComponentId must be null when ComponentType is 'PRODUCT'.", new[] { nameof(ComponentId) });
                    }
                }
                else
                {
                    yield return new ValidationResult("ComponentType must be either 'COMPONENT' or 'PRODUCT'.", new[] { nameof(ComponentType) });
                }
            }
        }
    }
}