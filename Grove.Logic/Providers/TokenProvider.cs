using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Grove.Data.Models;
using Grove.Logic.Abstraction;
using Grove.Shared.Enums;
using Grove.Shared.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Grove.Logic.Providers
{
    public class TokenProvider(IConfiguration configuration) : ITokenProvider
    {
        public string GenerateToken(UserEm user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenOptions = configuration.GetSection(nameof(TokenOptions)).Get<TokenOptions>() ??
                               throw GroveError.MissingSecretKey.Throw();
            
            var key = Encoding.ASCII.GetBytes(tokenOptions.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.UserType.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }

    public class TokenOptions
    {
        public required string SecretKey { get; set; }
    }
}
