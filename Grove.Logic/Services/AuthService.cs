using Grove.Infrastructure.Abstraction;
using Grove.Logic.Abstraction;
using Grove.Logic.Helpers;
using Grove.Shared.Enums;
using Grove.Shared.Extensions;
using Grove.Transfer.Auth.Command;
using Grove.Transfer.Auth.Data;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Grove.Logic.Services
{
    public class AuthService(
        IReadOnlyStorage readOnlyStorage,
        ITokenProvider tokenProvider,
        ProtectedSessionStorage protectedSessionStorage) : IAuthService
    {
        public async Task<AuthDto> AuthenticateAsync(AuthCommand command)
        {
            var user = await readOnlyStorage.Users.FirstOrDefaultAsync(x => x.Email == command.Email);

            if (user == null || !CryptHelper.Verify(command.Password, user.Password))
            {
                throw GroveError.AuthFailed.Throw();
            }

            var token = tokenProvider.GenerateToken(user);
            
            return new AuthDto
            {
                Id = user.Id,
                Email = user.Email,
                Type = (UserType)user.UserType,
                Token = token
            };
        }

        public async Task<bool> IsAuthenticatedAdminAsync()
        {
            var result = await protectedSessionStorage.GetAsync<AuthDto>(nameof(AuthDto));

            return result.Value is not null && result.Value.Type == UserType.Admin;
        }
    }
}
