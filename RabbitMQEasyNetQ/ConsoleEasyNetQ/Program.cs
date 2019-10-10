using EasyNetQ;
using EasyNetQ.Topology;

namespace ConsoleEasyNetQ
{
    class Program
    {
        static void Main(string[] args)
        {
            using var advancedBus = RabbitHutch.CreateBus("host=localhost").Advanced;

            var sourceExchange = advancedBus.ExchangeDeclare("test_exchange", ExchangeType.Topic);
            var queue = advancedBus.QueueDeclare("test_queue");

            advancedBus.Bind(sourceExchange, queue, "test.exchange");
        }
    }
}
