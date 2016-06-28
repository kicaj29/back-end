using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapMicroServices
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bootstrap started");
            for(var port = 10025; port < 10035; port++)
            {
                Process.Start("ExeOverheadVerification.exe", port.ToString());
            }
            Console.WriteLine("Bootstrap ended, bye!");
        }
    }
}
