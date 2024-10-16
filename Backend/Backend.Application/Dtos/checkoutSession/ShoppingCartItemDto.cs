namespace Backend.Application.Dtos.checkoutSession;

public class ShoppingCartItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int Quantity { get; set; }
}
