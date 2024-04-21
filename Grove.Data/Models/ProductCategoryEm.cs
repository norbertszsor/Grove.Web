using System.ComponentModel.DataAnnotations;
using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class ProductCategoryEm : Entity
    {
        [MaxLength(128)]
        public required string Name { get; set; }

        public byte Type { get; set; }

        public virtual ICollection<ProductEm>? Products { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
