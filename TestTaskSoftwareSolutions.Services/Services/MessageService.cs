using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TestTaskSoftwareSolutions.DAL.Context;
using TestTaskSoftwareSolutions.DAL.Domain;
using TestTaskSoftwareSolutions.Model.DTO;
using TestTaskSoftwareSolutions.Services.Interfaces;

namespace TestTaskSoftwareSolutions.Services.Services
{
    public class MessageService : IMessageService
    {
        IMapper _mapper;
        RepositoryContext db;

        public MessageService(RepositoryContext dbContex, IMapper mapper)
        {
            db = dbContex;
            _mapper = mapper;
        }

        public void Create(MessageDTO dto)
        {
            var newmMssage = _mapper.Map<Message>(dto);
            db.Messages.Add(newmMssage);
            db.SaveChanges();
        }

        public IEnumerable<MessageDTO> Get()
        {
            return _mapper.Map<IEnumerable<MessageDTO>>(db.Messages);
        }
    }
}
