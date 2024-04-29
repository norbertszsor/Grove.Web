using System.ComponentModel.DataAnnotations;
using Grove.Shared.Abstraction;
using Grove.Transfer.BinaryFile.Data;

namespace Grove.Transfer.BinaryFile.Command
{
    public class CreateBinaryFileCommand : ICommand<BinaryFileDto>
    {
        [Required]
        public required string FileName { get; set; }

        [Required]
        public required byte[] Data { get; set; }
    }
}
