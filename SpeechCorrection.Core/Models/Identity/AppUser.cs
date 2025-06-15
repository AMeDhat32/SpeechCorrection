using Microsoft.AspNetCore.Identity;
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
        public string? LasttName { get; set; }
        public DateTime? BirthDate { get; set; }

        public string? ProfilePictureUrl { get; set; }

        public string? nationality { get; set; }
        
        public string? City { get; set; }

        public string? Genger { get; set; }

    }
}
