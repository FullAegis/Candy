using Candy.API.Models.DTO.Users;
using Candy.BLL.Interfaces;
using Candy.BLL.Services;
using Candy.Mappers;
using Candy.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using Api = Candy.API.Models.DTO;
namespace Candy.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IUserService userService, TokenManager tokenManager) : ControllerBase {
  private readonly IUserService _userService = userService;
  private readonly TokenManager _tokenManager = tokenManager; 
  
  [HttpPost(nameof(Login))]
  public IActionResult Login(UserLoginFormDTO form) {
    if (ModelState.IsValid is false) {
      return BadRequest(ModelState);
    }
    Api::User user;
    try {
      user = _userService.Login(email: form.Email, password: form.Password).ToApi();
    } catch (Exception e) {
      return BadRequest(e.Message);
    }
    
    var token = _tokenManager.GenerateJwt(user);
    return Ok(token);
  }
  
  [HttpPost(nameof(Register))]
  public IActionResult Register(UserRegisterFormDTO form) {
    if (ModelState.IsValid is false) {
      return BadRequest(ModelState);
    } 
    
    try {
      _userService.Register(form.ToBll());
      return Ok("User Registration Success!");
    } catch (Exception e) {
      return BadRequest(e.Message);
    }
  }
}
