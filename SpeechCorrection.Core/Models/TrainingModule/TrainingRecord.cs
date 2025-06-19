using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechCorrection.Core.Models.TrainingModule
{
    public class TrainingRecord
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string RecordingUrl { get; set; }

        public int TrainingLevelId { get; set; }

        public TrainingLevel TrainingLevel { get; set; }
    }
}
