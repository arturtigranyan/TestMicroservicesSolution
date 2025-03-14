using AutoMapper;
using Test.Core.DTO;
using Test.Core.Entities;
using Test.Core.RepositoryContracts;
using Test.Core.ServiceContracts;

namespace Test.Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductResponse>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductResponse>>(products);
    }

    public async Task<ProductResponse?> GetByIdAsync(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);
        return product is null ? null : _mapper.Map<ProductResponse>(product);
    }

    public async Task<ProductResponse> CreateAsync(ProductRequest request)
    {
        var product = _mapper.Map<Product>(request);
        var result = await _repository.AddAsync(product);
        return _mapper.Map<ProductResponse>(result);
    }

    public async Task<ProductResponse?> UpdateAsync(Guid id, ProductRequest request)
    {
        var existingProduct = await _repository.GetByIdAsync(id);
        if (existingProduct is null)
            return null;

        _mapper.Map(request, existingProduct);
        var updatedProduct = await _repository.UpdateAsync(existingProduct);

        return _mapper.Map<ProductResponse>(updatedProduct);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task UpdateProductStockAsync(Guid productId, int quantity)
    {
        await _repository.UpdateProductStockAsync(productId, quantity);
    }
}