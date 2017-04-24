using Messages;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Endpoint=sb://jaceknamespace.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=slk23eCF/B+9X4LilthlmiGgutqrfva+n1kA6oOznKc=";
            var queueName = "firstqueue";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            string customerType = typeof(Customer).ToString();
            string storeType = typeof(Store).ToString(); ;

            client.OnMessage(message =>
            {
                //Console.WriteLine(String.Format("Message body: {0}", message.GetBody<String>()));

                if (message.ContentType == customerType)
                {
                    Customer cust = message.GetBody<Customer>();
                    Console.WriteLine(string.Format("Name: {0}, Age: {1}", cust.Name, cust.Age));
                    Console.WriteLine(String.Format("Message id: {0}", message.MessageId));
                }
                else if (message.ContentType == storeType)
                {
                    Store store = message.GetBody<Store>();
                    Console.WriteLine(string.Format("Name: {0}, Address: {1}", store.Name, store.Address));
                    Console.WriteLine(String.Format("Message id: {0}", message.MessageId));
                }
                else
                {
                    throw new Exception(message.ContentType);
                }
            });

            Console.ReadLine();
        }
    }
}
