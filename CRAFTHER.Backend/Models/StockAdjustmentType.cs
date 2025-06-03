using System;
using System.ComponentModel.DataAnnotations;

namespace CRAFTHER.Backend.Models
{
    public class StockAdjustmentType
    {
        [Key]
        public Guid AdjustmentTypeId { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty; // เช่น "Receive", "Issue", "Adjustment (+)", "Adjustment (-)", "Production Output"

        [Required]
        [StringLength(10)]
        public string Effect { get; set; } = string.Empty; // "Increase" หรือ "Decrease"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}