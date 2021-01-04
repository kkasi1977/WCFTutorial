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

/* Part 44 Multiple concurrency mode in WCF 

With Multiple concurrency mode an exclusive lock is not acquired on the service instance. 
This means multiple threads are allowed to access the service instance simultaneously and we get better throughput. 
However, shared resources if any must be protected from concurrent access by multiple threads to avoid convurrency issues. 

In Part93 in C# video series, we discussed
1. What happens if shared resources are not protected from concurrent access in a multithreaded environment 
2. How to protect shared resources from concurrent access 

When concurrency mode is set to Multiple, requests are processed concurrently by the service instance irrespective of the Service Instance Context Mode and whethe if the binding supports session or not. 


파트 44 WCF의 다중 동시성 모드

다중 동시성 모드를 사용하면 서비스 인스턴스에서 배타적 잠금이 획득되지 않습니다.
즉, 여러 스레드가 동시에 서비스 인스턴스에 액세스 할 수 있으며 처리량이 향상됩니다.
그러나 동시성 문제를 방지하려면 여러 스레드의 동시 액세스로부터 공유 리소스를 보호해야합니다.

C # 비디오 시리즈의 Part93에서
1. 다중 스레드 환경에서 공유 리소스가 동시 액세스로부터 보호되지 않으면 어떻게됩니까?
2. 동시 액세스로부터 공유 리소스를 보호하는 방법

동시성 모드가 다중으로 설정되면 서비스 인스턴스 컨텍스트 모드 및 바인딩이 세션을 지원하는지 여부에 관계없이 
서비스 인스턴스에서 요청을 동시에 처리합니다.
*/ 
