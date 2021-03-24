using System.ComponentModel.DataAnnotations;

namespace TestTaskSoftwareSolutions.Model.Requests
{
    public class CreateMessageRequest
    {
        /// <summary>
        /// Channel
        /// </summary>
        public string channel = "char";

        /// <summary>
        /// Phone
        /// </summary>
        [Required]
        public string phone { get; set; }

        /// <summary>
        /// Text of message
        /// </summary>
        [Required]
        public string text { get; set; }

        /// <summary>
        /// Sender name
        /// </summary>
        public string sender { get; set; }
    }
}
