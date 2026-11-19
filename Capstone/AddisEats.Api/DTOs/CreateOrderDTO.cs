using System.ComponentModel.DataAnnotations;
using AddisEats.Api.Validation;

namespace AddisEats.Api.DTOs;

public record CreateOrderDTO(
    [Range(1, int.MaxValue, ErrorMessage = "Restaurant Id must be a positive integer.")]
    int RestaurantId,
    int MenuItemId,
    [Required(ErrorMessage = "Customer Name is required.")]
    string CustomerName,
    [StringLength(60, MinimumLength = 1, ErrorMessage = "Delivery Address must be between 1 and 60 characters.")]
    string DeliveryAddress,
    [Required(ErrorMessage = "Customer Phone is required.")]
    [EthiopianMobile]
    string CustomerPhone,
    [Range(1, 50, ErrorMessage = "Quantity must be between 1 and 50.")]
    int Quantity,
    [Required (ErrorMessage = "Total Amount is required.")]
    [ETBAmount]
    decimal TotalAmount
);