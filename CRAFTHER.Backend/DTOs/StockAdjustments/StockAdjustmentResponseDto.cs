// Path: CRAFTHER.Backend/DTOs/StockAdjustments/StockAdjustmentResponseDto.cs
using System;

namespace CRAFTHER.Backend.DTOs.StockAdjustments
{
    public class StockAdjustmentResponseDto
    {
        public Guid AdjustmentId { get; set; }
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; } = string.Empty;

        public Guid ComponentId { get; set; }
        public string ComponentCode { get; set; } = string.Empty;
        public string ComponentName { get; set; } = string.Empty;
        public decimal ComponentCurrentStockQuantity { get; set; } // Stock quantity of component after this adjustment

        public Guid AdjustmentTypeId { get; set; }
        public string AdjustmentTypeName { get; set; } = string.Empty;
        public string AdjustmentTypeEffect { get; set; } = string.Empty; // "Increase" or "Decrease"

        public decimal Quantity { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public string UnitOfMeasureName { get; set; } = string.Empty;
        public string UnitOfMeasureAbbreviation { get; set; } = string.Empty;

        public decimal QuantityBeforeAdjustment { get; set; } // ยอดสต็อกของ Component ใน InventoryUnit ก่อนการปรับปรุง
        public decimal QuantityAfterAdjustment { get; set; } // ยอดสต็อกของ Component ใน InventoryUnit หลังการปรับปรุง

        public string? Notes { get; set; }
        public DateTime AdjustmentDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}