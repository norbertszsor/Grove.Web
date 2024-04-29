using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class ProductEm : Entity
    {
        [MaxLength(128)]
        public required string Name { get; set; }

        [MaxLength(512)]
        public string? Description { get; set; }

        public decimal Price { get; set; }

        [MaxLength(1024)]
        public int Stock { get; set; }

        public bool IsAvailable { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid? RegionId { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid CategoryId { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid? ImageId { get; set; }

        [ForeignKey(nameof(ImageId))]
        public virtual BinaryFileEm? Image { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual ProductCategoryEm? Category { get; set; }

        [ForeignKey(nameof(RegionId))]
        public virtual ProductRegionEm? Region { get; set; }
    }
}
