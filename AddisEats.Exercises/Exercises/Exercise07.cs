
namespace AddisEats.Exercises;

public static class Exercise07
{
    public static void Run()
    {
        string? customerName = null;

        // 1. Explicit null check
        if (customerName is null)
        {
            Console.WriteLine("Explicit null check: 0");
        }
        else
        {
            Console.WriteLine(
                $"Explicit null check: {customerName.Length}");
        }

        // 2. Null-coalescing operator
        int lengthWithCoalescing =
            (customerName ?? string.Empty).Length;

        Console.WriteLine(
            $"Null-coalescing (??): {lengthWithCoalescing}");

        // 3. Null-conditional operator
        int? lengthWithConditional = customerName?.Length;

        Console.WriteLine(
            $"Null-conditional (?.): " +
            $"{lengthWithConditional?.ToString() ?? "null"}");
    }
}
