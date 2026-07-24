using JwtDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Hardcoded username and password
            if (model.Username == "admin" && model.Password == "123")
            {
                var claims = new[]
{
    new Claim(ClaimTypes.Name, model.Username),
    new Claim(ClaimTypes.Role, "Admin")
};

                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("ThisIsASecretKeyForJwtToken1234567890"));

                var creds = new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "MyAuthServer",
                    audience: "MyApiUsers",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: creds);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new
                {
                    Token = jwt
                });
            }

            return Unauthorized("Invalid Username or Password");
        }
    }
}