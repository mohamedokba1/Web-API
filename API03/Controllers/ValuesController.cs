using API03.Data;
using API03.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly UserManager<ApplicationUser> _manager;
        public ValuesController(UserManager<ApplicationUser> manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("GetInfoForManager")]
        [Authorize(Policy = "AdminOnly")]
        public string[] GetInfoForManager()
        {
            return new[] { "Value1 For Admin only", "Value2  For Admin only" };
        }

        [HttpGet]
        [Route("GetInfoForUser")]
        [Authorize(Policy = "UserOrAdmin")]
        public string[] GetInfoForUser()
        {
            return new[] { "value1 For Admin Or User", "Value2 For Admin Or User" };
        }

        [HttpGet]
        [Route("GetAuthUser")]
        [Authorize]
        public IActionResult GetUser()
        {
            var userName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var usercolor = User.Claims.FirstOrDefault(c => c.Type == "Color");
            return Ok(new userData(userName?.Value, usercolor?.Value, userEmail?.Value));
        }
    }
}
