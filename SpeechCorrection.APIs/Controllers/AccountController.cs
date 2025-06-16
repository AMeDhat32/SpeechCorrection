using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeechCorrection.APIs.DTOs;
using SpeechCorrection.APIs.Errors;
using SpeechCorrection.Core.Models.Enum;
using SpeechCorrection.Core.Models;
using SpeechCorrection.Core.Models.Identity;
using SpeechCorrection.Core.Services.Contract;
using SpeechCorrection.Repository.Data;

namespace SpeechCorrection.APIs.Controllers
{

    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly ITokenService _tokenService;
        private readonly ApplicationContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, ITokenService tokenService,ApplicationContext context)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody]LoginDto logindto)
        {
            var user = await _userManager.FindByEmailAsync(logindto.Email);

            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signinManager.CheckPasswordSignInAsync(user, logindto.Password, false);

            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            var token = await _tokenService.CreateTokenAsync(user, _userManager);
            return  new AuthResponseDto
            { 
                
                Email = user.Email,
                UserType = user.UserType,
                Token = token
               
            };
        }
        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterDto registerDto)
        {
            if (CheckEmailExistsAsync(registerDto.Email).Result.Value)
            {
                return BadRequest(new ApiValidationErrorResponse() { Errors = new[] { "Email address is in use" } });
            }

            var user = new AppUser
            {
                UserName = registerDto.Email.Split('@')[0],
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                BirthDate = registerDto.BirthDate,
                nationality = registerDto.Nationality,
                City = registerDto.City,
                Gender = registerDto.Gender,
                UserType = registerDto.UserType.Value
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new ApiResponse(400));
            }
            if (registerDto.UserType == userType.Doctor && registerDto.Doctor != null)
            {
                var doctor = new Doctor
                {
                    Id = user.Id, // Primary key shared with AppUser
                    About = registerDto.Doctor.About,
                    WorkingDays = registerDto.Doctor.WorkingDays,
                    AvailableFrom = registerDto.Doctor.AvailableFrom,
                    AvailableTo = registerDto.Doctor.AvailableTo
                };

                _context.Doctors.Add(doctor);
            }
            else if (registerDto.UserType == userType.Patient && registerDto.Patient != null)
            {
                var patient = new Patient
                {
                    Id = user.Id,
                    FamilyMembersCount = registerDto.Patient.FamilyMembersCount,
                    SiblingRank = registerDto.Patient.SiblingRank,
                    LatestIqTestResult = registerDto.Patient.LatestIqTestResult,
                    LatestLeftEarTestResult = registerDto.Patient.LatestLeftEarTestResult,
                    LatestRightEarTestResult = registerDto.Patient.LatestRightEarTestResult
                };

                _context.Patients.Add(patient);
            }

            await _context.SaveChangesAsync();
            var token = await _tokenService.CreateTokenAsync(user, _userManager);
            return new AuthResponseDto
            {

                Email = user.Email,
                UserType = user.UserType,
                Token = token

            };



        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }




    }
}
