using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FecbookDemoAPI.Models
{
    public interface IConsumerRepository
    {
        IEnumerable<Consumer> GetConsumers();
    }

    public class ConsumerRepository : IConsumerRepository
    {
        // for dependency Injection
        private List<Consumer> _Consumers;
        public ConsumerRepository()
        {
            _Consumers = new List<Consumer>()
            {
                new Consumer(){ConsumerId= 1, Username= "Ali", Email="a@b.c", PhoneNumber="12345678991" }
            };
        }

        //Get All Consumers
        public IEnumerable<Consumer> GetConsumers()
        {
            IEnumerable<Consumer> consumers = _Consumers;
            return (consumers);
        }
    }
}
