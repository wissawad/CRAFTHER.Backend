using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.DTOs.UnitOfMeasures
{
    public class UpdateUnitOfMeasureDto
    {
        [Required(ErrorMessage = "Unit ID is required for update.")]
        public Guid UnitId { get; set; }

        [StringLength(50, ErrorMessage = "Unit Name cannot exceed 50 characters.")]
        public string? UnitName { get; set; }

        [StringLength(10, ErrorMessage = "Abbreviation cannot exceed 10 characters.")]
        public string? Abbreviation { get; set; }

        public bool? IsBaseUnit { get; set; } // Nullable because it might not always be updated

        [Range(0.000000001, double.MaxValue, ErrorMessage = "Conversion Factor must be greater than zero.")]
        public decimal? ConversionFactorToBaseUnit { get; set; } // Nullable

        public Guid? UnitGroupId { get; set; } // Nullable
    }
}