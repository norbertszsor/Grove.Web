using System.ComponentModel.DataAnnotations;
using Grove.Shared.Abstraction;

namespace Grove.Shared.Transfer.Commands
{
    public class DeleteProductCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
