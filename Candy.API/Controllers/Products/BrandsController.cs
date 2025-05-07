using Candy.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Bll = Candy.BLL.Models.Products;
using Api = Candy.API.Models.DTO.Products;
using Candy.API.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace Candy.API.Controllers.Products;

[ApiController]
[Route("[controller]")]
public class BrandsController(IBrandService brandService) : ControllerBase
{
  private readonly IBrandService _brandService = brandService;

  [HttpGet]
  public IActionResult GetAll()
  {
    var brands = _brandService.GetAll();
    return Ok(brands.Select(b => b.ToApi()));
  }

  [HttpGet("{id:int}")]
  public IActionResult GetById(int id)
  {
    var brand = _brandService.Get(id);
    if (brand == null)
    {
      return NotFound();
    }
    return Ok(brand.ToApi());
  }

  [HttpPost]
  [Authorize(Roles = "Admin")]
  public IActionResult Create(Api::Brand brandDto)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    try
    {
      _brandService.Create(brandDto.ToBll());
      return CreatedAtAction(nameof(GetById), new { id = brandDto.Id }, brandDto);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPut("{id:int}")]
  [Authorize(Roles = "Admin")]
  public IActionResult Update(int id, Api::Brand brandDto)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    if (id != brandDto.Id)
    {
      return BadRequest("ID mismatch");
    }
    try
    {
      _brandService.Update(id, brandDto.ToBll());
      return NoContent();
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpDelete("{id:int}")]
  [Authorize(Roles = "Admin")]
  public IActionResult Delete(int id)
  {
    try
    {
      _brandService.Remove(id);
      return NoContent();
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}
