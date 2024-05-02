using Grove.Shared.Enums;

namespace Grove.Transfer.Auth.Data
{
    public class AuthDto
    {
        public required Guid Id { get; set; }

        public required string Email { get; set; }

        public UserType Type { get; set; }

        public required string Token { get; set; }
    }
}
