namespace Candy.API.Mappers;
using Bll = Candy.BLL.Models.Products;
using Dto = Candy.API.Models.DTO.Products;

public static class ProductsMapper {
  #region Brand
  public static Bll::Brand ToBll(this Dto::Brand brand)
  => new Bll::Brand { Id = brand.Id, Name = brand.Name };
  
  public static Dto::Brand ToDal(this Bll::Brand brand)
  => new Dto::Brand { Id = brand.Id, Name = brand.Name };
  #endregion
  #region Category
  public static Bll::Category ToBll(this Dto::Category category)
  => new Bll::Category { Id = category.Id, Name = category.Name };
  
  public static Dto::Category ToDal(this Bll::Category category)
  => new Dto::Category { Id = category.Id, Name = category.Name };
  #endregion
  #region Candy
  public static Bll::Candy ToBll(this Dto::Candy candy) => new Bll::Candy
  { Id = candy.Id
  , Name = candy.Name
  , Brand = candy.Brand.ToBll()
  , Category = candy.Category.ToBll()
  , PriceBeforeTax = candy.PriceBeforeTax
  };
  
  public static Dto::Candy ToDal(this Bll::Candy candy) => new Dto::Candy
  { Id = candy.Id
  , Name = candy.Name
  , Brand = candy.Brand.ToDal()
  , Category = candy.Category.ToDal()
  , PriceBeforeTax = candy.PriceBeforeTax
  };
  #endregion

};
