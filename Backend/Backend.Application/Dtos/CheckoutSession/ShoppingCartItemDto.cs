namespace Backend.Application.Dtos.checkoutSession;

public class ShoppingCartItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }
    public int Quantity { get; set; }
}
