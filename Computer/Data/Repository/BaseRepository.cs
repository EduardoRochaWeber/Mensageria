using Data.Context;
using Data.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public abstract class BaseRepository<M> where M : Base
    {
        public virtual void Create(M model)
        {
            var factory = new ConnectionFactory() { HostName = "192.168.0.144" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                        queue: "computer_queue",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );

                string message = System.Text.Json.JsonSerializer.Serialize(model);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "",
                                                routingKey: "computer_queue",
                                                basicProperties: null,
                                                body: body);
            }
        }

    }
}
