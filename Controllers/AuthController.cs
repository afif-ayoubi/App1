using App1.CustomActionFilters;
using App1.Models.DTO;
using App1.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace App1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;

            _tokenRepository = tokenRepository;
        }


        [HttpPost]
        [Route("register")]
        [ValidateModelAtrribute]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var invalidRoles = new List<string>();

            foreach (var role in registerRequestDto.Roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))

                    invalidRoles.Add(role);

            }

            if (invalidRoles.Any())
            {
                return BadRequest(new { Errors = $"The following roles do not exist: {string.Join(", ", invalidRoles)}" });
            }

            var identityUser = new IdentityUser { UserName = registerRequestDto.Username, Email = registerRequestDto.Username };
            var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                if (identityResult.Succeeded)
                {
                    return Ok("User was registered successfully! Please login.");
                }
                else
                {
                    await _userManager.DeleteAsync(identityUser);
                    return BadRequest(identityResult.Errors.Select(x => x.Description).ToList());
                }
            }

            return BadRequest(identityResult.Errors.Select(x => x.Description).ToList());

        }

        [HttpPost]
        [Route("login")]
        [ValidateModelAtrribute]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var identityUser = await _userManager.FindByEmailAsync(loginRequestDto.Username);

            if (identityUser != null)
            {
                var check = await _userManager.CheckPasswordAsync(identityUser, loginRequestDto.Password);
                if (check)
                {

                    var roles = await _userManager.GetRolesAsync(identityUser);
                    if (roles.Any())
                    {
                        var jwtToken = _tokenRepository.CreateJWTToken(identityUser, roles.ToList());
                        var response = new LoginResponseDto { Token = jwtToken };
                        return Ok(response);

                    }
                }
            }


            return BadRequest("Invalid username or password.");
        }
    }
}
