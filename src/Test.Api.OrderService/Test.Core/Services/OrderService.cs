using AutoMapper;
using Test.Core.DTO;
using Test.Core.Entities;
using Test.Core.RepositoryContracts;
using Test.Core.ServiceContracts;

namespace Test.Core.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;
    private readonly IMapper mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        this.orderRepository = orderRepository;
        this.mapper = mapper;
    }

    public async Task<OrderResponse> CreateOrderAsync(OrderRequest request)
    {
        var order = mapper.Map<Order>(request);

        order.OrderItems = request.Items.Select(item => new OrderItem
        {
            ProductId = item.ProductId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice
        }).ToList();

        var createdOrder = await orderRepository.CreateAsync(order);

        return mapper.Map<OrderResponse>(createdOrder);
    }

    public async Task<IEnumerable<OrderResponse>> GetOrdersByUserIdAsync(Guid userId)
    {
        var orders = await orderRepository.GetOrdersByUserIdAsync(userId);
        return mapper.Map<IEnumerable<OrderResponse>>(orders);
    }

    public async Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
    {
        var orders = await orderRepository.GetAllOrdersAsync();
        return mapper.Map<IEnumerable<OrderResponse>>(orders);
    }

    public async Task DeleteOrderAsync(Guid orderId)
    {
        var order = await orderRepository.GetOrderByIdAsync(orderId)
            ?? throw new InvalidOperationException($"Order with id {orderId} not found.");

        await orderRepository.DeleteAsync(order);
    }

    public async Task<OrderResponse> UpdateOrderAsync(Guid orderId, OrderRequest request)
    {
        var existingOrder = await orderRepository.GetOrderByIdAsync(orderId)
            ?? throw new InvalidOperationException($"Order with id {orderId} not found.");

        existingOrder.UserId = request.UserId;

        existingOrder.OrderItems.Clear();

        foreach (var item in request.Items)
        {
            existingOrder.OrderItems.Add(new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            });
        }

        await orderRepository.UpdateAsync(existingOrder);

        return mapper.Map<OrderResponse>(existingOrder);
    }

    public async Task<OrderResponse?> GetOrderByIdAsync(Guid orderId)
    {
        var order = await orderRepository.GetOrderByIdAsync(orderId);
        return mapper.Map<OrderResponse?>(order);
    }
}