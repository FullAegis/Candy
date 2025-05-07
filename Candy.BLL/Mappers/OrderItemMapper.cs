namespace Candy.BLL.Mappers;

using Bll = Candy.BLL.Models.Orders;
using Dal = Candy.DAL.Models.Orders;
using Candy.BLL.Mappers;
using System.Linq;

public static class OrderItemMapper {
  public static Bll::OrderItem ToBll(this Dal::OrderItem orderItem) {
    return new Bll::OrderItem {
      Id = orderItem.Id,
      OrderId = orderItem.OrderId,
      CandyId = orderItem.CandyId,
      Quantity = orderItem.Quantity,
      UnitPrice = orderItem.UnitPrice,
      TaxRate = orderItem.TaxRate,
      ItemTaxAmount = orderItem.ItemTaxAmount,
      ItemPriceWithTax = orderItem.ItemPriceWithTax,
      Candy = orderItem.Candy.ToBll() // Assuming CandyMapper exists
    };
  }

  public static Dal::OrderItem ToDal(this Bll::OrderItem orderItem) {
    return new Dal::OrderItem {
      Id = orderItem.Id,
      OrderId = orderItem.OrderId,
      CandyId = orderItem.CandyId,
      Quantity = orderItem.Quantity,
      UnitPrice = orderItem.UnitPrice,
      TaxRate = orderItem.TaxRate,
      ItemTaxAmount = orderItem.ItemTaxAmount,
      ItemPriceWithTax = orderItem.ItemPriceWithTax,
      Candy = orderItem.Candy.ToDal() // Assuming CandyMapper exists
    };
  }
};