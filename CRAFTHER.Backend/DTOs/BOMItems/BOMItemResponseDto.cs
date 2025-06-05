namespace CRAFTHER.Backend.DTOs.BOMItems
{
    public class BOMItemResponseDto
    {
        public Guid BOMItemId { get; set; }
        public Guid ParentProductId { get; set; }
        public string ParentProductCode { get; set; } = string.Empty;
        public string ParentProductName { get; set; } = string.Empty;

        public Guid? ComponentId { get; set; }
        public string? ComponentCode { get; set; } // Will be null if ComponentType is PRODUCT
        public string? ComponentName { get; set; } // Will be null if ComponentType is PRODUCT
        public string? ComponentInventoryUnitAbbreviation { get; set; } // Unit of the actual component stock

        public Guid? SubProductId { get; set; } // Changed from ProductId to SubProductId for clarity
        public string? SubProductCode { get; set; } // Will be null if ComponentType is COMPONENT
        public string? SubProductName { get; set; } // Will be null if ComponentType is COMPONENT
        public string? SubProductUnitAbbreviation { get; set; } // Unit of the actual sub-product stock

        public string ComponentType { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal WastePercentage { get; set; }

        public Guid UsageUnitId { get; set; }
        public string UsageUnitName { get; set; } = string.Empty;
        public string UsageUnitAbbreviation { get; set; } = string.Empty;

        public string? Remarks { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}