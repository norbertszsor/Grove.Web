using Grove.Shared.Abstraction;
using System.ComponentModel.DataAnnotations;
using Grove.Transfer.Auth.Data;

namespace Grove.Transfer.Auth.Command
{
    public class AuthCommand : ICommand<AuthDto>
    {
        [Required]
        [MaxLength(20)]
        public required string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Password { get; set; }
    }
}
