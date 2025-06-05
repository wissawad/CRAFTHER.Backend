// Path: CRAFTHER.Backend/DTOs/StockAdjustments/StockAdjustmentResponseDto.cs
using System;

namespace CRAFTHER.Backend.DTOs.StockAdjustments
{
    public class StockAdjustmentResponseDto
    {
        public Guid AdjustmentId { get; set; }
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; } = string.Empty;

        // *** เพิ่ม ProductId และเปลี่ยนชื่อ/โครงสร้างสำหรับ Component/Product ***
        public Guid? ComponentId { get; set; }
        public string? ComponentCode { get; set; } // เปลี่ยนเป็น nullable
        public string? ComponentName { get; set; } // เปลี่ยนเป็น nullable
        public string? ComponentInventoryUnitAbbreviation { get; set; } // เปลี่ยนเป็น nullable

        public Guid? ProductId { get; set; } // เพิ่ม ProductId
        public string? ProductCode { get; set; } // เพิ่ม ProductCode
        public string? ProductName { get; set; } // เพิ่ม ProductName
        public string? ProductUnitAbbreviation { get; set; } // เพิ่ม ProductUnitAbbreviation

        public decimal ItemCurrentStockQuantity { get; set; } // เปลี่ยนชื่อจาก ComponentCurrentStockQuantity
        // *** สิ้นสุดการเพิ่ม/เปลี่ยนแปลง ***

        public Guid AdjustmentTypeId { get; set; }
        public string AdjustmentTypeName { get; set; } = string.Empty;
        public string AdjustmentTypeEffect { get; set; } = string.Empty;

        public decimal Quantity { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public string UnitOfMeasureName { get; set; } = string.Empty;
        public string UnitOfMeasureAbbreviation { get; set; } = string.Empty;

        public decimal QuantityBeforeAdjustment { get; set; }
        public decimal QuantityAfterAdjustment { get; set; }

        public string? Notes { get; set; }
        public DateTime AdjustmentDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}