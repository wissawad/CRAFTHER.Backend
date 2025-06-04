namespace CRAFTHER.Backend.DTOs.UnitGroups
{
    public class UnitGroupResponseDto
    {
        public Guid UnitGroupId { get; set; }
        public string UnitGroupName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}