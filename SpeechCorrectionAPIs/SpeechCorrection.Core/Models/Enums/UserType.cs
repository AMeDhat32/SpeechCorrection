using System.Runtime.Serialization;

namespace SpeechCorrectionAPIs.SpeechCorrection.Core.Models.Enums
{
    public enum UserType
    {
        [EnumMember(Value = "Doctor")]
        Doctor,
        [EnumMember(Value = "Child")]
        Patient
    }
        
}
