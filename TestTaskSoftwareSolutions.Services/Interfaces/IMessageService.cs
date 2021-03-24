using System;
using System.Collections.Generic;
using System.Text;
using TestTaskSoftwareSolutions.DAL.Domain;
using TestTaskSoftwareSolutions.Model.DTO;

namespace TestTaskSoftwareSolutions.Services.Interfaces
{
    public interface IMessageService
    {
        /// <summary>
        /// Create entity Message
        /// </summary>
        void Create(MessageDTO dto);

        /// <summary>
        /// Get List of sent messages
        /// </summary>
        IEnumerable<MessageDTO> Get();
    }
}
