using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusQueuesDemo
{
    public static class CreateMessages
    {
        const int numberOfMessages = 10;

        static IQueueClient queueClient;

        public static async Task MainAsync(ServiceBusConnectionStringBuilder sbcsb)
        {

            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after sending all the messages.");
            Console.WriteLine("======================================================");

            queueClient = new QueueClient(sbcsb);

            // Send messages.
            await SendMessagesAsync(numberOfMessages);

            await queueClient.CloseAsync();
        }
        

        static async Task SendMessagesAsync(int numberOfMessages)
        {
            try
            {
                for (var i = 0; i < numberOfMessages; i++)
                {
                    // create a new message to send to the queue.
                    string messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    // Write the body of the message to the console.
                    Console.WriteLine($"Sending message: {messageBody}");

                    // Send the message to the queue.
                    await queueClient.SendAsync(message);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }
    }
}
