using Test.Core.DTO;

namespace Test.Core.ServiceContracts;

public interface IProductService
{
    Task<IEnumerable<ProductResponse>> GetAllAsync();
    Task<ProductResponse?> GetByIdAsync(Guid id);
    Task<ProductResponse> CreateAsync(ProductRequest request);
    Task<ProductResponse?> UpdateAsync(Guid id, ProductRequest request);
    Task<bool> DeleteAsync(Guid id);

    Task UpdateProductStockAsync(Guid productId, int quantity);
}