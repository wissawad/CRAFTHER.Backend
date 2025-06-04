using System;

namespace CRAFTHER.Backend.DTOs.UnitConversions
{
    public class UnitConversionResponseDto
    {
        public Guid UnitConversionId { get; set; }
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; } = string.Empty; // ชื่อ Organization ที่เกี่ยวข้อง
        public Guid FromUnitId { get; set; }
        public string FromUnitName { get; set; } = string.Empty;
        public string FromUnitAbbreviation { get; set; } = string.Empty;
        public Guid ToUnitId { get; set; }
        public string ToUnitName { get; set; } = string.Empty;
        public string ToUnitAbbreviation { get; set; } = string.Empty;
        public decimal ConversionFactor { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}