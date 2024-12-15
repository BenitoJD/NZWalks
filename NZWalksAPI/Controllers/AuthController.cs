using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager , ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var IdentityUser = new IdentityUser
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.UserName
                
            };

            var identityResult =   await userManager.CreateAsync(IdentityUser, registerRequestDto.password);

            if (identityResult.Succeeded) 
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult =  await userManager.AddToRoleAsync(IdentityUser, registerRequestDto.Roles[0]);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please Login");
                    }
                }
            }
            return BadRequest("Something Went Wrong");


        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);

            if(user != null)
            {
               var CheckPassword =  await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (CheckPassword)
                {
                   var Roles = await userManager.GetRolesAsync(user);

                    if(Roles != null)
                    {
                      var jwtToken =  tokenRepository.CreateJwtToken(user, Roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken,
                        };

                        return Ok(response);


                    }


                }
            }
            return BadRequest("User Name or Password Incorrect");
        }
    }
}
