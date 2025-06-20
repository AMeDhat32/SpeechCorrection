using Microsoft.EntityFrameworkCore;
using SpeechCorrection.Core.Models.TrainingModule;
using SpeechCorrection.Core.Repositories.Contract;
using SpeechCorrection.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechCorrection.Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationContext _dbcontext;

        public TrainingRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IReadOnlyList<TrainingRecord>> GetTrainingRecordsAsync(string letter, int level)
        {
            var trainingRecords = await _dbcontext.TrainingRecords.Include(tr =>tr.TrainingLevel).ThenInclude(tl => tl.Letter)
                .Where(tr => tr.TrainingLevel.Letter.Symbol == letter && tr.TrainingLevel.Level == level)
                .ToListAsync();
            return trainingRecords;
        }
    }
}
