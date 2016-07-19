using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ExeOverheadVerificationService
{
    public partial class Service1 : ServiceBase
    {
        public Service1(string[] args)
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var web = new HttpListener();
            web.Start();

            var context = web.GetContext();
            var response = context.Response;
            string responseString = string.Format("<html><body>Hello world from port {0}</body></html>", args[0]);
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            web.Stop();
        }

        protected override void OnStop()
        {
        }
    }
}
