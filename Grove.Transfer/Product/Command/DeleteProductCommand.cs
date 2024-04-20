using System.ComponentModel.DataAnnotations;
using Grove.Shared.Abstraction;

namespace Grove.Transfer.Product.Command
{
    public class DeleteProductCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
