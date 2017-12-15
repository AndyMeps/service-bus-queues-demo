using Microsoft.Azure.ServiceBus;
using System;

namespace ServiceBusQueuesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("------------------");
            Console.WriteLine("1. CreateMessages");
            Console.WriteLine("2. ReceiveMessages");
            Console.WriteLine("------------------\n");

            Console.Write("Enter choice: ");

            var sbcs = GetConnectionStringBuilder(
                endpoint: "sb://<endpoint-url>/",
                queueName: "<queue-name>",
                accessKeyName: "<shared-access-key-name>",
                accessKey: "<shared-access-key>");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateMessages.MainAsync(sbcs).GetAwaiter().GetResult();
                    break;
                case "2":
                    ReceiveMessages.MainAsync(sbcs).GetAwaiter().GetResult();
                    break;
                default:
                    break;
            }

            Console.WriteLine("Done, press ANY KEY to exit.");
            Console.ReadKey();
        }

        static ServiceBusConnectionStringBuilder GetConnectionStringBuilder(string endpoint, string queueName, string accessKeyName, string accessKey, TransportType transportType = TransportType.AmqpWebSockets)
        {
            return new ServiceBusConnectionStringBuilder(endpoint, queueName, accessKeyName, accessKey, transportType);
        }
    }
}
