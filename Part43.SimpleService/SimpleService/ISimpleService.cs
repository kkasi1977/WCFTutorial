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
        List<int> GetEvenNumbers();

        [OperationContract]
        List<int> GetOddNumbers();
    }
}

/*Part 43 Single concurreny mode in WCF 
 * 
To understand concurrency better, we need to understand 
Instance Context Modes in  WCF - Discussed in Part 36 to 42 in WCF video series
Multithreading concepts - Discussed in Parts 86 to 97 in C# video series 

In addition we also need to understand the term throughput. 
Throughput is the amount of work done in a specified amount of time. 

Multiple threads executing the application code simultaneously is called as concurrency. 
In general with concurrency we get better throughtput. 
However, concurrency issues can occur when multiple threads access the same resource. 
In WCF, Service Instance is a shared resource. 

The default concurrency mode in WCF is Single. 
This means only a single thread can access the service instance at any given point in time. 
While a request is being processed by the service instance, and exclusive lock is acquired and all the other threads will have to wait until the current request completes and the lock is released. 
Upon releasing the lock, next thread in the queue can access the service instance. 

ConcurrencyMode parameter of the ServiceBehavior attribute controls the concurrency setting. 
ConcurrencyMode can be - Single, Reentrant or Multiple 
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]

Whether a WCF service handles client requests concurrently or not depends on 3 things 
1. Service InstanceConextMode
2. Service ConcurrencyMode
3. Where if the binding supports session or not 
 

Part 43 WCF의 단일 동시성 모드
동시성을 더 잘 이해하려면
WCF의 인스턴스 컨텍스트 모드-WCF 비디오 시리즈의 36 ~ 42 부에서 논의 됨
멀티 스레딩 개념-C # 비디오 시리즈의 86-97 부에서 논의 됨

또한 처리량이라는 용어도 이해해야합니다.
처리량은 지정된 시간 동안 수행 된 작업의 양입니다.

애플리케이션 코드를 동시에 실행하는 여러 스레드를 동시성이라고합니다.
일반적으로 동시성을 사용하면 처리량이 향상됩니다.
그러나 여러 스레드가 동일한 리소스에 액세스 할 때 동시성 문제가 발생할 수 있습니다.
WCF에서 서비스 인스턴스는 공유 리소스입니다.

WCF의 기본 동시성 모드는 단일입니다.
즉, 주어진 시점에서 단일 스레드 만 서비스 인스턴스에 액세스 할 수 있습니다.
요청이 서비스 인스턴스에 의해 처리되고 배타적 잠금이 획득되고 다른 모든 스레드는 현재 요청이 완료되고 잠금이 해제 될 때까지 기다려야합니다.
잠금을 해제하면 큐의 다음 스레드가 서비스 인스턴스에 액세스 할 수 있습니다.

ServiceBehavior 속성의 ConcurrencyMode 매개 변수는 동시성 설정을 제어합니다.
ConcurrencyMode는 단일, 재진입 또는 다중 일 수 있습니다.
[ServiceBehavior (ConcurrencyMode = ConcurrencyMode.Single)]

WCF 서비스가 클라이언트 요청을 동시에 처리하는지 여부는 세 가지에 따라 다릅니다.
1. 서비스 InstanceConextMode
2. 서비스 ConcurrencyMode
3. 바인딩이 세션을 지원하는지 여부
 * 
*/ 
