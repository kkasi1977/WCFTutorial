﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "ISimpleService"을 변경할 수 있습니다.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ISimpleService
    {
        [OperationContract]
        int IncrementNumber();
    }
}

/*Part 42 SessionMode Enumeration
Use SessionMode enumeration with the Service Contract to require, allow, or prohibit bindings to use sessions.

Allowed : Service contract supports sessions if the binding supports them. 

NotAllowed : Service contract does not support bindings that initiate sessions.

Required : Service contract requires a binding that supports session. 

Example 1 : Set the service InstanceContextMode to Single and SessionMode to Allowed. 

If we use basicHttpBinding that does not support sessions, the service still works as a singleton service but without session.  

One the other hand if we use, netTcpBinding that support sessions, the service gets a session, and continue to work as a singleton service.  

Example 2 : Now change SessionMode to Required. 

If we use, netTcpBinding that support sessions, the service gets a session, and continue to work as a singleton service. 

On the other hand, if we use basicHttpBinding that does not support sessions, the following exception is thrown 
System.InvalidOperationException: Contract requires Session, but Binding 'BasicHttpBinding' doesn't support it or isn't configured properly to support it. 

The following MSDN link, shows all the possible combinations of Service InstanceContextMode values and SessionMode enumeration values, and the end result of using each of these combinations with bindings that does and does not support sessions. 
http://msdn.microsoft.com/en-us/library/system.servicemodel.sessionmodel(v=vs.110).aspx



Part 42 SessionMode 열거 형
세션을 사용하기위한 바인딩을 요구, 허용 또는 금지하려면 서비스 계약과 함께 SessionMode 열거를 사용합니다.

허용됨 : 바인딩이 지원하는 경우 서비스 계약이 세션을 지원합니다.

NotAllowed : 서비스 계약은 세션을 시작하는 바인딩을 지원하지 않습니다.

필수 : 서비스 계약에는 세션을 지원하는 바인딩이 필요합니다.

예 1 : 서비스 InstanceContextMode를 Single로 설정하고 SessionMode를 Allowed로 설정합니다.

세션을 지원하지 않는 basicHttpBinding을 사용하는 경우 서비스는 여전히 단일 서비스로 작동하지만 세션은 없습니다.

다른 한편으로 세션을 지원하는 netTcpBinding을 사용하면 서비스가 세션을 가져 와서 싱글 톤 서비스로 계속 작동합니다.

예제 2 : 이제 SessionMode를 Required로 변경하십시오.

세션을 지원하는 netTcpBinding을 사용하면 서비스가 세션을 가져 와서 싱글 톤 서비스로 계속 작동합니다.

반면 세션을 지원하지 않는 basicHttpBinding을 사용하면 다음과 같은 예외가 발생합니다.
System.InvalidOperationException : 계약에 세션이 필요하지만 'BasicHttpBinding'바인딩이이를 지원하지 않거나이를 지원하도록 적절하게 구성되지 않았습니다.

다음 MSDN 링크는 Service InstanceContextMode 값과 SessionMode 열거 형 값의 가능한 모든 조합과 세션을 지원하거나 지원하지 않는 바인딩과 함께 이러한 각 조합을 사용한 최종 결과를 보여줍니다.
http://msdn.microsoft.com/en-us/library/system.servicemodel.sessionmodel(v=vs.110).aspx
*/