using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRAFTHER.Backend.Models
{
    public class UnitConversion
    {
        [Key]
        public Guid ConversionId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid OrganizationId { get; set; } // ผูกกับการแปลงหน่วยขององค์กรใด
        [ForeignKey("OrganizationId")]
        public Organization? Organization { get; set; }

        [Required]
        public Guid FromUnitId { get; set; } // หน่วยต้นทาง (เช่น กิโลกรัม)
        [ForeignKey("FromUnitId")]
        public UnitOfMeasure? FromUnit { get; set; }

        [Required]
        public Guid ToUnitId { get; set; } // หน่วยปลายทาง (เช่น กรัม)
        [ForeignKey("ToUnitId")]
        public UnitOfMeasure? ToUnit { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 8)")] // ใช้ Precision สูงขึ้นสำหรับอัตราส่วน
        public decimal ConversionFactor { get; set; } // อัตราส่วนการแปลง เช่น 1 kg = 1000 g, factor = 1000

        [MaxLength(255)] // เพิ่ม Remarks เข้าไป
        public string? Remarks { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}