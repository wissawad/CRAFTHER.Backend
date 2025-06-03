using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRAFTHER.Backend.Models
{
    public class Quest
    {
        [Key]
        public Guid QuestId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty; // ชื่อภารกิจ

        [MaxLength(500)]
        public string? Description { get; set; } // คำอธิบายภารกิจ

        [Required]
        public Guid QuestTypeId { get; set; }

        [ForeignKey(nameof(QuestTypeId))]
        public QuestType? QuestType { get; set; }

        [Required]
        public int RewardPoints { get; set; } // คะแนนที่ได้รับเมื่อทำภารกิจสำเร็จ

        [Required]
        public bool IsRepeatable { get; set; } // ทำซ้ำได้ไหม (สำหรับ Daily/Weekly)

        public DateTime? ExpiresAt { get; set; } // วันที่หมดอายุ (ถ้ามี)

        public int RequiredProgress { get; set; } = 1; // จำนวนครั้ง/ปริมาณที่ต้องทำ (เช่น สร้าง 5 สูตร, อัปเดตสต็อก 10 ครั้ง)

        [MaxLength(100)]
        public string? TargetFeature { get; set; } // ฟีเจอร์ที่เกี่ยวข้องกับภารกิจ (เช่น "CREATE_PRODUCT", "UPDATE_STOCK")

        [MaxLength(255)]
        public string? ImageUrl { get; set; } // URL รูปภาพ/ไอคอนของภารกิจ

        // Foreign Key เพื่อเชื่อมโยงกับ Organization (ถ้าภารกิจเฉพาะเจาะจงกับ Organization นั้นๆ)
        // ถ้าเป็น Global Quest (ทุกคนเห็น) อาจจะไม่ต้องมี OrganizationId หรือเป็น Nullable
        public Guid? OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public Organization? Organization { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}