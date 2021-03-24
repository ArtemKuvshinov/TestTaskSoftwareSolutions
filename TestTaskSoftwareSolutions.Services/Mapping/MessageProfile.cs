using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TestTaskSoftwareSolutions.DAL.Domain;
using TestTaskSoftwareSolutions.Model.DTO;

namespace TestTaskSoftwareSolutions.Services.Mapping
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDTO>().ReverseMap();           
        }
    }

}
