using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.UnitGroups
{
    public class UpdateUnitGroupDto
    {
        [Required(ErrorMessage = "Unit Group ID is required for update.")]
        public Guid UnitGroupId { get; set; }

        // OrganizationId ถูกลบออกแล้ว เนื่องจาก UnitGroup เป็น Global

        [StringLength(50, ErrorMessage = "Unit Group Name cannot exceed 50 characters.")]
        public string? UnitGroupName { get; set; }

        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string? Description { get; set; }
    }
}