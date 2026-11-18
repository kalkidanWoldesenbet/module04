
using System.Globalization;

var topUps = new List<TopUp>();

const int numberOfCustomers = 5;

Console.WriteLine("====================================");
Console.WriteLine("       TELEBIRR TOP-UP SYSTEM");
Console.WriteLine("====================================");

for (int i = 0; i < numberOfCustomers; i++)
{
    Console.WriteLine($"\nCustomer {i + 1}");

    string? name = ReadRequiredText("Customer name: ");

    if (name is null)
    {
        Console.WriteLine("\nInput ended. Application stopped safely.");
        return;
    }

    string? network = ReadRequiredText(
        "Network (Ethio Telecom / Safaricom): ");

    if (network is null)
    {
        Console.WriteLine("\nInput ended. Application stopped safely.");
        return;
    }

    decimal amount;

    while (true)
    {
        Console.Write("Top-up amount (ETB): ");

        string? input = Console.ReadLine();

        if (input is null)
        {
            Console.WriteLine("\nInput ended. Application stopped safely.");
            return;
        }

        if (!decimal.TryParse(
                input,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out amount))
        {
            Console.WriteLine("Invalid input. Enter a valid number.");
            continue;
        }

        if (amount <= 0 || amount > 5000m)
        {
            Console.WriteLine(
                "Amount must be greater than 0 and at most 5,000 ETB.");
            continue;
        }

        break;
    }

    topUps.Add(new TopUp(name, network, amount));
}

// Display customer results

decimal grandTotal = 0m;

Console.WriteLine("\n\n================ TOP-UP REPORT ================\n");

Console.WriteLine(
    $"{"CUSTOMER",-18}" +
    $"{"NETWORK",-16}" +
    $"{"AMOUNT",12}" +
    $"{"BONUS",12}" +
    $"{"EXTRA",10}" +
    $"{"TOTAL",12}");

Console.WriteLine(new string('-', 80));

foreach (var topUp in topUps)
{
    decimal bonusRate = topUp.Network.Trim().ToLowerInvariant() switch
    {
        "ethio telecom" => 0.05m,
        "safaricom" => 0.03m,
        _ => 0m
    };

    decimal bonus = topUp.Amount * bonusRate;

    decimal extra = topUp.Amount >= 1000m ? 20m : 0m;

    decimal total = topUp.Amount + bonus + extra;

    grandTotal += total;

    Console.WriteLine(
        $"{Fit(topUp.CustomerName, 18),-18}" +
        $"{Fit(topUp.Network, 16),-16}" +
        $"{topUp.Amount,12:N2}" +
        $"{bonus,12:N2}" +
        $"{extra,10:N2}" +
        $"{total,12:N2}");
}

Console.WriteLine(new string('-', 80));

Console.WriteLine(
    $"{"GRAND TOTAL",-58}" +
    $"{grandTotal,22:N2} ETB");

Console.WriteLine("\nThank you for using TeleBirr Top-Up!");


// Input helper

static string? ReadRequiredText(string prompt)
{
    while (true)
    {
        Console.Write(prompt);

        string? input = Console.ReadLine();

        if (input is null)
            return null;

        if (!string.IsNullOrWhiteSpace(input))
            return input.Trim();

        Console.WriteLine("This field cannot be empty.");
    }
}

// Keeps the report columns aligned for long names.

static string Fit(string value, int width)
{
    return value.Length > width
        ? value[..(width - 3)] + "..."
        : value;
}

// Top-up model

record TopUp(string CustomerName, string Network, decimal Amount);
