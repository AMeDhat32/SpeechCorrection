using SpeechCorrection.Core.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace SpeechCorrection.APIs.DTOs
{
    public class RegisterDto
    {
        // ===== Identity Data =====
       [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string? PhoneNumber { get; set; }

        // ===== General Info =====
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateOnly? BirthDate { get; set; }

        public string? Nationality { get; set; }

        public string? City { get; set; }

        public string? Gender { get; set; }

        [Required]
        public userType? UserType { get; set; }

        public PatientDto? Patient { get; set; }

        public DoctorDto? Doctor { get; set; }
    }
}
