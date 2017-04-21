using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Endpoint=sb://jaceknamespace.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=slk23eCF/B+9X4LilthlmiGgutqrfva+n1kA6oOznKc=";
            var queueName = "firstqueue";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            var message = new BrokeredMessage("This is a test message!");
            client.Send(message);
        }
    }
}
