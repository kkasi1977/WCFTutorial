﻿using System;
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

/*Part 40 How to retrieve the sessionid in WCF service and in the client application

In order to send messages from a particular client to a particular service instance on the server, WCF uses SessionId. 

Client 1                <-------------------------->          Service Instance for Client1
SID:92F88DCC-.....                                         SID:92F88DCC-.....  

Client 2                <-------------------------->          Service Instance for Client2
SID:FB1BA179-.....                                         SID:FB1BA179-.....  

Please Note : There are different types of sessions in WCF.
We will discuess these in a greater detail in a later video session. 

To retrieve SessionId from the client application
    procyClassInstance.InnerChannel.SessionId

To retrieve SessionId from the WCF service 
    OperationContext.Current.SessionId

The client-side and service-side session IDs are co-related using the reliable session id. 
So, if TCP binding used with reliable sessions disabled then the client and server session id's will be different. 
On the other hand, if reliable sessions are enabled, the session id's will be ssame. 
<bindings>
   <netTcpBinding>
      <binding name="netTCP" receiveTimeout="00:00:10">
         <reliableSession enable="true"/>
      </binding>
   </netTcpBinding>
</bindings>

With wsHttpBinding, irrespective of whether reliable sessions are enabled or not, the session id's will be same. 




Part 40 WCF 서비스 및 클라이언트 애플리케이션에서 세션 ID를 검색하는 방법

특정 클라이언트에서 서버의 특정 서비스 인스턴스로 메시지를 보내기 위해 WCF는 SessionId를 사용합니다.

클라이언트 1 <--------------------------> Client1의 서비스 인스턴스
SID : 92F88DCC -..... SID : 92F88DCC -.....

클라이언트 2 <--------------------------> Client2 용 서비스 인스턴스
SID : FB1BA179 -..... SID : FB1BA179 -.....

참고 : WCF에는 여러 유형의 세션이 있습니다.
나중에 비디오 세션에서 더 자세히 설명하겠습니다.

클라이언트 응용 프로그램에서 SessionId를 검색하려면
    procyClassInstance.InnerChannel.SessionId

WCF 서비스에서 SessionId를 검색하려면
    OperationContext.Current.SessionId

클라이언트 측 및 서비스 측 세션 ID는 신뢰할 수있는 세션 ID를 사용하여 상호 연관됩니다.
따라서 신뢰할 수있는 세션을 비활성화 한 상태에서 TCP 바인딩을 사용하면 클라이언트 및 서버 세션 ID가 달라집니다.
반면 신뢰할 수있는 세션이 활성화 된 경우 세션 ID는 동일합니다.
<바인딩>
   <netTcpBinding>
      <binding name = "netTCP"receiveTimeout = "00:00:10">
         <reliableSession enable = "true"/>
      </ binding>
   </ netTcpBinding>
</ 바인딩>

wsHttpBinding을 사용하면 신뢰할 수있는 세션이 활성화되었는지 여부에 관계없이 세션 ID가 동일합니다.
*/