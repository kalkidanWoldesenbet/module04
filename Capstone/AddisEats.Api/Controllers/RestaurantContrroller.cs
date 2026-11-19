using AddisEats.Api.DTOs;
using AddisEats.Api.Services.RestaurantServices;
using Microsoft.AspNetCore.Mvc;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpGet("{id:int:min(1)}")]
    public IActionResult GetRestaurantsById(int id)
    {
        var restaurant = _restaurantService.GetById(id);

        if (restaurant == null)
        {
            return NotFound();
        }

        return Ok(restaurant);
    }

    [HttpGet]
    public IActionResult GetAllRestaurants([FromQuery] RestaurantQuery query)
    {
        var restaurants = _restaurantService.GetAll(query);
        return Ok(restaurants);
    }

    [HttpGet("active")]
    public IActionResult GetAllActiveRestaurants([FromQuery] RestaurantQuery query)
    {
        query.IsActive = true;

        var restaurants = _restaurantService.GetAll(query);

        return Ok(restaurants);
    }
    [HttpPost]
    public IActionResult CreateRestaurant([FromBody] CreateRestaurantDTO createDTO)
    {
        var createdRestaurant = _restaurantService.createRestaurant(createDTO);
        return CreatedAtAction(
            nameof(GetRestaurantsById),
            new { id = createdRestaurant.Id },
            createdRestaurant
        );
    }
}