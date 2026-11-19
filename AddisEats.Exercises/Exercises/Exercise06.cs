
namespace AddisEats.Exercises;

public static class Exercise06
{
    public static void Run()
    {
        // VALUE TYPE: assigning an int copies its actual value.
        int originalNumber = 10;
        int copiedNumber = originalNumber;

        copiedNumber = 20;

        Console.WriteLine("===== VALUE TYPE =====");
        Console.WriteLine($"Original number: {originalNumber}");
        Console.WriteLine($"Copied number: {copiedNumber}");

        // REFERENCE TYPE: assigning a List copies its reference,
        // so both variables refer to the same list.
        List<string> originalMenu = new()
        {
            "Doro Wot",
            "Tibs"
        };

        List<string> copiedMenu = originalMenu;

        copiedMenu.Add("Shiro");

        Console.WriteLine("\n===== REFERENCE TYPE =====");
        Console.WriteLine(
            $"Original menu: {string.Join(", ", originalMenu)}");

        Console.WriteLine(
            $"Copied menu: {string.Join(", ", copiedMenu)}");
    }
}
