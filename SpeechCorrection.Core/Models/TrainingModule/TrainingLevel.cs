using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechCorrection.Core.Models.TrainingModule
{
    public class TrainingLevel
    {
        public int Id { get; set; }
        public int Level { get; set; }

        public int LetterId { get; set; }

        public virtual Letter Letter { get; set; }

        public virtual ICollection<TrainingRecord> TrainingRecords { get; set; } = new List<TrainingRecord>();
    }
}
