using Microsoft.AspNetCore.Identity;
using SpeechCorrection.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechCorrection.Core.Models.Identity
{
    public class AppUser  : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? BirthDate { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public string? nationality { get; set; }
        
        public string? City { get; set; }

        public string? Gender { get; set; }

        public userType? UserType { get; set; }

    }
}
