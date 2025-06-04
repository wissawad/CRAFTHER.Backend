// Path: CRAFTHER.Backend/DTOs/StockAdjustments/CreateStockAdjustmentDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.StockAdjustments
{
    public class CreateStockAdjustmentDto
    {
        // OrganizationId จะถูกดึงจาก JWT Claim ใน Controller และ Service
        // ไม่จำเป็นต้องให้ Client ส่งมาโดยตรงใน DTO นี้ เพื่อป้องกันการปลอมแปลง

        [Required(ErrorMessage = "Component ID is required.")]
        public Guid ComponentId { get; set; }

        [Required(ErrorMessage = "Adjustment Type ID is required.")]
        public Guid AdjustmentTypeId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0.0001, (double)decimal.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Unit of Measure ID is required.")]
        public Guid UnitOfMeasureId { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; }
    }
}