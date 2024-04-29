namespace Grove.Transfer.ProductRegion.Data
{
    public class ProductRegionDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public Guid? ImageId { get; set; }
    }
}
