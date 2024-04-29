using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class ProductRegionEm : Entity
    {
        public required string Name { get; set; }
        
        public required string Description { get; set; }

        public Guid? ImageId { get; set; }

        public virtual BinaryFileEm? Image { get; set; }

        public virtual ICollection<ProductEm>? Products { get; set; }
    }
}
