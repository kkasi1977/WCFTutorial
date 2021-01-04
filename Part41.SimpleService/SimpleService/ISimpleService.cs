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

/*Part 41 Single instance context mode in WCF

When the instance context mode for a wcf service is set to Single, only one instance of the wcf service class is created to handle all requests, from all clients.

Set InstanceContextMode to Single, to create a single instance of a WCF service that handles all requests from all clients. 
[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
public class SimpleService : ISimpleService

Implications of creating a wcf serice with Single instance context mode: 
1. Since a single service instance is serving all client requests, state is maintained and shared not only between requests from the same client but also between different clients. 

2. Concurrency is an issue

3. Throughput can be an issue. To fix the concurrency issue,  we can configure the service to allow only a single thread to access the service instance. 
But the moment we do it throughtput becomes an issue as other requests queue up and wait for the current thread to finish it's work.


Part 41 WCF의 단일 인스턴스 컨텍스트 모드

wcf 서비스의 인스턴스 컨텍스트 모드가 Single로 설정되면 모든 클라이언트의 모든 요청을 처리하기 위해 wcf 서비스 클래스의 인스턴스 하나만 생성됩니다.

InstanceContextMode를 Single로 설정하여 모든 클라이언트의 모든 요청을 처리하는 WCF 서비스의 단일 인스턴스를 만듭니다.
[ServiceBehavior (InstanceContextMode = InstanceContextMode.Single)]
공용 클래스 SimpleService : ISimpleService

단일 인스턴스 컨텍스트 모드로 wcf serice 생성의 의미 :
1. 단일 서비스 인스턴스가 모든 클라이언트 요청을 처리하기 때문에 동일한 클라이언트의 요청뿐만 아니라 다른 클라이언트 간에도 상태가 유지되고 공유됩니다.

2. 동시성이 문제

3. 처리량이 문제가 될 수 있습니다. 동시성 문제를 해결하기 위해 단일 스레드 만 서비스 인스턴스에 액세스 할 수 있도록 서비스를 구성 할 수 있습니다.
그러나 처리하는 순간 다른 요청이 대기열에 대기하고 현재 스레드가 작업을 완료 할 때까지 대기하므로 처리량이 문제가됩니다.



*/