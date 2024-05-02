using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Grove.Data.Models;
using Grove.Logic.Abstraction;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Grove.Logic.Providers
{
    public class TokenProvider(IOptions<TokenOptions> options) : ITokenProvider
    {
        public string GenerateToken(UserEm user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(options.Value.SecretKey);

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
