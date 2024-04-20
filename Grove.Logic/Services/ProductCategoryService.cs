using Grove.Data.Models;
using Grove.Infrastructure.Abstraction;
using Grove.Logic.Abstraction;
using Grove.Shared.Enums;
using Grove.Shared.Extensions;
using Grove.Transfer.ProductCategory.Command;
using Grove.Transfer.ProductCategory.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Grove.Logic.Services
{
    public class ProductCategoryService(IStorage storage, IReadOnlyStorage readOnlyStorage) : IProductCategoryService
    {
        public async Task<ProductCategoryDto> CreateProductCategoryAsync(CreateProductCategoryCommand command)
        {
            var id = await storage.InsertAsync(new ProductCategoryEm()
            {
                Name = command.Name,
                Type = (byte)command.Type
            });

            return await storage.ProductCategories.ProjectToType<ProductCategoryDto>().SingleOrDefaultAsync(x => x.Id == id) ??
                   throw GroveError.ProductCategoryNotCreated.Throw();
        }

        public async Task<ProductCategoryDto> UpdateProductCategoryAsync(UpdateProductCategoryCommand command)
        {
            var productCategory = await readOnlyStorage.ProductCategories.FirstOrDefaultAsync(x => x.Id == command.Id) ??
                                  throw GroveError.ProductCategoryNotFound.Throw();

            productCategory.Name = command.Name;
            productCategory.Type = (byte)command.Type;

            await storage.UpdateAsync(productCategory);

            return await storage.ProductCategories.ProjectToType<ProductCategoryDto>().SingleOrDefaultAsync(x => x.Id == command.Id) ??
                   throw GroveError.ProductCategoryNotUpdated.Throw();
        }

        public async Task DeleteProductCategoryAsync(DeleteProductCategoryCommand command)
        {
            var productCategory = await readOnlyStorage.ProductCategories.FirstOrDefaultAsync(x => x.Id == command.Id) ??
                                  throw GroveError.ProductCategoryNotFound.Throw();

            await storage.DeleteAsync(productCategory);
        }
    }
}
