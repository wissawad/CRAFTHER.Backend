﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CRAFTHER.Backend.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string ProductCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        [Required]
        public Guid ProductUnitId { get; set; }
        [ForeignKey("ProductUnitId")]
        public UnitOfMeasure? ProductUnit { get; set; }

        [Required]
        public Guid? SaleUnitId { get; set; } // หน่วยที่ใช้ในการขาย Product (เช่น "ชิ้น" สำหรับเค้ก)
        [ForeignKey(nameof(SaleUnitId))]
        public UnitOfMeasure? SaleUnit { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 6)")] // ใช้ Precision สูงขึ้นสำหรับอัตราส่วนการแปลง
        public decimal ProductUnitToSaleUnitConversionFactor { get; set; } // อัตราส่วนการแปลงจาก ProductUnit ไป SaleUnit (เช่น 1 ก้อน = 8 ชิ้น, factor = 8)
        
        [Column(TypeName = "decimal(18, 4)")]
        public decimal CurrentStockQuantity { get; set; } = 0.0000m;

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal SellingPrice { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal CalculatedCost { get; set; }

        public bool IsSubProduct { get; set; }

        [Required]
        public Guid ItemCategoryId { get; set; } // Foreign Key to ItemCategory
        [ForeignKey(nameof(ItemCategoryId))]
        public ItemCategory? ItemCategory { get; set; }
        
        [Required]
        public Guid OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public Organization? Organization { get; set; }

        // Navigation Property: BOMItems ที่ Product นี้เป็น ParentProduct
        public ICollection<BOMItem>? BOMItems { get; set; }

        // Navigation Property: BOMItems ที่ Product นี้ถูกใช้เป็น SubProduct (Optional: หากคุณต้องการรู้ว่า Product นี้ถูกใช้ใน BOM อื่นๆ ที่ไหนบ้าง)
        public ICollection<BOMItem>? SubProductBOMItems { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}