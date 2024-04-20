using Grove.Data.Models;
using Grove.Infrastructure.Abstraction;
using Grove.Logic.Abstraction;
using Grove.Shared.Enums;
using Grove.Shared.Extensions;
using Grove.Transfer.Product.Command;
using Grove.Transfer.Product.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Grove.Logic.Services
{
    public class ProductService(IStorage storage, IReadOnlyStorage readOnlyStorage) : IProductService
    {
        public async Task<ProductDto> CreateProductAsync(CreateProductCommand command)
        {
            _ = await readOnlyStorage.ProductCategories.FirstOrDefaultAsync(x => x.Id == command.CategoryId) ??
                throw GroveError.ProductCategoryNotFound.Throw();

            var id = await storage.InsertAsync(new ProductEm()
            {
                Name = command.Name,
                CategoryId = command.CategoryId,
                CreatedAt = DateTime.UtcNow,
                Description = command.Description,
                Price = command.Price,
                Region = (byte)command.Region
            });

            return await storage.Products.ProjectToType<ProductDto>().SingleOrDefaultAsync(x => x.Id == id) ??
                   throw GroveError.ProductNotCreated.Throw();
        }

        public async Task<ProductDto> UpdateProductAsync(UpdateProductCommand command)
        {
            _ = await readOnlyStorage.ProductCategories.FirstOrDefaultAsync(x => x.Id == command.CategoryId) ?? 
                throw GroveError.ProductCategoryNotFound.Throw();

            var product = await readOnlyStorage.Products.FirstOrDefaultAsync(x => x.Id == command.Id) ??
                          throw GroveError.ProductNotFound.Throw();

            product.Name = command.Name;
            product.CategoryId = command.CategoryId;
            product.Description = command.Description;
            product.Price = command.Price;
            product.Region = (byte)command.Region;

            await storage.UpdateAsync(product);

            return await storage.Products.ProjectToType<ProductDto>().SingleOrDefaultAsync(x => x.Id == command.Id) ??
                   throw GroveError.ProductNotUpdated.Throw();
        }

        public async Task DeleteProductAsync(DeleteProductCommand command)
        {
            var product = await readOnlyStorage.Products.FirstOrDefaultAsync(x => x.Id == command.Id) ??
                          throw GroveError.ProductNotFound.Throw();

            await storage.DeleteAsync(product);
        }
    }
}
