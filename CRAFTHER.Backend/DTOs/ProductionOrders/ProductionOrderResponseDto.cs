// Path: CRAFTHER.Backend/DTOs/ProductionOrders/ProductionOrderResponseDto.cs
using System;
using System.Collections.Generic; // สำหรับ ICollection ของ ProductionOrderItemResponseDto

namespace CRAFTHER.Backend.DTOs.ProductionOrders
{
    public class ProductionOrderResponseDto
    {
        public Guid ProductionOrderId { get; set; }
        public string ProductionOrderCode { get; set; } = string.Empty;

        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; } = string.Empty; // ชื่อ Organization

        public Guid ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty; // รหัส Product
        public string ProductName { get; set; } = string.Empty; // ชื่อ Product

        public decimal QuantityToProduce { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public string UnitOfMeasureName { get; set; } = string.Empty; // ชื่อหน่วยของ QuantityToProduce
        public string UnitOfMeasureAbbreviation { get; set; } = string.Empty; // ตัวย่อหน่วย

        public string Status { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }

        public string? Notes { get; set; }

        // รายละเอียดส่วนประกอบที่ใช้ในการผลิตจริง
        public ICollection<ProductionOrderItemResponseDto>? ProductionOrderItems { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}