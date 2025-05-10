using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Api.Dtos;
using WebApp.Application.Dtos.ApplicationUser;
using WebApp.Core.enums;
using WebApp.Core.models;

namespace WebApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public ApplicationUserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [Authorize(nameof(AppRoles.SuperAdmin))]
        [HttpPost("AddAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddAdmin([FromBody] UserDto adminDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userManager.FindByEmailAsync(adminDto.Email);
            if (existingUser != null)
                return BadRequest("User with this email already exists.");

            var user = new ApplicationUser()
            {
                Address = adminDto.Address,
                UserName = adminDto.UserName,
                Email = adminDto.Email
            };

            var result = await _userManager.CreateAsync(user, adminDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, nameof(AppRoles.Admin));
            return Created();

        }


        [Authorize(nameof(AppRoles.SuperAdmin))]
        [HttpPost("AddInspector")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddInspector([FromBody] UserDto inspectorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userManager.FindByEmailAsync(inspectorDto.Email);
            if (existingUser != null)
                return BadRequest("User with this email already exists.");

            var user = new ApplicationUser
            {
                Address = inspectorDto.Address,
                UserName = inspectorDto.UserName,
                Email = inspectorDto.Email
            };

            var result = await _userManager.CreateAsync(user, inspectorDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, nameof(AppRoles.Inspector));
            return Created();
        }

        [HttpGet("GetAllClients")]
        [Authorize(Roles = $"{nameof(AppRoles.SuperAdmin)}")]
        public async Task<ActionResult> GetAllClients()
        {
            var clients = await _userManager.GetUsersInRoleAsync("Client");
            var clientList = clients.Select(user => new
            {
                user.Id,
                Name = user.UserName,
                user.Email,
                user.Address,
                IsActive = user.IsDeleted
            }).ToList();
            return Ok(clientList);
        }


        [HttpPost("AddClient")]
        public async Task<ActionResult> AddClient([FromBody] UserDto clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userManager.FindByEmailAsync(clientDto.Email);
            if (existingUser != null)
                return BadRequest("User with this email already exists.");

            var user = new ApplicationUser
            {
                Address = clientDto.Address,
                UserName = clientDto.UserName,
                Email = clientDto.Email
            };

            var result = await _userManager.CreateAsync(user, clientDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            if (!await _roleManager.RoleExistsAsync("Client"))
                await _roleManager.CreateAsync(new ApplicationRole { Name = "Client" });
            try
            {

                await _userManager.AddToRoleAsync(user, "Client");
                return Ok(new { Message = "Client has been created successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }




        [HttpGet("RemoveClient")]
        public async Task<ActionResult> RemoveClient(string id)
        {
            var client = await _userManager.FindByIdAsync(id);
            if (client == null)
                return BadRequest(new { Message = "There is no client with this id." });

            if (client.IsDeleted)
            {
                client.IsDeleted = false;
            }
            else
            {
                client.IsDeleted = true;

            }
            var result = await _userManager.UpdateAsync(client);
            if (result.Succeeded)
            {
                return Ok(new { Success = true, Message = "Client has been deleted." });
            }
            return StatusCode(505, new { Message = "Cant delete client." });
        }


        [HttpPost("UpdateClient")]
        public async Task<ActionResult> UpdateClient(UpdateUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var client = await _userManager.FindByIdAsync(dto.Id);
            if (client == null)
                return BadRequest(new { Message = "There is no client with this id." });

            client.Address = dto.Address;
            client.UserName = dto.UserName;
            client.Email = dto.Email;

            var result = await _userManager.UpdateAsync(client);
            if (result.Succeeded)
            {
                return Ok(new { Success = true, Message = "Client updated successfully." });
            }
            return StatusCode(500, new { Errors = result.Errors });


        }


        [HttpGet("GetUserName")]
        public ActionResult GetCurrentUserName()
        {
            var userName = User.Identity!.Name;
            return Ok(userName);

        }


      

    }
}



