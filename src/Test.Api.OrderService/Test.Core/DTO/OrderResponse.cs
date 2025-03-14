namespace Test.Core.DTO;

public class OrderResponse
{
    public Guid OrderId { get; set; }
    public Guid UserId { get; set; }
    public List<OrderItemResponse> Items { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}

public class OrderItemResponse
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}