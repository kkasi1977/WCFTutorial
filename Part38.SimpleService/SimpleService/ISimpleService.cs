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

/*Part 38 PerSession instance context mode

When the instance context mode for a wcf serice is set to PerSession, a new instance of the service object is created for each new client session and maintained for the duration of that session.

What are the implications of a PerCall WCF service?
1. State maintained between calls.

2. Greater memory consumption as serevice objects remain in memory until the client session times out.
This negatively affects application scalability.

3. Concurrency is an issue for multi-threaded clients

Common interview question : How do you design a WCF service?
 Would you design it as a PerCall service or PerSession service?
1. PerCall and PerSession services have different strengths and weaknesses.

2. If you prefer using object oriented programming style, then PerSession is our choice. 
One the other hand if you prefer SOA(Service Oriented Arhcitecture)style, then PerCall is your choice.

3. In general, all things being equal, the trade-off is performance v/s scalability.
PerSession services perform better because the service object does not have to be instantiated on subsequent requests.
PerCall services scale better because the service objects are destoryed immediately after the method call returns.

So the decision reall depends on the application architecture, performance & scalability needs.


Part 38 PerSession 인스턴스 컨텍스트 모드

wcf 서비스에 대한 인스턴스 컨텍스트 모드가 PerSession으로 설정되면 서비스 개체의 새 인스턴스가 각 새 클라이언트 세션에 대해 생성되고 해당 세션 동안 유지됩니다.

PerCall WCF 서비스의 의미는 무엇입니까?
1. 통화 사이에 상태가 유지됩니다.

2. 클라이언트 세션이 시간 초과 될 때까지 서비스 개체가 메모리에 남아 있으므로 더 많은 메모리 소비.
이는 애플리케이션 확장성에 부정적인 영향을 미칩니다.

3. 동시성은 다중 스레드 클라이언트의 문제입니다.

일반적인 인터뷰 질문 : WCF 서비스를 어떻게 디자인합니까?
 PerCall 서비스 또는 PerSession 서비스로 설계 하시겠습니까?
1. PerCall 및 PerSession 서비스는 장단점이 다릅니다.

2. 객체 지향 프로그래밍 스타일을 선호한다면 PerSession이 우리의 선택입니다.
한편, SOA (Service Oriented Arhcitecture) 스타일을 선호한다면 PerCall을 선택하십시오.

3. 일반적으로 모든 것이 동일 할 때 성능 대 확장 성이 절충됩니다.
PerSession 서비스는 서비스 개체가 후속 요청에서 인스턴스화 될 필요가 없기 때문에 더 나은 성능을 발휘합니다.
PerCall 서비스는 메서드 호출이 반환 된 직후에 서비스 개체가 제거되므로 확장 성이 향상됩니다.

따라서 결정 영역은 애플리케이션 아키텍처, 성능 및 확장 성 요구 사항에 따라 달라집니다.
*/