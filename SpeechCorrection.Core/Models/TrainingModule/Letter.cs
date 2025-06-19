using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechCorrection.Core.Models.TrainingModule
{
    public class Letter
    {
        public int Id { get; set; }
        public string Symbol { get; set; }

        public ICollection<TrainingLevel> TrainingLevels { get; set; } = new List<TrainingLevel>();
    }
}
