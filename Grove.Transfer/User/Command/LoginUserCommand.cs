using Grove.Shared.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Grove.Transfer.User.Command
{
    public class LoginUserCommand : ICommand<bool>
    {
        [Required]
        [MaxLength(20)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public required string Password { get; set; }
    }
}
