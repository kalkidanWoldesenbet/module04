using AddisEats.Api.Models;
using AddisEats.Api.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;
using AddisEats.Api.DTOs;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderController : ControllerBase
{

    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }


    [HttpGet("{id}")]
    public IActionResult GetOrderById(int id)
    {
        var order = _orderService.GetById(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderDTO creatDTO)
    {
        var result = _orderService.CreateOrder(creatDTO);

        if (!result.IsSuccess)
        {
            return Problem(
                title: result.Error?.Message,
                statusCode: result.Error?.Status,
                detail: result.Error?.Code
                );
        }

        return CreatedAtAction(
            nameof(GetOrderById),
            new { id = result.Value?.Id },
            result.Value
        );
    }
} 