using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class UserEm : Entity
    {
        public required string Email { get; set; }

        public required string Password { get; set; }

        public required byte UserType { get; set; }
    }
}
