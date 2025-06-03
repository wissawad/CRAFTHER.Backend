using System;
using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs
{
    public class AssignRoleDto
    {
        [Required]
        public Guid UserId { get; set; } // ID ของผู้ใช้งาน

        [Required]
        public Guid RoleId { get; set; } // ID ของบทบาท
    }
}