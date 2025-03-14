namespace Test.Core.Entities;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public required string Category { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}