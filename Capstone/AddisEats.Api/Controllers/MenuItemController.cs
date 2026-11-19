using AddisEats.Api.Models;
using Microsoft.AspNetCore.Mvc;
using AddisEats.Api.Services.MenuItemServices;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]

public class MenuItemController : ControllerBase
{
    private readonly IMenuItemService _menuItemService;

    public MenuItemController(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }

    [HttpGet]
    public IActionResult GetAll([FromQuery] string? category)
    {
        var menuItems = _menuItemService.GetAll(category);
        return Ok(menuItems);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var menuItem = _menuItemService.GetById(id);

        if (menuItem == null)
        {
            return NotFound();
        }
        return Ok(menuItem);
    }
}