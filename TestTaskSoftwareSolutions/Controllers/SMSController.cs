using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestTaskSoftwareSolutions.Model.DTO;
using TestTaskSoftwareSolutions.Model.Requests;
using TestTaskSoftwareSolutions.Model.Responses;
using TestTaskSoftwareSolutions.Services.Interfaces;

namespace TestTaskSoftwareSolutions.Controllers
{
    public class SMSController : Controller
    {
        IMessageService _messageService;
        private readonly IMapper _mapper;

        public SMSController(IMessageService messageService, IMapper mapper)
        {
            _mapper = mapper;
            _messageService = messageService;
        }

        [Route("message/new")]
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateMessageRequest request)
        {
            List<CreateMessageRequest> dataMessage = new List<CreateMessageRequest>() { request };

            var inputDataJSONFormat = JsonConvert.SerializeObject(new
            {
                apiKey = "A3UjPbZPwJ8iAULPWV5PJfkBDxe7xZyNQKdMESUGF9TEPp8xPcuUp9FfKJ6O",
                sms = dataMessage
            });

            var inputData = new StringContent(inputDataJSONFormat, Encoding.UTF8, "application/json");
            var urlApi = "https://new.smsgorod.ru/apiSms/create";

            using (var client = new HttpClient())
            {
                try
                {
                    //Основная 
                     var response = await client.PostAsync(urlApi, inputData);
                     string resultString = response.Content.ReadAsStringAsync().Result;
                    //

                   // string resultString = "{\"status\":\"success\",\"data\":[{\"message\":\"Hello!\",\"createdAt\":1616350993,\"id\":771133373,\"status\":\"sent\",\"phone\":\"79377010329\"}]}";//delete
                    var messageResponse = JsonConvert.DeserializeObject<MessageResponse>(resultString);

                    var responseDTO = _mapper.Map<MessageDTO>(messageResponse);
                    responseDTO.SentDate = DateTime.Now;

                    _messageService.Create(responseDTO);
                }
                catch (HttpRequestException e)
                {
                    return BadRequest($"Error: {e.Message}");
                }
            }

            return Ok();
        }

        [Route("message")]
        [HttpGet]
        public IEnumerable<MessageDTO> Get()
        {
            IEnumerable<MessageDTO> result = _messageService.Get();
            return result;
        }

    }
}
