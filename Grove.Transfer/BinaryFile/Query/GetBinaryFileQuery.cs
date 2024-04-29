using System.ComponentModel.DataAnnotations;
using Grove.Shared.Abstraction;
using Grove.Transfer.BinaryFile.Data;

namespace Grove.Transfer.BinaryFile.Query
{
    public class GetBinaryFileQuery : IQuery<BinaryFileDto>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
