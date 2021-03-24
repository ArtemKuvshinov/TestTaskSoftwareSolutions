using System;

namespace TestTaskSoftwareSolutions.Model.DTO
{
    public class MessageDTO : BaseDTO
    {
        /// <summary>
        /// Sent date of message
        /// </summary>
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Phone sender
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Text of message
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Status message
        /// </summary>
        public string Status { get; set; }
    }
}
