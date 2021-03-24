using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestTaskSoftwareSolutions.DAL.Domain;
using TestTaskSoftwareSolutions.Model.DTO;
using TestTaskSoftwareSolutions.Model.Responses;

namespace TestTaskSoftwareSolutions.Mappings
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageDTO, Message>().ReverseMap();

            CreateMap<MessageResponse, MessageDTO>()
                .ForMember(x => x.Id, x => x.MapFrom(m => m.Data.Select(x => x.Id).First()))
                .ForMember(x => x.Phone, x => x.MapFrom(m => m.Data.Select(x => x.Phone).First()))
                .ForMember(x => x.Text, x => x.MapFrom(m => m.Data.Select(x => x.Message).First()))
                .ForMember(x => x.Status, x => x.MapFrom(m => m.Data.Select(x => x.Status).First()));
        }
    }
}
