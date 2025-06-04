namespace CRAFTHER.Backend.DTOs.Products
{
    public class ProductResponseDto
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal CurrentStockQuantity { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal CalculatedCost { get; set; }
        public bool IsSubProduct { get; set; }

        // Flattened Navigation Properties' important data for ProductUnit
        public Guid ProductUnitId { get; set; }
        public string ProductUnitName { get; set; } = string.Empty;
        public string ProductUnitAbbreviation { get; set; } = string.Empty;

        // Flattened Navigation Properties' important data for SaleUnit
        public Guid? SaleUnitId { get; set; }
        public string? SaleUnitName { get; set; }
        public string? SaleUnitAbbreviation { get; set; }

        // Flattened Navigation Properties' important data for Organization
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}