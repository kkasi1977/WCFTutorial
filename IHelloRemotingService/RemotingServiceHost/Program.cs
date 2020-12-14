using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

//https://www.youtube.com/watch?v=3Qt7TTS1u4A&list=PL6n9fhu94yhVxEyaRMaMN_-qnDdNVGsL1&index=2
namespace RemotingServiceHost
{
    class Program
    {
        static void Main()
        {
            HelloRemothingService.HelloRemotingService remotingService = new 
                HelloRemothingService.HelloRemotingService();
            TcpChannel channel = new TcpChannel(8085);
            ChannelServices.RegisterChannel(channel);
            RemotingConfiguration.RegisterWellKnownServiceType
                (typeof(HelloRemothingService.HelloRemotingService), "GetMessage", WellKnownObjectMode.Singleton);
            Console.WriteLine("Remoting service started @ " + DateTime.Now);
            Console.ReadLine();
        }
    }
}
