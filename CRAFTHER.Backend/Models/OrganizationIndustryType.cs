using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.Models
{
    public class OrganizationIndustryType
    {
        [Key]
        public Guid IndustryTypeId { get; set; } = Guid.NewGuid(); // Primary Key

        [Required]
        [MaxLength(100)]
        public string IndustryTypeName { get; set; } = string.Empty; // ชื่อประเภทอุตสาหกรรม (เช่น "ร้านอาหาร", "คาเฟ่", "งานฝีมือ")

        [MaxLength(500)]
        public string? Description { get; set; } // คำอธิบายเพิ่มเติม

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}