using AuthService.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Exchange.WebServices.Auth.Validation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_verysecure_api_secret"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expirationDate = DateTime.UtcNow.AddHours(2);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.userName.ToString()),
                new Claim("Role", "Admin")
            };

            var token = new JwtSecurityToken(
                    audience: "apiAudience",
                    issuer: "apiIssuer",
                    claims: claims,
                    expires: expirationDate,
                    signingCredentials: credentials
                );

            /*var authToken = new AuthToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationDate = expirationDate
            };*/

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
