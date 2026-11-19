
namespace AddisEats.Exercises;

public static class Exercise05
{
    public static void Run()
    {
        int firstNumber = 7;
        int secondNumber = 2;

        int integerResult = firstNumber / secondNumber;

        decimal decimalResult =
            (decimal)firstNumber / secondNumber;

        Console.WriteLine($"Integer division: {integerResult}");
        Console.WriteLine($"Decimal division: {decimalResult}");

    }
}
