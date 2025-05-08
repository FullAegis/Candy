using Candy.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Bll = Candy.BLL.Models.Products;
using Api = Candy.API.Models.DTO.Products;
using Candy.API.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace Candy.API.Controllers.Products;

[ApiController]
[Route("[controller]")]
public class BrandsController(IBrandService brandService) : ControllerBase {
  private readonly IBrandService _brandService = brandService;

  [HttpGet]
  public IActionResult GetAll() => Ok(_brandService.GetAll().ToDto());
  
  [HttpGet("{id:int}")]
  public IActionResult GetById(int id) {
    try {
      var brand = _brandService.Get(id);
      return Ok(brand.ToDto());
    } catch (Exception e) {
      return NotFound(e.Message);
    }
  }
  //
  // [HttpPost]
  // [Authorize(Roles = "Admin")]
  // public ActionResult Create(Api::Brand brandDto) {
  //   if (ModelState.IsValid is false) {
  //     return BadRequest(ModelState);
  //   }
  //   try {
  //     _brandService.Create(brandDto.ToBll());
  //     return CreatedAtAction(nameof(GetById), new { id = brandDto.Id }, brandDto);
  //   } catch (Exception ex) {
  //     return BadRequest(ex.Message);
  //   }
  // }

  [HttpPost]
  [Authorize(Roles = "Admin")]
  public async Task<IActionResult> CreateAsync(Api::Brand brandDto) {
    if (ModelState.IsValid is false) {
      return BadRequest(ModelState);
    }
    var brandBll = await Task.Run(() => brandDto.ToBll());
    try {
      await Task.Run(() => _brandService.Create(brandBll));
      return CreatedAtAction(nameof(GetById), new { id = brandDto.Id }, brandDto);
    } catch (Exception ex) {
      return BadRequest(ex.Message);
    }
  }

  
  // [HttpPut("{id:int}")]
  // [Authorize(Roles = "Admin")]
  // public IActionResult Update(int id, Api::Brand brandDto) {
  //   if (ModelState.IsValid is false) {
  //     return BadRequest(ModelState);
  //   }
  //
  //   if (id != brandDto.Id) {
  //     return BadRequest("ID mismatch");
  //   }
  //
  //   try {
  //     _brandService.Update(id, brandDto.ToBll());
  //     return NoContent();
  //   } catch (Exception ex) {
  //     return BadRequest(ex.Message);
  //   }
  // }

  [HttpPut("{id:int}")]
  [Authorize(Roles = "Admin")]
  public async Task<IActionResult> UpdateAsync(int id, Api::Brand brandDto) {
    if (ModelState.IsValid is false) {
      return BadRequest(ModelState);
    } else if (id != brandDto.Id) {
      return BadRequest("ID mismatch");
    }

    var brandBll = await Task.Run(() => brandDto.ToBll());
    try {
      _brandService.Update(id, brandBll);
      return NoContent();
    } catch (Exception ex) {
      return BadRequest(ex.Message);
    }
  }
  
  // [HttpDelete("{id:int}")]
  // [Authorize(Roles = "Admin")]
  // public IActionResult Delete(int id) {
  //   try {
  //     _brandService.Remove(id);
  //     return NoContent();
  //   } catch (Exception ex) {
  //     return BadRequest(ex.Message);
  //   }
  // }
  
  [HttpDelete("{id:int}")]
  [Authorize(Roles = "Admin")]
  public async Task<IActionResult> DeleteAsync(int id) {
    try {
      await Task.Run(() => _brandService.Remove(id));
      return NoContent();
    } catch (Exception ex) {
      return BadRequest(ex.Message);
    }
  }
}
