using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;


namespace HelloServiceHost
{
    class Program
    {
        static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(HelloService.HelloService)))
            {
     
                 //Part 22 Confugure WCF service endpoint dynamically in code
                ServiceMetadataBehavior serviceMetadataBehavior = new ServiceMetadataBehavior()
                {
                    HttpGetEnabled = true,
                };
                host.Description.Behaviors.Add(serviceMetadataBehavior);
                host.AddServiceEndpoint(typeof(HelloService.IHelloService), new NetTcpBinding(), "HelloService");
        
                host.Open();
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }

        }
    }
}
