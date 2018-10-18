using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace WCFServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(WCFPOPS.POPS));
            serviceHost.Open();
            Console.WriteLine("Service Is Running...");
            Console.WriteLine("Press Enter to stop.");
            Console.ReadLine();
            serviceHost.Close();
        }
    }
}
