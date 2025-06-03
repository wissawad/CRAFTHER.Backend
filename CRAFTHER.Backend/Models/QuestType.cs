using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.Models
{
    public class QuestType
    {
        [Key]
        public Guid QuestTypeId { get; set; } = Guid.NewGuid(); // Primary Key

        [Required]
        [MaxLength(50)]
        public string QuestTypeName { get; set; } = string.Empty; // ชื่อประเภทภารกิจ (เช่น "DAILY", "WEEKLY", "MAIN_STORY")

        [MaxLength(255)]
        public string? Description { get; set; } // คำอธิบายประเภทภารกิจ

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}