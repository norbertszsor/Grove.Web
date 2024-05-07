using System.Text.Json;
using Grove.Shared.Enums;
using Grove.Shared.Extensions;
using Grove.Transfer.Auth.Data;
using Microsoft.AspNetCore.Http;

namespace Grove.Logic.Extensions
{
    public static class HttpContextExtension
    {
        public static AuthDto GetAuthDto(this HttpContext httpContext)
        {
            var authDto = JsonSerializer.Deserialize<AuthDto>(httpContext.Session.GetString("AuthDto") ?? string.Empty);

            return authDto ?? throw GroveError.Unauthorized.Throw();
        }
    }
}
