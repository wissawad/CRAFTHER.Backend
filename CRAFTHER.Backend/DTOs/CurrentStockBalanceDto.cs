using System;
using System.ComponentModel.DataAnnotations.Schema; // Ensure this is present for Column attribute

namespace CRAFTHER.Backend.DTOs
{
    public class CurrentStockBalanceDto
    {
        public Guid ComponentId { get; set; }
        public string ComponentName { get; set; } = string.Empty;
        public string ComponentSKU { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 4)")] // ใช้ Precision เดียวกับ Quantity ใน StockAdjustment
        public decimal CurrentQuantity { get; set; }

        public Guid UnitOfMeasureId { get; set; }
        public string UnitOfMeasureName { get; set; } = string.Empty;
        public string UnitOfMeasureSymbol { get; set; } = string.Empty;
    }
}