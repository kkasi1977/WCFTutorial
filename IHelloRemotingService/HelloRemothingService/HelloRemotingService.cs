using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//https://www.youtube.com/watch?v=3Qt7TTS1u4A&list=PL6n9fhu94yhVxEyaRMaMN_-qnDdNVGsL1&index=2
namespace HelloRemothingService
{
    public class HelloRemotingService : MarshalByRefObject, 
                IHelloRemotingService.IHelloRemotingService
    {

 
        public string GetMessage(string name)
        {
            return "Hello " + name;
        }

    }
}
