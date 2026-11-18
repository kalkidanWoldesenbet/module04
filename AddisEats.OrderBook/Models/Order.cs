namespace AddisEats.OrderBook.Models;

public class Order
{
    public string Customer { get; }
    public string Area { get; }
    public List<OrderLine> Lines { get; }

    public decimal Total => Lines.Sum(line => line.Subtotal);

    public Order(
        string customer,
        string area,
        List<OrderLine> lines)
    {
        Customer = customer;
        Area = area;
        Lines = lines ?? throw new ArgumentException(
            "Order lines cannot be null.",
            nameof(lines));
    }
}
