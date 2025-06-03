using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRAFTHER.Backend.Models
{
    public class UnitOfMeasure
    {
        [Key]
        public Guid UnitId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string UnitName { get; set; } = string.Empty; // ชื่อหน่วยวัด (เช่น "มิลลิลิตร", "กรัม", "ช้อนโต๊ะ")

        [Required]
        [MaxLength(10)]
        public string Abbreviation { get; set; } = string.Empty; // ตัวย่อ (เช่น "ml", "g", "tbsp")

        [Required]
        public bool IsBaseUnit { get; set; } // TRUE ถ้าเป็นหน่วยพื้นฐานสำหรับกลุ่มนั้นๆ (เช่น "ml" สำหรับของเหลว)

        [Required]
        public decimal ConversionFactorToBaseUnit { get; set; } = 1.0m; // อัตราส่วนการแปลงเป็นหน่วยพื้นฐาน (เช่น 1 ช้อนโต๊ะ = 15.0 ถ้า BaseUnit เป็น ml)

        [Required]
        public Guid UnitGroupId { get; set; } // เปลี่ยนจาก string เป็น Guid FK

        [ForeignKey(nameof(UnitGroupId))]
        public UnitGroup? UnitGroup { get; set; } // Navigation property

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}