using Candy.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ApiOrders = Candy.API.Models.DTO.Orders;
using Candy.API.Mappers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Candy.API.Controllers.Orders;

[ApiController]
[Route("[controller]")]
public class OrdersController(IOrderService orderService) : ControllerBase
{
  private readonly IOrderService _orderService = orderService;

  [HttpPost]
  [Authorize]
  public IActionResult PlaceOrder([FromBody] ApiOrders::PlaceOrderRequestDto orderRequest)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    // Get user ID from claims
    var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
    if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
    {
      return Unauthorized(); // Or a more specific error if user is authenticated but claim is missing/invalid
    }

    try
    {
      var order = orderRequest.ToBll();
      order.UserId = userId; // Set user ID from authenticated user
      _orderService.PlaceOrder(order);
      // Assuming PlaceOrder populates the order object with Id and details
      return CreatedAtAction(nameof(GetMyOrders), new { userId = userId }, order.ToApi());
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpGet("my")]
  [Authorize]
  public IActionResult GetMyOrders()
  {
    // Get user ID from claims
    var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
    if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
    {
      return Unauthorized();
    }

    try
    {
      var orders = _orderService.GetOrdersByUserId(userId);
      return Ok(orders.Select(o => o.ToApi()));
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPut("{id:int}/status")]
  [Authorize(Roles = "Admin")]
  public IActionResult UpdateStatus(int id, [FromBody] string status)
  {
    if (string.IsNullOrEmpty(status))
    {
      return BadRequest("Status cannot be empty.");
    }

    try
    {
      // Assuming the BLL service handles status parsing and validation
      _orderService.UpdateOrderStatus(id, status);
      return NoContent();
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}
