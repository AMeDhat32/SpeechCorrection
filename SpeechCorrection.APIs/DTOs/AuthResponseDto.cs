using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SpeechCorrection.Core.Models.Enum;

namespace SpeechCorrection.APIs.DTOs
{
    public class AuthResponseDto
    {
        public String Email { get; set; }
        public userType? UserType { get; set; }
        public String Token { get; set; }
    }
}
