using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs
{
    public class RoleDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string RoleName { get; set; } = string.Empty;
    }
}