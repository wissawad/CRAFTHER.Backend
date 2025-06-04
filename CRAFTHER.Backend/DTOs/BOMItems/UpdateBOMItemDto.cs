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
                        // Allow nulls if no change, but if they try to update ComponentType,
                        // one of them must be provided or become null as per rule.
                        // This validation is for explicit setting, not for leaving un-changed.
                        // If ComponentId is set, SubProductId must be null. If SubProductId is set, ComponentId must be null.
                        // If neither are set but ComponentType is, this is an issue.
                        // For update, we consider the current state of the model. This is more complex.
                        // For simplicity in DTO validation, let's enforce that if ComponentType is set,
                        // then the corresponding ID must be provided, and the other must be null.
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
            // If ComponentType is null, no validation is performed here,
            // as it implies no change to ComponentType. The service will handle default/existing values.
        }
    }
}