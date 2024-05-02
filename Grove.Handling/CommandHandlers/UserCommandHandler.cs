using Grove.Handling.Abstraction;
using Grove.Logic.Abstraction;
using Grove.Transfer.User.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grove.Handling.CommandHandlers
{
    public class UserCommandHandler(IUserService userService) : ICommandHandler<LoginUserCommand, bool>
    {
        public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await userService.LogIn(request.Name, request.Password);
        }
    }
}
