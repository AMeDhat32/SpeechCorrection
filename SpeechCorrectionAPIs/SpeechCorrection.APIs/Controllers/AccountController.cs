using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpeechCorrectionAPIs.SpeechCorrection.APIs.DTOs;
using SpeechCorrectionAPIs.SpeechCorrection.Core.Models.Identity;



namespace SpeechCorrectionAPIs.SpeechCorrection.APIs.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)

        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Unauthorized(new { message = "Unauthorized request. User not found." });
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized(new { message = "Unauthorized request. Incorrect password." });
            }
            return new UserDto
            {
                Email = user.Email,
                DisplayName = user.UserName
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.FindByEmailAsync(registerDto.Email) != null)
            {
                return BadRequest(new { message = "Email is already taken." });
            }
            var user = new IdentityUser
            {
                UserName = registerDto.DisplayName,
                Email = registerDto.Email
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Invalid password." });
            }
            return new UserDto
            {
                Email = user.Email,
                DisplayName = user.UserName
            };
        }




    }
}
