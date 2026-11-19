namespace AddisEats.Exercises;

public static class Exercise04
{
    public static void Run()
    {
        decimal subtotal = 1480.5m;
        decimal deliveryFee = 60m;

        decimal total = subtotal + deliveryFee;

        Console.WriteLine($"{"Subtotal:",-15} {subtota,10:N2}");
        Console.WriteLine($"{"Delivery Fee:",-15} {deliveryFee,10:N2}");
        Console.WriteLine($"{"Total:",-15} {total,10:N2}");
    }
}