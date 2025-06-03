using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CRAFTHER.Backend.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string ProductCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        [Required]
        public Guid ProductUnitId { get; set; }
        [ForeignKey("ProductUnitId")]
        public UnitOfMeasure? ProductUnit { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal CurrentStockQuantity { get; set; } = 0.0000m;

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal SellingPrice { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal CalculatedCost { get; set; }

        public bool IsSubProduct { get; set; }

        [Required]
        public Guid OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public Organization? Organization { get; set; }

        public ICollection<BOMItem>? BOMItems { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}