// Path: CRAFTHER.Backend/DTOs/ProductionOrders/ProductionOrderItemResponseDto.cs
using System;

namespace CRAFTHER.Backend.DTOs.ProductionOrders
{
    public class ProductionOrderItemResponseDto
    {
        public Guid ProductionOrderItemId { get; set; }
        public Guid ProductionOrderId { get; set; }

        public Guid? ComponentId { get; set; }
        public string? ComponentCode { get; set; } // รหัสวัตถุดิบ (ถ้ามี)
        public string? ComponentName { get; set; } // ชื่อวัตถุดิบ (ถ้ามี)
        public string? ComponentInventoryUnitAbbreviation { get; set; } // หน่วยสต็อกของวัตถุดิบ (ถ้ามี)

        public Guid? SubProductId { get; set; }
        public string? SubProductCode { get; set; } // รหัส SubProduct (ถ้ามี)
        public string? SubProductName { get; set; } // ชื่อ SubProduct (ถ้ามี)
        public string? SubProductUnitAbbreviation { get; set; } // หน่วย Product Unit ของ SubProduct (ถ้ามี)

        public string ItemType { get; set; } = string.Empty; // "COMPONENT" or "PRODUCT"

        public decimal QuantityUsed { get; set; }
        public Guid UsageUnitId { get; set; }
        public string UsageUnitName { get; set; } = string.Empty; // ชื่อหน่วยที่ใช้
        public string UsageUnitAbbreviation { get; set; } = string.Empty; // ตัวย่อหน่วยที่ใช้

        public decimal UnitCostAtProduction { get; set; } // ต้นทุนต่อหน่วยของวัตถุดิบ/SubProduct ณ วันที่ผลิต
        public decimal QuantityUsedInInventoryUnit { get; set; } // ปริมาณที่ใช้ไปจริงในหน่วย Inventory/Product Unit

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}