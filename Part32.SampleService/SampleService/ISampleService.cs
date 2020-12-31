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
    }
}


/*
Part 32 Messge Exchange Patterns in WCF

Message Exchange Pattern describes how the client and the wcf service exchange messages.
1. Request-Reply (Default)
2. One-Way
3. Duplex

Request-Reply:
1. This is the default Message Exchange Pattern
2. Client sends a message to a WCF Service and then waits for a reply.
 During this time the client stops processing until a response is received from the wcf service. 
3. The client waits for the service call to complete even if the operation return type is void.
4. All WCF bindings except the MSMQ-based bindings support the Request-Reply Message Exchange Pattern.
5. In a Request-Reply message exchange pattern faults and exceptions get reported to the client immediately if any. 
    IsOneWay parameter of OperationContract attribute specifies the Message Exchange Pattern. 
    The default value ofr IsOneWay parameter is false.
    This means that, if we don't specify this parameter, then the Message Exchange Pattern is Request/Reply.
    So the following 2 declareation are equivalent.
        ex1)
        [OperationContract(IsOneWay = false)]
        string RequestReplyOperation();
        ex2)
        [OperationContract]
        string RequestReplyOperation();



Part 32 WCF의 메시지 교환 패턴

메시지 교환 패턴은 클라이언트와 wcf 서비스가 메시지를 교환하는 방법을 설명합니다.
1. 요청-응답 (기본값)
2. 단방향
3. 이중

요청-응답 :
1. 이것이 기본 메시지 교환 패턴입니다.
2. 클라이언트가 WCF 서비스에 메시지를 보낸 다음 응답을 기다립니다.
  이 시간 동안 클라이언트는 wcf 서비스에서 응답을받을 때까지 처리를 중지합니다.
3. 클라이언트는 오퍼레이션 리턴 유형이 무효 인 경우에도 서비스 호출이 완료되기를 기다립니다.
4. MSMQ 기반 바인딩을 제외한 모든 WCF 바인딩은 요청-응답 메시지 교환 패턴을 지원합니다.
5. 요청-응답 메시지 교환 패턴에서 오류 및 예외가 있으면 즉시 클라이언트에보고됩니다.
    OperationContract 특성의 IsOneWay 매개 변수는 메시지 교환 패턴을 지정합니다.
    IsOneWay 매개 변수의 기본값은 false입니다.
    즉,이 매개 변수를 지정하지 않으면 메시지 교환 패턴이 요청 / 응답입니다.
    따라서 다음 두 선언은 동일합니다.
 
    ex1)
    [OperationContract (IsOneWay = false)]
    문자열 RequestReplyOperation ();
    ex2)
    [OperationContract]
    문자열 RequestReplyOperation ();
 */
