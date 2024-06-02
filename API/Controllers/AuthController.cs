using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var firstNameFromConfig = _configuration["DefaultUser:FirstName"];
            var lastNameFromConfig = _configuration["DefaultUser:LastName"];
            var idFromConfig = _configuration["DefaultUser:Id"];

            if (loginModel.FirstName == firstNameFromConfig && 
                loginModel.LastName == lastNameFromConfig &&
                loginModel.Id.Equals(idFromConfig))
            {
                var claims = new List<Claim>()
                {
                    new Claim("FirstName", firstNameFromConfig),
                    new Claim("LastName", lastNameFromConfig),
                    new Claim("Id", idFromConfig)
                };


                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JWT:TokenExpirationInMinutes"])),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }

            return Unauthorized();
        }
    }

}
