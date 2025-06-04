namespace CRAFTHER.Backend.DTOs
{
    public class CurrentStockBalanceDto
    {
        public Guid EntityId { get; set; } // Could be ProductId or ComponentId
        public string EntityCode { get; set; } = string.Empty;
        public string EntityName { get; set; } = string.Empty;
        public decimal CurrentStockQuantity { get; set; }
        public Guid UnitId { get; set; }
        public string UnitName { get; set; } = string.Empty;
        public string UnitAbbreviation { get; set; } = string.Empty;
    }
}