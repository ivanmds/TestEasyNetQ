using System;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Topology;
using Microsoft.AspNetCore.Mvc;

namespace RabbitMQEasyNetQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpGet("{message}")]
        public async Task<IActionResult> Add(string message)
        {
            using var bus = RabbitHutch.CreateBus("host=rabbit").Advanced;
            var exchange = bus.ExchangeDeclare("test_exchange", ExchangeType.Topic, durable: true);
            bus.Publish(exchange, "test.exchange", false, new MessageProperties { CorrelationId = Guid.NewGuid().ToString() }, Encoding.ASCII.GetBytes(message));

            return Ok();
        }
    }
}