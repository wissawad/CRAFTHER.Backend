using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity; // ต้องเพิ่ม using นี้

namespace CRAFTHER.Backend.Models
{
    // สืบทอดมาจาก IdentityUser และกำหนดให้ใช้ Guid เป็น Primary Key ของ User
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(100)]
        public string UserDisplayName { get; set; } = string.Empty; // ชื่อที่ใช้แสดงในระบบ

        // Foreign Key เพื่อเชื่อมโยงกับ Organization
        [Required]
        public Guid OrganizationId { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public Organization? Organization { get; set; } // Navigation property

        // Properties เพิ่มเติมที่เราอาจต้องการ
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}