// Path: CRAFTHER.Backend/DTOs/ProductionOrders/CreateProductionOrderItemDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.ProductionOrders
{
    public class CreateProductionOrderItemDto : IValidatableObject
    {
        [Required(ErrorMessage = "Production Order ID is required.")]
        public Guid ProductionOrderId { get; set; }

        // ต้องเลือกอย่างใดอย่างหนึ่งระหว่าง ComponentId หรือ ProductId (SubProduct)
        public Guid? ComponentId { get; set; }
        public Guid? SubProductId { get; set; } // Map to ProductId in Model

        [Required(ErrorMessage = "Item Type is required (COMPONENT or PRODUCT).")]
        [StringLength(10, ErrorMessage = "Item Type cannot exceed 10 characters.")]
        public string ItemType { get; set; } = string.Empty; // "COMPONENT" or "PRODUCT"

        [Required(ErrorMessage = "Quantity used is required.")]
        [Range(0.0001, (double)decimal.MaxValue, ErrorMessage = "Quantity used must be greater than zero.")]
        public decimal QuantityUsed { get; set; }

        [Required(ErrorMessage = "Usage Unit ID is required.")]
        public Guid UsageUnitId { get; set; }

        [StringLength(255, ErrorMessage = "Notes cannot exceed 255 characters.")]
        public string? Notes { get; set; }

        // Custom validation logic to ensure only one of ComponentId or SubProductId is set
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ItemType.ToUpper() == "COMPONENT")
            {
                if (!ComponentId.HasValue)
                {
                    yield return new ValidationResult("ComponentId is required when ItemType is 'COMPONENT'.", new[] { nameof(ComponentId) });
                }
                if (SubProductId.HasValue)
                {
                    yield return new ValidationResult("SubProductId must be null when ItemType is 'COMPONENT'.", new[] { nameof(SubProductId) });
                }
            }
            else if (ItemType.ToUpper() == "PRODUCT")
            {
                if (!SubProductId.HasValue)
                {
                    yield return new ValidationResult("SubProductId is required when ItemType is 'PRODUCT'.", new[] { nameof(SubProductId) });
                }
                if (ComponentId.HasValue)
                {
                    yield return new ValidationResult("ComponentId must be null when ItemType is 'PRODUCT'.", new[] { nameof(ComponentId) });
                }
            }
            else
            {
                yield return new ValidationResult("ItemType must be either 'COMPONENT' or 'PRODUCT'.", new[] { nameof(ItemType) });
            }
        }
    }
}