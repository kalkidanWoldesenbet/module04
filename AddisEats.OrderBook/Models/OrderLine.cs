namespace AddisEats.OrderBook.Models;

public record OrderLine
{
    public MenuItem Item { get; init; }
    public int Quantity { get; init; }

    public decimalSubtotal => Item.Price * Quantity;
    
    public OrderLine(MenuItem item, int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        }
        Item = item ?? throw new ArgumentNullException(nameof(item), "MenuItem cannot be null.");
        
        Quantity = quantity;
    }
}