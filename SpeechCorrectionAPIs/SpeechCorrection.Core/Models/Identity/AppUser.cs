using Microsoft.AspNetCore.Identity;
using SpeechCorrectionAPIs.SpeechCorrection.Core.Models.Enums;

namespace SpeechCorrectionAPIs.SpeechCorrection.Core.Models.Identity
{
    public class AppUser : IdentityUser
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }    
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public UserType UserType { get; set; }
    }
}
