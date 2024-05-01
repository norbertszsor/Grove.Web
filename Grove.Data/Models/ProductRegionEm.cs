using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class ProductRegionEm : Entity
    {
        public required string Name { get; set; }
        
        public required string Description { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid? ImageId { get; set; }

        [ForeignKey(nameof(ImageId))]
        public virtual BinaryFileEm? Image { get; set; }

        public virtual ICollection<ProductEm>? Products { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
