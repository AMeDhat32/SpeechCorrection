using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpeechCorrection.Core.Models.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum userType
    {
        Patient = 1,
        Doctor = 2
    }
}
