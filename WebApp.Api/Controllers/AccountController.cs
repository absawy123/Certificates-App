using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApp.Api.Dtos;
using WebApp.Core.models;

namespace WebApp.Api.Controllers
{
    [Route("[controller]")]
    // [Authorize]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;

        }



        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginUserDto userDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userDto.Email);
                if (user == null)
                    return Unauthorized(new { message = "Invalid email or password" });

                var result = await _signInManager.CheckPasswordSignInAsync(user, userDto.Password, false);
                if (!result.Succeeded)
                {
                    return Unauthorized(new { message = "Invalid Login Attempt." });
                }

                var token =await GenerateJwtToken(user);
                return Ok(new {token}); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }



        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var authClaims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.UtcNow.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync(); 
                return Ok(new { message = "Logged out successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred during logout", details = ex.Message });
            }
        }


       
      

        [HttpPost("LockUser")]
        public async Task<ActionResult> LockUser([FromQuery]string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound(new { success = false, message = "User not found" });
            }

            user.LockoutEnd = DateTimeOffset.UtcNow.AddSeconds(60); // Lock user indefinitely
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok(new { success = true, message = "User has been locked" });
            }

            return BadRequest(new { success = false, message = "Failed to lock user" });
        }

        //[HttpPost("UnlockUser")]
        //public async Task<ActionResult> UnlockUser([FromQuery] string userId)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        return NotFound(new { success = false, message = "User not found" });
        //    }

        //    // Unlock the user by setting LockoutEnd to null
        //    user.LockoutEnd = null;
        //    var result = await _userManager.UpdateAsync(user);

        //    if (result.Succeeded)
        //    {
        //        return Ok(new { success = true, message = "User has been unlocked" });
        //    }

        //    return BadRequest(new { success = false, message = "Failed to unlock user" });
        //}



        [HttpGet("GetAllUsers")]
       // [Authorize(Roles ="SuperAdmin")]
        public async Task<ActionResult> GetAllUsers()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("User is not authenticated.");
            }

            var currentUserId = int.Parse(userIdClaim);

            var users = await _userManager.Users
                .Where(u => u.Id != currentUserId) // Exclude current user
                .Select(u => new
                {
                    u.Id,
                    u.UserName,
                    u.Email ,
                    u.LockoutEnd
                }) 
                .ToListAsync();

            return Ok(users);
        }
    }
}
