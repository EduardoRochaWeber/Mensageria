using Data.Repository;
using Data.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;

namespace RabbitMq
{
    class Program
    {
        static void Main(string[] args)
        {
            DbRepository db = new DbRepository();
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var computer = System.Text.Json.JsonSerializer.Deserialize<Computer>(body);
                    Console.WriteLine(" [x] Received {0}", computer.Description);
                    
                    db.Create(computer);
                };
                channel.BasicConsume(queue: "computer_queue",
                                                            autoAck: true,
                                                            consumer: consumer);
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }

        }
    }
}
