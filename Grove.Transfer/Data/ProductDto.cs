namespace Grove.Transfer.Data
{
    public class ProductDto
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        public byte Region { get; set; }

        public virtual required ProductCategoryDto Category { get; set; }
    }
}
