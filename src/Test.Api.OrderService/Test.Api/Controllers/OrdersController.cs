using Microsoft.AspNetCore.Mvc;
using Test.Core.ServiceContracts;
using Test.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Serilog;

namespace Test.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(IOrderService orderService) : ControllerBase
{
    [HttpPost]
    //[Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
    {
        var order = await orderService.CreateOrderAsync(request);
        Log.Information("Order created successfully: {@Order}", order);
        return CreatedAtAction(nameof(GetOrderById), new { orderId = order.OrderId }, order);
    }

    [HttpGet]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("user/{userId:guid}")]
    //[Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> GetOrdersByUser(Guid userId)
    {
        var orders = await orderService.GetOrdersByUserIdAsync(userId);
        return Ok(orders);
    }

    [HttpGet("{orderId:guid}")]
    //[Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> GetOrderById(Guid orderId)
    {
        var order = await orderService.GetOrderByIdAsync(orderId);

        if (order == null)
        {
            Log.Warning("Order not found: {OrderId}", orderId);
            return NotFound();
        }

        return Ok(order);
    }

    [HttpDelete("{orderId:guid}")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteOrder(Guid orderId)
    {
        await orderService.DeleteOrderAsync(orderId);
        Log.Information("Order deleted successfully: {OrderId}", orderId);
        return NoContent();
    }

    [HttpPut("{orderId:guid}")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateOrder(Guid orderId, [FromBody] OrderRequest request)
    {
        var updatedOrder = await orderService.UpdateOrderAsync(orderId, request);
        Log.Information("Order updated successfully: {@UpdatedOrder}", updatedOrder);
        return Ok(updatedOrder);
    }
}