using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.Models
{
    public class Level
    {
        [Key]
        public Guid LevelId { get; set; } = Guid.NewGuid();

        [Required]
        public int LevelNumber { get; set; } // หมายเลข Level (เช่น 1, 2, 3)

        [Required]
        [MaxLength(100)]
        public string LevelName { get; set; } = string.Empty; // ชื่อ Level (เช่น "BOM Novice", "Recipe Master")

        [Required]
        public int RequiredPoints { get; set; } // คะแนนที่ต้องใช้เพื่อขึ้น Level นี้

        [MaxLength(500)]
        public string? Description { get; set; } // คำอธิบาย Level

        [MaxLength(255)]
        public string? BadgeImageUrl { get; set; } // URL รูปภาพ Badge/Icon ของ Level

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}