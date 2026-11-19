using AddisEats.Api.Models;

namespace AddisEats.Api.Services.MenuItemServices;

public class MenuItemService : IMenuItemService
{
    private readonly List<MenuItem> _menuItems = new List<MenuItem>
    {
       new MenuItem { Id = 1, Name = "Cheeseburger", Category = "Main Course", Price = 20m },
       new MenuItem { Id = 2, Name = "Burger", Category = "Main Course", Price = 15m }
    };
    public List<MenuItem> GetAll(string? category)
    {
        var items = _menuItems
            .Where(x => category == null || x.Category == category)
            .ToList();
        return items;
    }
    public MenuItem? GetById(int id)
    {
        return _menuItems.FirstOrDefault(m => m.Id == id);
    }
}