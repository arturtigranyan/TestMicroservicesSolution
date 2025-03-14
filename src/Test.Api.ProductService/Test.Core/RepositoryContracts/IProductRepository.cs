using Test.Core.Entities;

namespace Test.Core.RepositoryContracts;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task<Product> AddAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<bool> DeleteAsync(Guid id);

    Task UpdateProductStockAsync(Guid productId, int quantity);
}