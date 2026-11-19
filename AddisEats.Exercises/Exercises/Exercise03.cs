
namespace AddisEats.Exercises;

public static class Exercise03
{
    public static void Run()
    {
        bool isAvailable = true;
        byte tableNumber = 12;
        sbyte temperature = 25;
        short dailyOrders = 250;
        ushort availableTables = 40;
        int restaurantId = 1001;
        uint totalCustomers = 500;
        long annualRevenue = 1500000L;
        ulong totalTransactions = 250000UL;
        char categoryCode = 'T';
        float customerRating = 4.5f;
        double deliveryDistance = 3.75;
        decimal foodPrice = 450.50m;

        Console.WriteLine($"Boolean: {isAvailable}");
        Console.WriteLine($"Byte: {tableNumber}");
        Console.WriteLine($"SByte: {temperature}");
        Console.WriteLine($"Short: {dailyOrders}");
        Console.WriteLine($"UShort: {availableTables}");
        Console.WriteLine($"Int32: {restaurantId}");
        Console.WriteLine($"UInt32: {totalCustomers}");
        Console.WriteLine($"Int64: {annualRevenue}");
        Console.WriteLine($"UInt64: {totalTransactions}");
        Console.WriteLine($"Char: {categoryCode}");
        Console.WriteLine($"Single: {customerRating}");
        Console.WriteLine($"Double: {deliveryDistance}");
        Console.WriteLine($"Decimal: {foodPrice}");
    }
}
