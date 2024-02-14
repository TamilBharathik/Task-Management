
using Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] User cd)
        {
            if (IsValidUser(cd.Username, cd.Password))
            {
                return Ok(new { Message = "Login successful" });
            }

            return Unauthorized(new { Message = "Check your credentials" });
        }
        private bool IsValidUser(string username, string password)
        {
            return (username == "Tamil" && password == "Bharathi@123");
        }
    }
    
}
