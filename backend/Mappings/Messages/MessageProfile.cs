// Mappings/MessageProfile.cs
using AutoMapper;
using chatbot.DTOs.Message;
using chatbot.Models;

namespace chatbot.Mappings.Messages
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageDto, Message>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Timestamp, opt => opt.Ignore())
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => "user"))
                .ForMember(dest => dest.Intent, opt => opt.MapFrom(src => "unknown"));
        }
    }
}
