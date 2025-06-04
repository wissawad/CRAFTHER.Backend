using System.ComponentModel.DataAnnotations;
using System;

namespace CRAFTHER.Backend.DTOs.UnitConversions
{
    public class CreateUnitConversionDto
    {
        // OrganizationId จะถูกดึงจาก JWT Claim ใน Controller และ Service
        // ไม่จำเป็นต้องให้ Client ส่งมาโดยตรงใน DTO นี้ เพื่อป้องกันการปลอมแปลง

        [Required(ErrorMessage = "From Unit ID is required.")]
        public Guid FromUnitId { get; set; }

        [Required(ErrorMessage = "To Unit ID is required.")]
        public Guid ToUnitId { get; set; }

        [Required(ErrorMessage = "Conversion Factor is required.")]
        [Range(0.000000001, double.MaxValue, ErrorMessage = "Conversion Factor must be greater than zero.")]
        public decimal ConversionFactor { get; set; }

        [StringLength(255, ErrorMessage = "Remarks cannot exceed 255 characters.")]
        public string? Remarks { get; set; }
    }
}