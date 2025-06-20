using AutoMapper;
using SpeechCorrection.APIs.DTOs;
using SpeechCorrection.Core.Models.TrainingModule;

namespace SpeechCorrection.APIs.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<SourceType, DestinationType>()
            //     .ForMember(dest => dest.PropertyName, opt => opt.MapFrom(src => src.SourcePropertyName));

            // Example mapping
            // CreateMap<AppUser, AuthResponseDto>()
            //     .ForMember(dest => dest.Token, opt => opt.Ignore());

            // Add more mappings as needed

            CreateMap<TrainingRecord,TrainingRecordDto>()
                .ForMember(dest =>dest.letter,opt => opt.MapFrom(src => src.TrainingLevel.Letter.Symbol))
                .ForMember(dest => dest.level, opt => opt.MapFrom(src => src.TrainingLevel.Level))
                
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.RecordingUrl, opt => opt.MapFrom<TrainingRecordUrlResolver>());
        }
    }
}
