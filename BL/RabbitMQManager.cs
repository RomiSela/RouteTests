﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Common;

namespace BL
{
    public class RabbitMQManager
    {
        public ConnectionFactory Factory { get; private set; }
        public IModel Channel { get; private set; }
        public IConnection Connection { get; private set; }

        public void Connect()
        {
            Factory = new ConnectionFactory();
            Factory.UserName = ConfigManager.RabbitUserName;
            Factory.Password = ConfigManager.RabbitPassword;
            Factory.VirtualHost = ConfigManager.RabbitVirtualHost;
            Factory.HostName = ConfigManager.RabbitHostName;

            Connection = Factory.CreateConnection();
            Factory.Port = ConfigManager.RabbitPort;
            Channel = Connection.CreateModel();
        }

        public void Send(PurchaseData purchaseData)
        {
            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(purchaseData.ToString());
            Channel.BasicPublish("", "TEST", null, messageBodyBytes);
            Disconnect();
        }

        public void Disconnect()
        {
            Channel.Close();
            Connection.Close();
        }
    }
}
