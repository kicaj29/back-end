using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSelfHost_CORS
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Started...");
                // Create HttpCient and make a request to api/values 
                //HttpClient client = new HttpClient();

                //var response = client.GetAsync(baseAddress + "api/values").Result;

                //Console.WriteLine(response);

                //var response1 = client.GetAsync(baseAddress + "api/values").Result;

                //Console.WriteLine(response1);
                //Console.WriteLine(response1.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }

            Console.WriteLine("Good by!");
        }
    }
}
