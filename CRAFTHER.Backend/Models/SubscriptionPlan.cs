using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis; // สำหรับ [SetsRequiredMembers]

namespace CRAFTHER.Backend.Models
{
    public class SubscriptionPlan
    {
        [Key]
        public Guid PlanId { get; set; } = Guid.NewGuid(); // Primary Key

        [Required]
        [MaxLength(50)]
        public string PlanName { get; set; } = string.Empty; // ชื่อแผน (เช่น "Free", "Basic", "Pro")

        [Required]
        public decimal Price { get; set; } // ราคาต่อเดือน/ปี

        [MaxLength(500)]
        public string? Description { get; set; } // คำอธิบายแผน

        // ข้อจำกัดของแต่ละแผน
        public int? MaxProducts { get; set; } // จำนวนสูตร/ผลิตภัณฑ์สูงสุด (nullable: ไม่มีขีดจำกัด)
        public int? MaxComponents { get; set; } // จำนวนวัตถุดิบสูงสุด
        public int? MaxUsers { get; set; } // จำนวนผู้ใช้งานสูงสุดต่อองค์กร
        public int? StorageSpaceMB { get; set; } // พื้นที่เก็บข้อมูล (เป็น MB)

        // คุณสมบัติอื่นๆ ของแผน (อาจจะเพิ่มในอนาคต)
        public bool CanAccessAdvancedReports { get; set; } // สามารถเข้าถึงรายงานขั้นสูงได้ไหม
        public bool CanIntegratePOS { get; set; } // สามารถเชื่อมต่อ POS ได้ไหม

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}