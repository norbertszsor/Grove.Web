using System.ComponentModel.DataAnnotations;

namespace Grove.Transfer.Commands
{
    public class DeleteProductCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }
    }
}
