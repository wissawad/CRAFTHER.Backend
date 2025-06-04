using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.UnitOfMeasures
{
    public class CreateUnitOfMeasureDto
    {
        [Required(ErrorMessage = "Unit Name is required.")]
        [StringLength(50, ErrorMessage = "Unit Name cannot exceed 50 characters.")]
        public string UnitName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Abbreviation is required.")]
        [StringLength(10, ErrorMessage = "Abbreviation cannot exceed 10 characters.")]
        public string Abbreviation { get; set; } = string.Empty;

        [Required(ErrorMessage = "IsBaseUnit is required.")]
        public bool IsBaseUnit { get; set; }

        [Required(ErrorMessage = "Conversion Factor to Base Unit is required.")]
        [Range(0.000000001, double.MaxValue, ErrorMessage = "Conversion Factor must be greater than zero.")]
        public decimal ConversionFactorToBaseUnit { get; set; }

        [Required(ErrorMessage = "Unit Group ID is required.")]
        public Guid UnitGroupId { get; set; }
    }
}