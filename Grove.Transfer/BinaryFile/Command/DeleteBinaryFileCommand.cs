using Grove.Shared.Abstraction;

namespace Grove.Transfer.BinaryFile.Command
{
    public class DeleteBinaryFileCommand : ICommand
    {
        public Guid? Id { get; set; }
    }
}
