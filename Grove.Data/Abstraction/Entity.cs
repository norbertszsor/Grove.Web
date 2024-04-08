namespace Grove.Data.Abstraction
{
    public abstract class Entity<TKey>
    {
        public required TKey Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
