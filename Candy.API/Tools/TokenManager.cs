using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Candy.Tools {
  public class TokenManager {
    private readonly IConfiguration _config;
    private readonly string _secret;
    private readonly string _issuer;
    private readonly string _audience;

    public TokenManager(IConfiguration config) {
      _config = config;
      _secret = _config["jwt:key"];
      _issuer = config["jwt:issuer"];
      _audience = config["jwt:audience"];
    }
    
    public string GenerateJwt(dynamic user, int expirationDate = 1) {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

      var now = DateTime.Now;
      var myclaims = new Claim[] {
        new(ClaimTypes.Sid, user.Id.ToString())
      , new(ClaimTypes.GivenName, user.Email ?? "NomInconnu")
      , new(ClaimTypes.Expiration, now.AddHours(expirationDate).ToString(), ClaimValueTypes.DateTime)
      };

      var token = new JwtSecurityToken( claims:             myclaims            
                                      , expires:            now.AddHours(expirationDate)
                                      , signingCredentials: credentials
                                      , audience:           _audience
                                      , issuer:             _issuer
                                      );
      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  };
}
