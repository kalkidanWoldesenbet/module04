
using System.Globalization;

namespace AddisEats.Exercises;

public static class Exercise08
{
    public static void Run()
    {
        Console.Write("Enter top-up amount in ETB: ");

        string? input = Console.ReadLine();

        if (!decimal.TryParse(
                input,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out decimal amount))
        {
            Console.WriteLine(
                "Invalid input. Please enter a valid number.");

            return;
        }

        if (amount <= 0m)
        {
            Console.WriteLine(
                "Amount must be greater than zero.");

            return;
        }

        Console.WriteLine(
            $"Valid top-up amount: {amount:N2} ETB");
    }
}
