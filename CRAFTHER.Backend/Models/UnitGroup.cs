using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.Models
{
    public class UnitGroup
    {
        [Key]
        public Guid UnitGroupId { get; set; } = Guid.NewGuid(); // Primary Key

        [Required]
        [MaxLength(50)]
        public string UnitGroupName { get; set; } = string.Empty; // ชื่อกลุ่มหน่วย (เช่น "ของเหลว", "ของแข็ง", "นับชิ้น")

        [MaxLength(255)]
        public string? Description { get; set; } // คำอธิบายกลุ่มหน่วย

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}