using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRAFTHER.Backend.Models
{
    public class Organization
    {
        [Key]
        public Guid OrganizationId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        public string OrganizationName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(500)] // เพิ่ม Address
        public string? Address { get; set; }

        [MaxLength(50)] // เพิ่ม PhoneNumber
        public string? PhoneNumber { get; set; }

        [MaxLength(255)] // เพิ่ม Email
        public string? Email { get; set; }

        [MaxLength(255)] // เพิ่ม Website
        public string? Website { get; set; }

        [Required] // Organization ต้องมี IndustryType เสมอ
        public Guid IndustryTypeId { get; set; }

        [ForeignKey(nameof(IndustryTypeId))]
        public OrganizationIndustryType? IndustryType { get; set; } // Navigation property

        [Required] // Organization ต้องมี SubscriptionPlan เสมอ
        public Guid PlanId { get; set; }

        [ForeignKey(nameof(PlanId))]
        public SubscriptionPlan? SubscriptionPlan { get; set; } // Navigation property

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property สำหรับ Users ใน Organization นี้ (จะเพิ่มเมื่อสร้าง User Model)
        // public ICollection<User>? Users { get; set; }
    }
}