using Test.Core.Entities;

namespace Test.Core.RepositoryContracts;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId);
    Task<Order?> GetOrderByIdAsync(Guid orderId);
    Task<Order> CreateAsync(Order order);
    Task<Order> UpdateAsync(Order order);
    Task<bool> DeleteAsync(Order order);
}