using Grove.Infrastructure.Abstraction;
using Grove.Logic.Abstraction;
using Grove.Logic.Extensions;
using Grove.Logic.Helpers;
using Grove.Shared.Enums;
using Grove.Shared.Extensions;
using Grove.Transfer.Auth.Command;
using Grove.Transfer.Auth.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Grove.Logic.Services
{
    public class AuthService(
        IReadOnlyStorage readOnlyStorage,
        ITokenProvider tokenProvider,
        IHttpContextAccessor httpContextAccessor) : IAuthService
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
            var authDto = httpContextAccessor.HttpContext?.GetAuthDto();

            return await Task.FromResult(authDto?.Type == UserType.Admin);
        }
    }
}
