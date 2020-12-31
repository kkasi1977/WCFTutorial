﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SampleService
{
    [ServiceContract]
    public interface ISampleService
    {
 
        [OperationContract(IsOneWay = false)]
        string RequestReplyOperation();

        [OperationContract]
        string RequestReplyOperation_ThrowsException();

        //Part 33 OneWay Message Exchange Pattern
        [OperationContract(IsOneWay = true)]
        void OneWayOperation();

        [OperationContract(IsOneWay = true)]
        void OneWayOperation_ThrowsException();
    }
}


/*Part 33 OneWay Message Exchange Pattern 

In a Request-Reply pattern, the client sends a message to the WCF service and then waits for the reply message, even if the service operation's return type is void.

In case of One-Way operation, only one message is exchanged between the client and the service. 
The client makes a call to the service method, but does not wait for a response message.
So, in short, the receiver of the message does not send a reply message, nor does the sender of the mesage expects one. 

To make an operation one-way, set IsOneWay=true
ex)
[OperationContract(IsOneWay=true)]
void OneWayOperation();

As messages are exchanged only in one way, faults does not get reported.
Clients are unaware of the server channel faults until a subsequent all is made. 

An exception will be thrown, if operations marked with IsOneWay=true declares output parameters, by-reference parameters or return value. 

Are OneWay calls same as asynchronous calls?
No, they are not. When a oneway call is received at the service, and if the service is busy serving other requests, then the call gets queued and the client is unblocked and can continue executing while the service processes the operation in the background.  
One-way calls can still block the client, if the number of messages waiting to be processed has exceeded the server queue limit. 
So, OneWay calls are not asynchronous calls, they just appear to be asynchronous. 

Part 33 OneWay 메시지 교환 패턴

요청-응답 패턴에서 클라이언트는 WCF 서비스에 메시지를 보낸 다음 서비스 작업의 반환 형식이 void 인 경우에도 응답 메시지를 기다립니다.

단방향 운영의 경우 클라이언트와 서비스간에 하나의 메시지 만 교환됩니다.
클라이언트는 서비스 메소드를 호출하지만 응답 메시지를 기다리지 않습니다.
즉, 메시지 수신자는 응답 메시지를 보내지 않으며 메시지 발신자도이를 기대하지 않습니다.

작업을 단방향으로 만들려면 IsOneWay = true로 설정합니다.
ex)
[OperationContract (IsOneWay = true)]
void OneWayOperation ();

메시지는 한 방향으로 만 교환되므로 오류가보고되지 않습니다.
클라이언트는 후속 조치가 모두 이루어질 때까지 서버 채널 오류를 인식하지 못합니다.

IsOneWay = true로 표시된 작업이 출력 매개 변수, 참조 매개 변수 또는 반환 값을 선언하면 예외가 발생합니다.

OneWay 호출은 비동기 호출과 동일합니까?
아니요, 그렇지 않습니다. 서비스에서 단방향 호출이 수신되고 서비스가 다른 요청을 처리하는 중이면 호출이 대기열에 추가되고 클라이언트가 차단 해제되고 서비스가 백그라운드에서 작업을 처리하는 동안 계속 실행할 수 있습니다.
처리 대기중인 메시지 수가 서버 큐 제한을 초과 한 경우 단방향 호출은 여전히 ​​클라이언트를 차단할 수 있습니다.
따라서 OneWay 호출은 비동기 호출이 아니라 비동기로 보입니다.
 * */
 