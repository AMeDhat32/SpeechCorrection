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
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
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
            var user = new AppUser
            {
                UserName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserType = registerDto.UserType,
                Address = registerDto.Address
                
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Invalid password." });
            }
            return new UserDto
            {
                Email = user.Email,
                DisplayName = user.UserName,

            };
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            // Simulate sending an email (replace with your actual email-sending logic)
            // For example: _emailService.SendResetPasswordEmail(user.Email, token);

            return Ok(new { message = "Password reset token generated.", token });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Failed to reset password.", errors = result.Errors });
            }

            return Ok(new { message = "Password reset successful." });
        }




    }
}
