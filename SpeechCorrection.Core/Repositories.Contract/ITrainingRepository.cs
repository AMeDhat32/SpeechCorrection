using SpeechCorrection.Core.Models.TrainingModule;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechCorrection.Core.Repositories.Contract
{
    public interface ITrainingRepository
    {
        Task<IReadOnlyList<TrainingRecord>> GetTrainingRecordsAsync(string letter,int level);
    }
}
