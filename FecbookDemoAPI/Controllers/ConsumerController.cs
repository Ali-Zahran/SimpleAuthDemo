using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FecbookDemoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FecbookDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private IConsumerRepository _consumerRepository;
        public ConsumerController(IConsumerRepository consumerRepository)
        {
            _consumerRepository = consumerRepository;
        }

        public IEnumerable<Consumer> Consumers()
        {
            IEnumerable<Consumer> consumers = _consumerRepository.GetConsumers();
            return consumers;
        }
    }
}
