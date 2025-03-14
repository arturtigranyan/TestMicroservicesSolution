using Test.Core.DTO;

namespace Test.Core.ServiceContracts;

public interface IOrderService
{
    Task<OrderResponse> CreateOrderAsync(OrderRequest request);
    Task<IEnumerable<OrderResponse>> GetOrdersByUserIdAsync(Guid userId);
    Task<IEnumerable<OrderResponse>> GetAllOrdersAsync();
    Task<OrderResponse?> GetOrderByIdAsync(Guid orderId);
    Task DeleteOrderAsync(Guid orderId);
    Task<OrderResponse> UpdateOrderAsync(Guid orderId, OrderRequest request);
}