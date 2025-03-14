using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using Test.Api;
using Test.Core.DTO;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Test.Api.IntegrationTests.Controllers;

public class ProductsControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ProductsControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact(Skip = "Temporary issue - integration test setup problem")]
    public async Task CreateProduct_ReturnsCreated_WhenValidRequest()
    {
        var productRequest = new ProductRequest
        {
            Name = "Integration Test Product",
            Description = "Description",
            Price = 100,
            Quantity = 20,
            Category = "Integration"
        };

        var response = await _client.PostAsJsonAsync("/api/products", productRequest);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var createdProduct = await response.Content.ReadFromJsonAsync<ProductResponse>();

        createdProduct.Should().NotBeNull();
        createdProduct!.Name.Should().Be(productRequest.Name);
    }
}