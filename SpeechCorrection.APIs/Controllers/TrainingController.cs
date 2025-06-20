using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeechCorrection.APIs.DTOs;
using SpeechCorrection.Core.Models.TrainingModule;
using SpeechCorrection.Core.Repositories.Contract;

namespace SpeechCorrection.APIs.Controllers
{
    
    public class TrainingController : BaseApiController
    {
        private readonly ITrainingRepository _trainRepo;
        private readonly IMapper _mapper;

        public TrainingController(ITrainingRepository trainRepo,IMapper mapper)
        {
            _trainRepo = trainRepo;
            _mapper = mapper;
        }


        [HttpGet("TrainingRecords")]
        public async Task<ActionResult<IReadOnlyList<TrainingRecordDto>>> GetRecords(string letter,int level)
        {
            var records = await _trainRepo.GetTrainingRecordsAsync(letter, level);
            if (records == null || !records.Any())
            {
                return NotFound("No training records found for the specified letter and level.");
            }
            var recordDtos = _mapper.Map<IReadOnlyList<TrainingRecordDto>>(records);
            return Ok(recordDtos);
        }
    }
}
