// Path: CRAFTHER.Backend/Models/ItemCategory.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.Models
{
    public class ItemCategory
    {
        [Key]
        public Guid ItemCategoryId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; } = string.Empty; // เช่น "วัตถุดิบอาหาร", "ผ้า", "อุปกรณ์ตัดเย็บ", "เครื่องดื่ม", "อาหารสำเร็จรูป"

        [MaxLength(500)]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}