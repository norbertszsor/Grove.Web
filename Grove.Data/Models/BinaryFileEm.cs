using Grove.Data.Abstraction;

namespace Grove.Data.Models
{
    public class BinaryFileEm : Entity
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string FileName { get; set; }

        public byte Type { get; set; }

        public required byte[] Data { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
