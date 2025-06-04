using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.UnitGroups
{
    public class CreateUnitGroupDto
    {
        [Required(ErrorMessage = "Unit Group Name is required.")]
        [StringLength(50, ErrorMessage = "Unit Group Name cannot exceed 50 characters.")]
        public string UnitGroupName { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string? Description { get; set; }
    }
}