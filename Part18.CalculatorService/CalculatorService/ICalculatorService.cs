using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculatorService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "ICalculatorService"을 변경할 수 있습니다.
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        int Divide(int Numerator, int Denominator);
    }
}

/*## Part 18 Throwing SOAP Faults from WCF
A WCF service should be throwing a FaultException or FautlException<T> instead of Dot Net exceptions.
This is because of the following 2 reasons.
1. An unhandled .NET exception will cause the channel between the client and the server to fault.
Once the channel is  in a faulted state we cannot use the client proxy anymore.
We will have to re-create the proxy.
We discussed this in Part 17 of the WCF tutorial. 
On the other hand faultexceptions will not cause the communication channel to fault.

2. As .NET exceptions are platform specific, they can only be understood by a client that is also .NET. 
If you want the WCF service to be interoperable, then the service should be throwing FaultExceptions.

Please Note : FaultException<T> allows us to create strongly typed SOAP faults. 
We will discuss this in our next video.
 * 
 * Part 18 WCF에서 SOAP 오류 던지기
WCF 서비스는 Dot Net 예외 대신 FaultException 또는 FautlException <T>를 throw해야합니다.
이는 다음 두 가지 이유 때문입니다.
1. 처리되지 않은 .NET 예외로 인해 클라이언트와 서버 간의 채널에 오류가 발생합니다.
채널이 오류 상태가되면 더 이상 클라이언트 프록시를 사용할 수 없습니다.
프록시를 다시 만들어야합니다.
WCF 자습서의 Part 17에서 이에 대해 논의했습니다.
반면에 faultexceptions는 통신 채널에 오류를 일으키지 않습니다.

2. .NET 예외는 플랫폼에 따라 다르기 때문에 .NET 인 클라이언트 만 이해할 수 있습니다.
WCF 서비스를 상호 운용 할 수 있도록하려면 서비스에서 FaultExceptions를 throw해야합니다.

참고 : FaultException <T>를 사용하면 강력한 유형의 SOAP 오류를 만들 수 있습니다. 
 다음 비디오에서 이에 대해 논의 할 것입니다.
*/