using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloService
{
    // Part 24 Self hosting a wcf service in console application
    public class HelloService : IHelloService
    {

        #region IHelloService 멤버

        public string GetMessage(string name)
        {
            return "Hello" + name;
        }

        #endregion
    }
}
