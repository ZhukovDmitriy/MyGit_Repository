using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Producer.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMqController : ControllerBase
    {
        private readonly IRabbitMqService _mqService;

        public RabbitMqController(IRabbitMqService mqService)
        {
            _mqService = mqService;
        }

        [Route("[action]/{message}")]
        [HttpGet]
        public IActionResult SendMessage(string message)
        {
            _mqService.SendMessage(message);

            return Ok("Сообщение отправленно");
        }
    }
}
