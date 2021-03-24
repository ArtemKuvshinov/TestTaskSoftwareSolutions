using System.Collections.Generic;

namespace TestTaskSoftwareSolutions.Model.Responses
{
    public class MessageResponse
    {
        public IEnumerable<MessageData> Data { get; set; }
    }

    public class MessageData
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Text of message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Status message
        /// </summary>
        public string Status { get; set; }
    }

}
