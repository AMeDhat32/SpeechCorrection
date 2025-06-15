using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechCorrection.Core.Models
{
    public class Doctor
    {
        public string Id { get; set; }
        public string? About { get; set; }

        public List<string>? WorkingDays { get; set; } = new();
        public TimeOnly? AvailableFrom { get; set; }
        public TimeOnly? AvailableTo { get; set; }



    }
}
