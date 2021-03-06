﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExeOverheadVerification
{
    class Program
    {
        static void Main(string[] args)
        {
            string tmp = string.Format("http://localhost:{0}/", args[0]);
            //string tmp = string.Format("http://localhost:{0}/", 10025);

            Console.WriteLine("Service started " + tmp);

            var web = new HttpListener();
            
            web.Prefixes.Add(tmp);

            Console.WriteLine("Listening..");
            web.Start();

            var context = web.GetContext();
            var response = context.Response;
            string responseString = string.Format("<html><body>Hello world from port {0}</body></html>", args[0]);
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            Console.WriteLine(output);
            output.Close();
            web.Stop();

            Console.WriteLine("Please press any key to close me... ");
            Console.ReadKey();
            Console.WriteLine("Good bye!");
        }
    }
}
