﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IHelloService"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        string GetMessage(string message);
    }
}

/*Part 47 WCF security 
Bindings in WCF determine the security scheme.
The following MSDN link contains all the system provided bindings and their respective security defaults.
http://msdn.microsoft.com/en-us/library/ms731092(v=vs.110).aspx

Notice that the default security scheme for NetTcpBinding is Transport and for WSHttpBinding it is Message. 
First let's understand the difference between Message cecurity and Transport security. 

From a security perspecive,  when sending a message between a client and a WCF service, there are 2 things to consider 
1. The WCF Message itself
2. The medium or protocol(HTTP, TCP, MSMQ) over which the message is sent 

Transport Security: Securing the transport channel is called transport cecurity. 
Each of the protocols(HTTP, TCP, MSMQ etc) have their own way of providing transport security. 

For example, TCP provides transport security, by implementing Transport Layer Security (TLS).
The TLS implementation is provided by the operationg system. 

HTTP provides transport security by using Secure Sockets Layer (SSL) over HTTP. 
Transport security provides only point-to-point channel security. 
It means if there is an intermediary (Load balancer, proxy etc) between,  then that intermediary has direct access to content of the message. 

Message Security: Securing the message itself by encapsulating the security credentials with every SOAP message is called message security. 
As the message itself is protected, it provides end to end security.  

The following MSDN article explains all the differences between message and transport security and when to use one over the other. 
http://msdn.microsoft.com/en-us/library/ms733137.aspx

By default for secure bindings WCF messages are signed and encrypted. 
<endpoint address="..."  binding="wsHttpBinding" contract="..." />

With wsHttpBinding by default, the SOAP message body is Encrypted and Signed. 
To view the Encrypted and Signed message enable message logging for the WCF Service. 
We discussed enabling message logging in Part 9 of the WCF tutorial. 

In the WCF Service config file change security mode to None 
<bindings>
   <wsHttpBinding>
      <binding name="wsHttp"> 
         <security mode="None" />
      </binding>
   </wsHttpBinding>
</bindings>
...
<endpoint address=".." binding="wsHttpBinding" contract="..." bindingConfuguration="wsHttp" />
...
Run the WCF service and the client and notice that the logged message is in plain text, that is the message is not encrypted and signed. 



47 부 WCF 보안
WCF의 바인딩은 보안 체계를 결정합니다.
다음 MSDN 링크에는 모든 시스템 제공 바인딩과 해당 보안 기본값이 포함되어 있습니다.
http://msdn.microsoft.com/en-us/library/ms731092(v=vs.110).aspx

NetTcpBinding의 기본 보안 체계는 Transport이고 WSHttpBinding의 경우 Message입니다.
먼저 메시지 보안과 전송 보안의 차이점을 이해하겠습니다.

보안 측면에서 클라이언트와 WCF 서비스간에 메시지를 보낼 때 고려해야 할 두 가지 사항이 있습니다.
1. WCF 메시지 자체
2. 메시지가 전송되는 매체 또는 프로토콜 (HTTP, TCP, MSMQ)

전송 보안 : 전송 채널 보안을 전송 보안이라고합니다.
각 프로토콜 (HTTP, TCP, MSMQ 등)에는 전송 보안을 제공하는 고유 한 방법이 있습니다.

예를 들어 TCP는 TLS (전송 계층 보안)를 구현하여 전송 보안을 제공합니다.
TLS 구현은 운영 시스템에서 제공합니다.

HTTP는 HTTP를 통해 SSL (Secure Sockets Layer)을 사용하여 전송 보안을 제공합니다.
전송 보안은 지점 간 채널 보안 만 제공합니다.
중간에 중개자 (로드 밸런서, 프록시 등)가있는 경우 해당 중개자는 메시지 내용에 직접 액세스 할 수 있습니다.

메시지 보안 : 모든 SOAP 메시지에 보안 자격 증명을 캡슐화하여 메시지 자체를 보호하는 것을 메시지 보안이라고합니다.
메시지 자체가 보호되므로 종단 간 보안을 제공합니다.

다음 MSDN 문서에서는 메시지와 전송 보안의 모든 차이점과 둘 중 하나를 사용하는 경우에 대해 설명합니다.
http://msdn.microsoft.com/en-us/library/ms733137.aspx

보안 바인딩의 경우 기본적으로 WCF 메시지는 서명되고 암호화됩니다.
<endpoint address = "..."binding = "wsHttpBinding"contract = "..."/>

기본적으로 wsHttpBinding을 사용하면 SOAP 메시지 본문이 암호화되고 서명됩니다.
암호화 및 서명 된 메시지를 보려면 WCF 서비스에 대한 메시지 로깅을 활성화합니다.
WCF 자습서의 9 부에서 메시지 로깅 활성화에 대해 설명했습니다.

WCF 서비스 구성 파일에서 보안 모드를 없음으로 변경합니다.
<bindings>
   <wsHttpBinding>
      <binding name="wsHttp"> 
         <security mode="None" />
      </binding>
   </wsHttpBinding>
</bindings>
...
<endpoint address = ".."binding = "wsHttpBinding"contract = "..."bindingConfuguration = "wsHttp"/>
...
WCF 서비스와 클라이언트를 실행하고 로깅 된 메시지가 일반 텍스트로되어 있는지 확인합니다. 즉, 메시지가 암호화 및 서명되지 않았습니다.
*/
