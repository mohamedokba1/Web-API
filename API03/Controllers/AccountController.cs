using API03.Data;
using API03.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API03.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _manager;
    private readonly IConfiguration _configuration;

    public AccountController(UserManager<ApplicationUser> manager, IConfiguration configuration)
    {
        _manager = manager;
        _configuration = configuration;
    }


    [HttpPost]
    [Route("User")]
    public async Task<IActionResult> RegisterUser(RegisterDto values)
    {
        var error = await Register(values, "User");
        return error.Count() == 0 ? Ok() : BadRequest(error);
    }


    [HttpPost]
    [Route("Admin")]
    public async Task<IActionResult> RegisterAdmin(RegisterDto values)
    {
        var error = await Register(values, "Admin");
        return error.Count() == 0 ? Ok() : BadRequest(error);
    }
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginDto credinals)
    {
        var user = await _manager.FindByNameAsync(credinals.Name);
        if (user == null)
        {
            return Unauthorized();
        }
        var result = await _manager.CheckPasswordAsync(user, credinals.Password);
        if (result == false)
        {
            return Unauthorized();
        }
        var claims = await _manager.GetClaimsAsync(user);
        var token = GetToken(claims);
        return Ok(token);
    }


    private async Task<IEnumerable<IdentityError>> Register(RegisterDto values, string Role)
    {
        var user = new ApplicationUser()
        {
            Email = values.Email,
            UserName = values.UserName,
            FavouriteColor = values.FaviouritColor
        };

        var result = await _manager.CreateAsync(user, values.Password);
        if (!result.Succeeded)
        {
            return result.Errors;

        }
        var Claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, values.UserName),
            new Claim(ClaimTypes.Sid, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("Color", user.FavouriteColor),
            new Claim(ClaimTypes.Role, Role),
        };

        await _manager.AddClaimsAsync(user, Claims);
        return result.Errors;
    }


    private string GetToken(IList<Claim> claims)
    {
        var SecurityKey = new SymmetricSecurityKey(
            Encoding.ASCII
            .GetBytes(_configuration.GetValue<string>("Authentication:SecurityKey") ?? ""));
        var signingCrdenials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: signingCrdenials
            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
