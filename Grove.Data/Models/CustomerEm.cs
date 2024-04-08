using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class CustomerEm : Entity<Guid>
    {
        public required string Name { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public bool IsCompany { get; set; }
    }
}
