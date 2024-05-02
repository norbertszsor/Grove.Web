using Grove.Data;
using Grove.Logic.Abstraction;
using Grove.Transfer.Auth.Command;
using Grove.Transfer.Auth.Data;

namespace Grove.Logic.Services
{
    public class AuthService : IAuthService
    {
        public Task<AuthDto> AuthenticateAsync(AuthCommand command)
        {
            return Task.FromResult(new AuthDto()
            {
                Token = new Guid().ToString()
            });
        }
    }
}
