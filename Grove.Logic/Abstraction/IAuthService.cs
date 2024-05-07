using Grove.Transfer.Auth.Command;
using Grove.Transfer.Auth.Data;

namespace Grove.Logic.Abstraction
{
    public interface IAuthService
    {
        Task<AuthDto> AuthenticateAsync(AuthCommand command);

        Task<bool> IsAuthenticatedAdminAsync();
    }
}
