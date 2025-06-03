using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRAFTHER.Backend.Models
{
    public class UserScore
    {
        [Key]
        public Guid UserScoreId { get; set; } = Guid.NewGuid();

        // Foreign Key สำหรับผู้ใช้งาน (Unique เพื่อให้ 1 User มี UserScore แค่ 1 Record)
        [Required]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }

        [Required]
        public int TotalPoints { get; set; } = 0; // คะแนนสะสมทั้งหมด

        [Required]
        public int CurrentLevel { get; set; } = 1; // ระดับปัจจุบัน (เริ่มต้นที่ 1)

        // Foreign Key สำหรับ Level ปัจจุบัน
        public Guid? LevelId { get; set; } // อาจจะ Nullable ได้ ถ้ายังไม่มี Level เริ่มต้น
        [ForeignKey(nameof(LevelId))]
        public Level? Level { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}