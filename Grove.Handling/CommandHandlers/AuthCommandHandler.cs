using Grove.Handling.Abstraction;
using Grove.Logic.Abstraction;
using Grove.Transfer.Auth.Command;
using Grove.Transfer.Auth.Data;

namespace Grove.Handling.CommandHandlers
{
    public class AuthCommandHandler(IAuthService authService) : ICommandHandler<AuthCommand, AuthDto>
    {
        public async Task<AuthDto> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            return await authService.AuthenticateAsync(request);
        }
    }
}
