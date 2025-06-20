using AutoMapper;
using SpeechCorrection.APIs.DTOs;
using SpeechCorrection.Core.Models.TrainingModule;

namespace SpeechCorrection.APIs.Helpers
{
    public class TrainingRecordUrlResolver : IValueResolver<TrainingRecord, TrainingRecordDto, string>
    {
        private readonly IConfiguration _config;
        private readonly IHostEnvironment _env;

        public TrainingRecordUrlResolver(IConfiguration config,IHostEnvironment env)
        {
            _config = config;
            _env = env;
        }
        public string Resolve(TrainingRecord source, TrainingRecordDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.RecordingUrl))
            {
                return null;
            }
            var TrainingRecordUrl = source.RecordingUrl;
            if (_env.IsDevelopment())
            {
                return $"{_config["DevApiBaseUrl"]}/{TrainingRecordUrl}";
            }
            else
            {
                return $"{_config["ApiProductionUrl"]}/{TrainingRecordUrl}";
            }
        }
    }
}
