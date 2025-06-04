using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.BOMItems
{
    public class CreateBOMItemDto : IValidatableObject
    {
        [Required(ErrorMessage = "Parent Product ID is required.")]
        public Guid ParentProductId { get; set; }

        // ต้องเลือกอย่างใดอย่างหนึ่งระหว่าง ComponentId หรือ ProductId
        public Guid? ComponentId { get; set; }
        public Guid? SubProductId { get; set; } // เปลี่ยนชื่อให้สอดคล้องกับ SubProduct ใน BOMItem model

        [Required(ErrorMessage = "Component Type is required.")]
        [StringLength(10, ErrorMessage = "Component Type cannot exceed 10 characters.")]
        // ค่าที่เป็นไปได้: "COMPONENT" หรือ "PRODUCT"
        public string ComponentType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0.000001, (double)decimal.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Usage Unit ID is required.")]
        public Guid UsageUnitId { get; set; }

        [StringLength(255, ErrorMessage = "Remarks cannot exceed 255 characters.")]
        public string? Remarks { get; set; }

        [Required(ErrorMessage = "Sort Order is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Sort Order cannot be negative.")]
        public int SortOrder { get; set; }

        // Custom validation logic to ensure only one of ComponentId or SubProductId is set
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ComponentType.ToUpper() == "COMPONENT")
            {
                if (!ComponentId.HasValue)
                {
                    yield return new ValidationResult("ComponentId is required when ComponentType is 'COMPONENT'.", new[] { nameof(ComponentId) });
                }
                if (SubProductId.HasValue)
                {
                    yield return new ValidationResult("SubProductId must be null when ComponentType is 'COMPONENT'.", new[] { nameof(SubProductId) });
                }
            }
            else if (ComponentType.ToUpper() == "PRODUCT")
            {
                if (!SubProductId.HasValue)
                {
                    yield return new ValidationResult("SubProductId is required when ComponentType is 'PRODUCT'.", new[] { nameof(SubProductId) });
                }
                if (ComponentId.HasValue)
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