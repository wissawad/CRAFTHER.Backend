using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        // Optional: ถ้าต้องการให้ผู้ใช้ระบุ OrganizationId ตอนลงทะเบียน
        // หรือจะให้ Admin เป็นคนผูก OrganizationId ให้ทีหลังก็ได้
        public Guid? OrganizationId { get; set; }
    }
}