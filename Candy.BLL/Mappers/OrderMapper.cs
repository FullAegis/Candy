namespace Candy.BLL.Mappers;

using Bll = Candy.BLL.Models.Orders;
using Dal = Candy.DAL.Models.Orders;
using Candy.BLL.Mappers;
using System.Linq;

public static class OrderMapper {
  public static Bll::Order ToBll(this Dal::Order order) => new Bll::Order
  {
    Id = order.Id
  , UserId = order.UserId
  , OrderDate = order.OrderDate
  , Status = order.Status
  , TotalTaxAmount = order.TotalTaxAmount
  , TotalPriceWithTax = order.TotalPriceWithTax
  , OrderItems = order.OrderItems.Select(orderItem => orderItem.ToBll()).ToList()
  };

  public static Dal::Order ToDal(this Bll::Order order) => new Dal::Order
  {
    Id = order.Id
  , UserId = order.UserId
  , OrderDate = order.OrderDate
  , Status = order.Status
  , TotalTaxAmount = order.TotalTaxAmount
  , TotalPriceWithTax = order.TotalPriceWithTax
  , OrderItems = order.OrderItems.Select(orderItem => orderItem.ToDal()).ToList()
  };
};