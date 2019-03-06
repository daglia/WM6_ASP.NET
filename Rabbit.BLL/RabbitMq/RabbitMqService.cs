using RabbitMQ.Client;
using System;

namespace Rabbit.BLL.RabbitMq
{
    public class RabbitMqService
    {
        private readonly string _hostName = @"Wissen",
            _userName = "daglia",
            _password = "123456";

        public IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = _hostName,
                VirtualHost = "/",
                UserName = _userName,
                Password = _password,
                Uri = new Uri($"amqp://{_userName}@{_hostName}")
            };
            return connectionFactory.CreateConnection();
        }
    }
}
