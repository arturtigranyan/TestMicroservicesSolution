using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Test.Core.Entities;
using Test.Core.RepositoryContracts;
using Test.Infrastructure.Data;

namespace Test.Infrastructure.Repositories;

public class OrderRepository(ApplicationDbContext context) : IOrderRepository
{
    public async Task<Order> CreateAsync(Order order)
    {
        context.Orders.Add(order);
        await context.SaveChangesAsync();
        return order;
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId)
    {
        return await context.Orders
            .Include(o => o.OrderItems)
            .Where(o => o.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await context.Orders
            .Include(o => o.OrderItems)
            .ToListAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(Guid orderId)
    {
        return await context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }

    public async Task<bool> DeleteAsync(Order order)
    {
        context.OrderItems.RemoveRange(order.OrderItems);
        context.Orders.Remove(order);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        // Remove existing order items
        var existingOrderItems = context.OrderItems.Where(oi => oi.OrderId == order.Id);
        context.OrderItems.RemoveRange(existingOrderItems);

        // Add new items
        context.OrderItems.AddRange(order.OrderItems);

        context.Orders.Update(order);
        await context.SaveChangesAsync();

        return order;
    }
}