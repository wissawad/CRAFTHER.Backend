using System.ComponentModel.DataAnnotations;
using System;

namespace CRAFTHER.Backend.DTOs.UnitConversions
{
    public class UpdateUnitConversionDto
    {
        [Required(ErrorMessage = "Unit Conversion ID is required for update.")]
        public Guid UnitConversionId { get; set; }

        // OrganizationId จะถูกดึงจาก JWT Claim ใน Controller และ Service
        // ไม่จำเป็นต้องให้ Client ส่งมาโดยตรงใน DTO นี้ เพื่อป้องกันการปลอมแปลง

        public Guid? FromUnitId { get; set; } // Nullable, สามารถอัปเดตได้
        public Guid? ToUnitId { get; set; }   // Nullable, สามารถอัปเดตได้

        [Range(0.000000001, double.MaxValue, ErrorMessage = "Conversion Factor must be greater than zero.")]
        public decimal? ConversionFactor { get; set; } // Nullable

        [StringLength(255, ErrorMessage = "Remarks cannot exceed 255 characters.")]
        public string? Remarks { get; set; } // Nullable
    }
}