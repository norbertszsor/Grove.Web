namespace Grove.Transfer.BinaryFile.Data
{
    public class BinaryFileDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string FileName { get; set; }

        public byte Type { get; set; }

        public required byte[] Data { get; set; }
    }
}
