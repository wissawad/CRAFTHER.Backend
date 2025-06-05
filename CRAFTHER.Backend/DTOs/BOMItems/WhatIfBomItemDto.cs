// Path: CRAFTHER.Backend/DTOs/BOMItems/WhatIfBomItemDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.BOMItems
{
    public class WhatIfBomItemDto
    {
        // ใช้ BOMItemId เพื่อระบุว่าต้องการสมมุติราคา/ปริมาณของ BOMItem ตัวไหน
        [Required(ErrorMessage = "BOM Item ID is required for What-If analysis.")]
        public Guid BOMItemId { get; set; }

        // สามารถเลือกที่จะสมมุติค่าใหม่ได้
        [Range(0.000001, (double)decimal.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public decimal? NewQuantity { get; set; }

        [Range(0.00, 100.00, ErrorMessage = "Waste Percentage must be between 0 and 100.")]
        public decimal? NewWastePercentage { get; set; }

        // สามารถสมมุติราคา/ต้นทุนใหม่ได้โดยตรงสำหรับ Component/SubProduct ที่เกี่ยวข้อง
        // โดยปกติจะมาจาก UnitPrice ของ Component หรือ CalculatedCost ของ SubProduct
        [Range(0.00, (double)decimal.MaxValue, ErrorMessage = "New Unit Cost must be non-negative.")]
        public decimal? NewUnitCost { get; set; } // เช่น UnitPrice ของ Component หรือ CalculatedCost ของ SubProduct

        // UnitId สำหรับ NewUnitCost (ถ้ามีการสมมุติราคาในหน่วยที่ต่างออกไป)
        public Guid? NewUnitId { get; set; }
    }
}