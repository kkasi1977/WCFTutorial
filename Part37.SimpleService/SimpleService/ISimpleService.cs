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

/*Part 37 PerCall instance context mode in WCF 

When the instance context mode for a wcf service is set to PerCall, a new instance of the wcf service object is created for every request, 
irrespective of where the request come form the same client or a different client. 

What are the implications of a PerCall WCF service? 
1. Better memory usage as service objects are freed immediately after the mothod call returns
2. Concurrency not an issue
3. Application scalability is better 
4. State not maintained between calls.
5. Performance could be an issue as there is overhead involved in reconstructing the service instance state on each and every method call.


Part 37 WCF의 PerCall 인스턴스 컨텍스트 모드

wcf 서비스의 인스턴스 컨텍스트 모드가 PerCall로 설정되면 모든 요청에 대해 wcf 서비스 객체의 새 인스턴스가 생성됩니다.
요청이 동일한 클라이언트 또는 다른 클라이언트에서 오는 위치와 관계없이.

PerCall WCF 서비스의 의미는 무엇입니까?
1. mothod 호출이 반환 된 직후에 서비스 개체가 해제되므로 메모리 사용량이 향상됩니다.
2. 동시성은 문제가 아닙니다.
3. 애플리케이션 확장 성이 더 우수합니다.
4. 통화 사이에 상태가 유지되지 않습니다.
5. 각각의 모든 메서드 호출에서 서비스 인스턴스 상태를 재구성하는 데 관련된 오버 헤드가 있으므로 성능이 문제가 될 수 있습니다.
*/