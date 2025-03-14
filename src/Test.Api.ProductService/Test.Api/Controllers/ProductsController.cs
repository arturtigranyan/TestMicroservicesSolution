using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Core.DTO;
using Test.Core.ServiceContracts;

namespace Test.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var product = await _productService.GetByIdAsync(id);
        return product is not null ? Ok(product) : NotFound();
    }

    //[Authorize(Roles = "Admin,User")]
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductRequest request)
    {
        var createdProduct = await _productService.CreateAsync(request);
        return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
    }

    //[Authorize(Roles = "Admin,User")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, ProductRequest request)
    {
        var product = await _productService.UpdateAsync(id, request);
        if (product is null)
            return NotFound();

        return Ok(product);
    }

    //[Authorize(Roles = "Admin,User")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var result = await _productService.DeleteAsync(id);
        return result ? NoContent() : NotFound();
    }

    //[Authorize(Roles = "Admin,User")]
    [HttpPatch("{productId:guid}/stock")]
    public async Task<IActionResult> UpdateStock(Guid productId, [FromBody] ProductStockUpdateRequest request)
    {
        await _productService.UpdateProductStockAsync(productId, request.Quantity);
        return NoContent();
    }
}