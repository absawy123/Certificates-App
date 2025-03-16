using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApp.Api.Dtos;
using WebApp.Core.enums;
using WebApp.Core.models;

namespace WebApp.Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager ,
            IConfiguration configuration )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }



        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([FromBody] LoginUserDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return Unauthorized(new { message = "Invalid email or password" });

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
            if (!result.Succeeded)
                return Unauthorized(new { message = "Invalid email or password" });

            var token = GenerateJwtToken(user);
            return Ok(new { token });

        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var authClaims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var userRoles = _userManager.GetRolesAsync(user).Result;
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


        [Authorize(nameof(AppRoles.SuperAdmin))]
        [HttpPost("AddAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddAdmin([FromBody] AddUserDto adminDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userManager.FindByEmailAsync(adminDto.Email);
            if (existingUser != null)
                return BadRequest("User with this email already exists.");

            var adminUser = new ApplicationUser
            {
                UserName = adminDto.UserName,
                Email = adminDto.Email
            };

            var result = await _userManager.CreateAsync(adminUser, adminDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(adminUser, nameof(AppRoles.Admin));
            return Created();

        }

        [Authorize(nameof(AppRoles.SuperAdmin))]
        [HttpPost("AddInspector")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddInspector([FromBody] AddUserDto inspectorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userManager.FindByEmailAsync(inspectorDto.Email);
            if (existingUser != null)
                return BadRequest("User with this email already exists.");

            var inspectorUser = new ApplicationUser
            {
                UserName = inspectorDto.UserName,
                Email = inspectorDto.Email
            };

            var result = await _userManager.CreateAsync(inspectorUser, inspectorDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(inspectorUser, nameof(AppRoles.Inspector));
            return Created();
        }

        [Authorize(nameof(AppRoles.SuperAdmin))]
        [HttpPost("AddClient")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddClient([FromBody] AddUserDto clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userManager.FindByEmailAsync(clientDto.Email);
            if (existingUser != null)
                return BadRequest("User with this email already exists.");

            var inspectorUser = new ApplicationUser
            {
                UserName = clientDto.UserName,
                Email = clientDto.Email
            };

            var result = await _userManager.CreateAsync(inspectorUser, clientDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(inspectorUser, nameof(AppRoles.Client));
            return Created();
        }


    }
}
