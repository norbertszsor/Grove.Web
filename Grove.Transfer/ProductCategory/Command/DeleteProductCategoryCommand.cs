using Grove.Shared.Abstraction;

namespace Grove.Transfer.ProductCategory.Command
{
    public class DeleteProductCategoryCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
