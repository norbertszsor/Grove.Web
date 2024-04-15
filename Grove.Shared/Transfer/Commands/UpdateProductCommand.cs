using System.ComponentModel.DataAnnotations;
using Grove.Shared.Abstraction;

namespace Grove.Shared.Transfer.Commands
{
    public class UpdateProductCommand : CreateProductCommand, ICommand<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
