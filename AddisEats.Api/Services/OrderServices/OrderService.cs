using AddisEats.Api.Models;
using AddisEats.Api.DTOs;
using AddisEats.Api.Common;
using AddisEats.Api.Services.RestaurantServices;

namespace AddisEats.Api.Services.OrderServices;

public class OrderService : IOrderService
{
    private static readonly List<Order> _orders = new List<Order>();
    private static int _nextId = 1;

    private readonly IRestaurantService _restaurantService;
    public OrderService(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    public List<Order> GetAllOrders()
    {
        return _orders;
    }

    public Order? GetById(int id)
    {
        var order = _orders.FirstOrDefault(o => o.Id == id);
        return order;
    }

    public Result<Order> CreateOrder(CreateOrderDTO createDTO)
    {
        var restaurant = _restaurantService.GetById(createDTO.RestaurantId);
        if (restaurant is null)
        {
            return Result<Order>.Fail($"RESTAURANT_NOT_FOUND", $"Restaurant with Id {createDTO.RestaurantId} does not exist.", 404);
        }
        if (!restaurant.IsActive)
        {
            return Result<Order>.Fail($"RESTAURANT_NOT_ACTIVE", $"Restaurant with Id {createDTO.RestaurantId} is not active.", 409);
        }
        Order o = new Order
        {
            Id = _nextId++,
            RestaurantId = createDTO.RestaurantId,
            MenuItemId = createDTO.MenuItemId,
            CustomerName = createDTO.CustomerName,
            DeliveryAddress = createDTO.DeliveryAddress,
            CustomerPhone = createDTO.CustomerPhone,
            Quantity = createDTO.Quantity,
            TotalAmount = createDTO.TotalAmount
        };

        _orders.Add(o);
        return Result<Order>.OK(o);
    }
}