using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRAFTHER.Backend.Models
{
    public class UserQuest
    {
        [Key]
        public Guid UserQuestId { get; set; } = Guid.NewGuid();

        // Foreign Key สำหรับผู้ใช้งาน
        [Required]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }

        // Foreign Key สำหรับภารกิจ
        [Required]
        public Guid QuestId { get; set; }
        [ForeignKey(nameof(QuestId))]
        public Quest? Quest { get; set; }

        [Required]
        public int CurrentProgress { get; set; } = 0; // ความคืบหน้าปัจจุบันของภารกิจ

        [Required]
        public bool IsCompleted { get; set; } = false; // ทำภารกิจสำเร็จแล้วหรือยัง

        public DateTime? CompletedAt { get; set; } // วันที่ทำภารกิจสำเร็จ

        public DateTime AssignedAt { get; set; } = DateTime.UtcNow; // วันที่ได้รับภารกิจ

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}