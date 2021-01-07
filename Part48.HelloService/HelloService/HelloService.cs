using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloService
{

    public class HelloService : IHelloService
    {

        public string GetMessageWithoutAnyProtection()
        {
            return "Message without signature and encryption";
        }

        public string GetSignedMessage()
        {
            return "Mesesage with signature but without encryption";
        }

        public string GetSignedAndEncryptedMessage()
        {
            return "Message signed and encrypted";
        }

    }
}
