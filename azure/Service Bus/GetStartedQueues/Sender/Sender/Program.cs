using Messages;
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
            Customer c = new Customer();
            c.Name = "Jacek";
            c.Age = 18;

            //var message = new BrokeredMessage("This is a test message!");
            var message = new BrokeredMessage(c);
            message.ContentType = typeof(Customer).ToString();
            client.Send(message);

            var store = new Store();
            store.Name = "My store";
            store.Address = "Address";

            var message1 = new BrokeredMessage(store);
            message1.ContentType = typeof(Store).ToString();
            client.Send(message1);

        }
    }
}
