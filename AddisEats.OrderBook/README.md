
# Addis Eats Order Book

A C# console application that manages restaurant orders using
records, classes, collections, and LINQ.

## Features

- Menu items with ID, name, category, and price.
- Order lines with item quantities.
- Orders with computed totals.
- Manage multiple orders using an OrderBook.
- Filter orders by area.
- Sort orders by total in descending order.
- Calculate total restaurant revenue.
- Identify the busiest menu category.
- Paginate orders with five orders per page.

## Technologies

- C#
- .NET
- LINQ
- Records and Classes
- Generic Collections

## Validation

- Rejects non-positive menu prices.
- Rejects non-positive order quantities.
- Rejects invalid page numbers.

## How to Run

```bash
dotnet run
```

## Project Structure

- Models/MenuItem.cs
- Models/OrderLine.cs
- Models/Order.cs
- Services/OrderBook.cs
- Program.cs
