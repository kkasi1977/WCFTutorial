using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "ISimpleService"을 변경할 수 있습니다.
    [ServiceContract]
    public interface ISimpleService
    {
        [OperationContract]
        int IncrementNumber();
    }
}

/*Part 39 PerSession WCF services

Does all bindings suport sessions
No, not all bindings support sessions.
For example basicHttpBinding does not supprot session.
If the binding does not support session, then the service behaves as a PerCall service. 

MSDN Link
http://msdn.microsoft.com/en-us/library/ms730879(v-vs.110).aspx

How to control the WCF service session timeout? 
The default session timeout is 10 minutes.
If you want to increase or decrease the default timeout value, set receiveTimeout attribute of the respective binding element
<bindings>
  <netTcpBinding>
      <binding name="netTCP" receiveTimeout="00:00:10"></binding>
   </netTcpBinding>
</bindings>

What happens when the session timeout is reached
When the session timeout is reached, the connection to the wcf service is closed. 
As a result, the communication channel gets faulted and the client can no longer use the same proxy instance to communicate with the service. 
This also means that along with the session, the data in the service object is also lost. 

After the session has timed out, 
1. On the first attempt to invoke the service using the same proxy instance would result in the following exception. 

The socket connection was aborted. 
This could be caused by an error processing your message or a receive timeout being exceeded by the remote host, or an underlying network resource issue.
Local socket timeout was '00:00:59.93554444'.

2. On the second attenmpt, the following exception will be thrown
The communication object, System.ServiceModel.Channels.ServiceChannel, cannot be used for communication because it is in the Faulted state. 


How to fix, The communication channel is in a faulted state exception
1. Put the line that calls the service should in the try block
2. Catch the CommunicationException
3. Check if the communication channel is in a faulted state and create a new instance of the proxy class. 



Part 39 PerSession WCF 서비스

모든 바인딩이 세션을 지원합니까?
아니요, 모든 바인딩이 세션을 지원하는 것은 아닙니다.
예를 들어 basicHttpBinding은 세션을 지원하지 않습니다.
바인딩이 세션을 지원하지 않는 경우 서비스는 PerCall 서비스로 작동합니다.

MSDN 링크
http://msdn.microsoft.com/en-us/library/ms730879(v-vs.110).aspx

WCF 서비스 세션 시간 제한을 제어하는 ​​방법은 무엇입니까?
기본 세션 시간 제한은 10 분입니다.
기본 제한 시간 값을 늘리거나 줄이려면 각 바인딩 요소의 receiveTimeout 속성을 설정하십시오.
<bindings>
  <netTcpBinding>
      <binding name="netTCP" receiveTimeout="00:00:10"></binding>
   </netTcpBinding>
</bindings>

세션 시간 초과에 도달하면 어떻게 되나요?
세션 제한 시간에 도달하면 wcf 서비스에 대한 연결이 닫힙니다.
결과적으로 통신 채널에 오류가 발생하고 클라이언트는 더 이상 동일한 프록시 인스턴스를 사용하여 서비스와 통신 할 수 없습니다.
이것은 또한 세션과 함께 서비스 개체의 데이터도 손실됨을 의미합니다.

세션 시간이 초과되면
1. 동일한 프록시 인스턴스를 사용하여 서비스를 호출하려는 첫 번째 시도에서 다음 예외가 발생합니다.

소켓 연결이 중단되었습니다.
이는 메시지를 처리하는 동안 오류가 발생하거나 원격 호스트에서 수신 시간 초과가 초과되었거나 기본 네트워크 리소스 문제로 인해 발생할 수 있습니다.
로컬 소켓 시간 초과는 '00 : 00 : 59.93554444 '입니다.

2. 두 번째 참석시 다음 예외가 발생합니다.
통신 개체 인 System.ServiceModel.Channels.ServiceChannel은 Faulted 상태이므로 통신에 사용할 수 없습니다.


해결 방법, 통신 채널이 오류 상태 예외입니다.
1. 서비스를 호출하는 라인을 try 블록에 넣어야합니다.
2. CommunicationException 잡기
3. 통신 채널이 오류 상태인지 확인하고 프록시 클래스의 새 인스턴스를 만듭니다.
*/