﻿using SpeechCorrectionAPIs.SpeechCorrection.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SpeechCorrectionAPIs.SpeechCorrection.APIs.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        //[RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$", ErrorMessage = "Password must have 1 uppercase, 1 lowercase, 1 number, 1 non alphanumeric and at least 8 characters")]
        public string Password { get; set; }

        public UserType UserType { get; set; }  

        public string Address { get; set; }
    }
}
