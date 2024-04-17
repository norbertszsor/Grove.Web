using System.ComponentModel.DataAnnotations;

namespace Grove.Transfer.Commands
{
    public class UpdateProductCommand : CreateProductCommand, ICommand<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
