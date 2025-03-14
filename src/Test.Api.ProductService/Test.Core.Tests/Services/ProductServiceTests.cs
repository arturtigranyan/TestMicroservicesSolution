using AutoMapper;
using Moq;
using FluentAssertions;
using Test.Core.DTO;
using Test.Core.Entities;
using Test.Core.RepositoryContracts;
using Test.Core.Services;

namespace Test.Core.Tests.Services;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> productRepositoryMock;
    private readonly IMapper mapper;
    private readonly ProductService productService;

    public ProductServiceTests()
    {
        productRepositoryMock = new Mock<IProductRepository>();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ProductRequest, Product>();
            cfg.CreateMap<Product, ProductResponse>();
        });

        mapper = mapperConfig.CreateMapper();

        productService = new ProductService(productRepositoryMock.Object, mapper);
    }

    [Fact]
    public async Task CreateProductAsync_ShouldCreateProduct_WhenProductRequestIsValid()
    {
        // Arrange
        var productRequest = new ProductRequest
        {
            Name = "Test Product",
            Description = "Test Description",
            Price = 50,
            Quantity = 10,
            Category = "General"
        };

        productRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Product>()))
                             .ReturnsAsync((Product p) => p);

        // Act
        var result = await productService.CreateAsync(productRequest);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(productRequest.Name);
        productRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Product>()), Times.Once);
    }
}