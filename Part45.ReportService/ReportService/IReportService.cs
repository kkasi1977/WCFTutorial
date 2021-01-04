﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ReportService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IReportService"을 변경할 수 있습니다.
    [ServiceContract(CallbackContract = typeof(IReportServiceCallback))]
    public interface IReportService
    {
        [OperationContract]
        void ProcessReport();
    }

    public interface IReportServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReportProgress(int percentageCompleted);
    }
}

/* Part 45 Reentrant concurrency mode in WCF 

Reentrant concurrency mode allows the WCF service to issue callbacks to the client application

1. The WCF service concurrency mode is set to Single. 
This means only one thread is allowed to access the service instance. 

2. Client makes a request to the WCF Service. 
The service instance gets locked by the thread that is executing the client request. 
At this point no other thread can access the service instance, until the current thread has completed and released the lock. 

3. While the service instance is processing the client request, the service wants to callback the client. 
The callback operation is not one way. 
This means the response for the callback from the client needs to get back to the same service instance, but the service instance is locked and the response from the client cannot reenter and access the service instance. 
This situation leads to a deadlock. 

There are 2 ways to resolve the deadlock

Set the concurrency mode of the WCF service to Reentrant
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
public class ReportService : IReportService 

OR

Make the callback operation oneway. 
When the callback operation is made oneway, the service is not expecting a response for the callback from the client, 
so locking will not be an issue. 
public interface IReportServiceCallback
{
     [OperationContract(IsOneWay = true)]
     void ReportProgress(int percentageComplete);
}


Part 45 WCF의 재진입 동시성 모드

재진입 동시성 모드를 사용하면 WCF 서비스가 클라이언트 응용 프로그램에 콜백을 실행할 수 있습니다.

1. WCF 서비스 동시성 모드가 단일로 설정됩니다.
이는 하나의 스레드 만 서비스 인스턴스에 액세스 할 수 있음을 의미합니다.

2. 클라이언트가 WCF 서비스에 요청합니다.
서비스 인스턴스는 클라이언트 요청을 실행하는 스레드에 의해 잠 깁니다.
이 시점에서 현재 스레드가 잠금을 완료하고 해제 할 때까지 다른 스레드는 서비스 인스턴스에 액세스 할 수 없습니다.

3. 서비스 인스턴스가 클라이언트 요청을 처리하는 동안 서비스는 클라이언트를 콜백하려고합니다.
콜백 작업은 단방향이 아닙니다.
이는 클라이언트의 콜백에 대한 응답이 동일한 서비스 인스턴스로 돌아 가야하지만 서비스 인스턴스가 잠겨 있고 클라이언트의 응답이 서비스 인스턴스에 다시 들어가서 액세스 할 수 없음을 의미합니다.
이 상황은 교착 상태로 이어집니다.

교착 상태를 해결하는 방법에는 두 가지가 있습니다.

WCF 서비스의 동시성 모드를 재진입으로 설정
[ServiceBehavior (ConcurrencyMode = ConcurrencyMode.Reentrant)]
public class ReportService : IReportService 

또는

콜백 작업을 단방향으로 만듭니다.
콜백 작업이 단방향으로 이루어지면 서비스는 클라이언트의 콜백에 대한 응답을 기대하지 않습니다.
따라서 잠금은 문제가되지 않습니다.
public interface IReportServiceCallback
{
     [OperationContract(IsOneWay = true)]
     void ReportProgress(int percentageComplete);
}

*/