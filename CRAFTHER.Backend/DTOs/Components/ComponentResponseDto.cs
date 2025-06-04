namespace CRAFTHER.Backend.DTOs.Components
{
    public class ComponentResponseDto
    {
        public Guid ComponentId { get; set; }
        public string ComponentCode { get; set; } = string.Empty;
        public string ComponentName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal UnitPrice { get; set; }

        // Flattened Purchase Unit details
        public Guid PurchaseUnitId { get; set; }
        public string PurchaseUnitName { get; set; } = string.Empty;
        public string PurchaseUnitAbbreviation { get; set; } = string.Empty;

        // *** เปลี่ยนชื่อตรงนี้: PurchaseToInventoryConversionFactor ***
        public decimal PurchaseToInventoryConversionFactor { get; set; }

        // Flattened Inventory Unit details
        public Guid InventoryUnitId { get; set; }
        public string InventoryUnitName { get; set; } = string.Empty;
        public string InventoryUnitAbbreviation { get; set; } = string.Empty;

        public decimal CurrentStockQuantity { get; set; }
        public decimal MinimumStockLevel { get; set; }

        // Flattened Organization details
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}