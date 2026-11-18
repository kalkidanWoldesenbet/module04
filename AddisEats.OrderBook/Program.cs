
using AddisEats.OrderBook.Models;
using AddisEats.OrderBook.Services;

// 1. Create menu items

var doroWot = new MenuItem(
    1, "Doro Wot", "Traditional", 450m);

var tibs = new MenuItem(
    2, "Tibs", "Traditional", 350m);

var shiro = new MenuItem(
    3, "Shiro", "Vegetarian", 180m);

var cocaCola = new MenuItem(
    4, "Coca Cola", "Drinks", 60m);

var juice = new MenuItem(
    5, "Fresh Juice", "Drinks", 120m);


// 2. Create the order book

var orderBook = new OrderBook();


// 3. Create and add orders

var orders = new List<Order>
{
    new Order("Abel", "Bole", new List<OrderLine>
    {
        new OrderLine(doroWot, 2),
        new OrderLine(juice, 2)
    }),

    new Order("Hana", "Piassa", new List<OrderLine>
    {
        new OrderLine(shiro, 3),
        new OrderLine(cocaCola, 2)
    }),

    new Order("Meron", "Bole", new List<OrderLine>
    {
        new OrderLine(tibs, 3),
        new OrderLine(juice, 1)
    }),

    new Order("Dawit", "Kazanchis", new List<OrderLine>
    {
        new OrderLine(doroWot, 1),
        new OrderLine(cocaCola, 3)
    }),

    new Order("Sara", "Bole", new List<OrderLine>
    {
        new OrderLine(shiro, 2),
        new OrderLine(juice, 3)
    }),

    new Order("Yonas", "Piassa", new List<OrderLine>
    {
        new OrderLine(tibs, 2),
        new OrderLine(cocaCola, 2)
    })
};

orders.ForEach(order => orderBook.AddOrder(order));


// 4. Display orders for Bole

Console.WriteLine("===== BOLE ORDERS =====");

var boleOrders = orderBook.GetOrdersByArea("Bole");

Console.WriteLine(
    string.Join(
        Environment.NewLine,
        boleOrders.Select(order =>
            $"{order.Customer,-15} {order.Area,-12} " +
            $"{order.Total,10:N2} ETB")));


// 5. Display total revenue

Console.WriteLine("\n===== TOTAL REVENUE =====");

Console.WriteLine(
    $"{orderBook.GetTotalRevenue():N2} ETB");


// 6. Display busiest category

Console.WriteLine("\n===== BUSIEST CATEGORY =====");

Console.WriteLine(
    orderBook.GetBusiestCategory() ?? "No orders yet");


// 7. Display page 1

Console.WriteLine("\n===== ORDER BOOK - PAGE 1 =====");

var page1 = orderBook.GetPage(1);

Console.WriteLine(
    string.Join(
        Environment.NewLine,
        page1.Select(order =>
            $"{order.Customer,-15} {order.Total,10:N2} ETB")));


// 8. Display page 2

Console.WriteLine("\n===== ORDER BOOK - PAGE 2 =====");

var page2 = orderBook.GetPage(2);

Console.WriteLine(
    string.Join(
        Environment.NewLine,
        page2.Select(order =>
            $"{order.Customer,-15} {order.Total,10:N2} ETB")));
