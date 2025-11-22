namespace Core.Entities;

public class ShoppingCart
{
    //create properties
    public required string Id { get; set; }
    public List<CartItem> Items { get; set; } = [];

}
