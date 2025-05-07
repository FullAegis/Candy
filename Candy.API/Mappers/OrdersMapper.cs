using BllOrders = Candy.BLL.Models.Orders;
using ApiOrders = Candy.API.Models.DTO.Orders;

namespace Candy.API.Mappers;

public static class OrdersMapper
{
  public static BllOrders::Order ToBll(this ApiOrders::PlaceOrderRequestDto orderDto)
  {
    return new BllOrders::Order
    {
      OrderItems = orderDto.OrderItems.Select(oi => oi.ToBll()).ToList()
    };
  }

  public static BllOrders::OrderItem ToBll(this ApiOrders::OrderItemDto orderItemDto)
  {
    return new BllOrders::OrderItem
    {
      ProductId = orderItemDto.ProductId,
      Quantity = orderItemDto.Quantity
    };
  }

  public static ApiOrders::OrderResponseDto ToApi(this BllOrders::Order order)
  {
    return new ApiOrders::OrderResponseDto
    {
      Id = order.Id,
      UserId = order.UserId,
      OrderDate = order.OrderDate,
      Status = order.Status.ToString(), // Assuming Status is an enum in BLL
      OrderItems = order.OrderItems.Select(oi => oi.ToApi()).ToList()
    };
  }

  public static ApiOrders::OrderItemResponseDto ToApi(this BllOrders::OrderItem orderItem)
  {
    return new ApiOrders::OrderItemResponseDto
    {
      Id = orderItem.Id,
      ProductId = orderItem.ProductId,
      ProductName = orderItem.Product.Name, // Assuming Product is navigation property in BLL
      Quantity = orderItem.Quantity,
      UnitPrice = orderItem.UnitPrice // Assuming UnitPrice is in BLL OrderItem
    };
  }
}
