// Path: CRAFTHER.Backend/Models/ComponentPriceHistory.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRAFTHER.Backend.Models
{
    public class ComponentPriceHistory
    {
        [Key]
        public Guid ComponentPriceHistoryId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid ComponentId { get; set; } // FK ไปยัง Component ที่ราคามีการเปลี่ยนแปลง
        [ForeignKey(nameof(ComponentId))]
        public Component? Component { get; set; } // Navigation property

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal OldUnitPrice { get; set; } // ราคาต่อหน่วยเดิมของ Component

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal NewUnitPrice { get; set; } // ราคาต่อหน่วยใหม่ของ Component

        [Required]
        public DateTime ChangeDate { get; set; } = DateTime.UtcNow; // วันที่และเวลาที่ราคาเปลี่ยนแปลง

        // Optional: เพื่อบันทึกว่าใครเป็นคนเปลี่ยนราคา
        public Guid? ChangedByUserId { get; set; }
        [ForeignKey(nameof(ChangedByUserId))]
        public ApplicationUser? ChangedByUser { get; set; } // Navigation property

        [Required]
        public Guid OrganizationId { get; set; } // ผูกกับองค์กรที่ Component นั้นอยู่
        [ForeignKey(nameof(OrganizationId))]
        public Organization? Organization { get; set; } // Navigation property

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // วันที่สร้าง record (อาจจะซ้ำกับ ChangeDate)
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // วันที่อัปเดต record
    }
}