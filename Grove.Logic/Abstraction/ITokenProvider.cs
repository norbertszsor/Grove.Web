using Grove.Data.Models;

namespace Grove.Logic.Abstraction
{
    public interface ITokenProvider
    {
        string GenerateToken(UserEm user);
    }
}
