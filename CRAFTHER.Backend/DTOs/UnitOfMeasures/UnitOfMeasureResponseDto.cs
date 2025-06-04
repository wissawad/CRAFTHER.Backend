using System;

namespace CRAFTHER.Backend.DTOs.UnitOfMeasures
{
    public class UnitOfMeasureResponseDto
    {
        public Guid UnitId { get; set; }
        public string UnitName { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public bool IsBaseUnit { get; set; }
        public decimal ConversionFactorToBaseUnit { get; set; }

        // ข้อมูลของ UnitGroup ที่เกี่ยวข้อง
        public Guid UnitGroupId { get; set; }
        public string UnitGroupName { get; set; } = string.Empty; // ชื่อกลุ่มหน่วย
        public string? UnitGroupDescription { get; set; } // รายละเอียดกลุ่มหน่วย

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}