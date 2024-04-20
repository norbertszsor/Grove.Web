using System.ComponentModel.DataAnnotations;
using Grove.Shared.Abstraction;
using Grove.Transfer.Product.Data;

namespace Grove.Transfer.Product.Command
{
    public class UpdateProductCommand : CreateProductCommand, ICommand<ProductDto>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
