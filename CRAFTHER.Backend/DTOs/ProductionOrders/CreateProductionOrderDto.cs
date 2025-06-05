// Path: CRAFTHER.Backend/DTOs/ProductionOrders/CreateProductionOrderDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.ProductionOrders
{
    public class CreateProductionOrderDto
    {
        [Required(ErrorMessage = "Production Order Code is required.")]
        [StringLength(50, ErrorMessage = "Production Order Code cannot exceed 50 characters.")]
        public string ProductionOrderCode { get; set; } = string.Empty;

        // OrganizationId จะถูกดึงจาก JWT Claim ใน Controller และ Service
        // ไม่จำเป็นต้องให้ Client ส่งมาโดยตรงใน DTO นี้ เพื่อป้องกันการปลอมแปลง

        [Required(ErrorMessage = "Product ID to produce is required.")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Quantity to produce is required.")]
        [Range(0.0001, (double)decimal.MaxValue, ErrorMessage = "Quantity to produce must be greater than zero.")]
        public decimal QuantityToProduce { get; set; }

        [Required(ErrorMessage = "Unit of Measure ID for quantity to produce is required.")]
        public Guid UnitOfMeasureId { get; set; }

        [StringLength(20, ErrorMessage = "Status cannot exceed 20 characters.")]
        // ค่าที่เป็นไปได้: Pending, InProgress, Completed, Cancelled
        public string Status { get; set; } = "Pending"; // ค่าเริ่มต้น

        public DateTime? DueDate { get; set; } // กำหนดแล้วเสร็จ (Nullable)

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; }
    }
}