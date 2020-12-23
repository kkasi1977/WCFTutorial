using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculatorService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "ICalculatorService"을 변경할 수 있습니다.
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        int Divide(int Numerator, int Denominator);
    }
}




/* ## Part 15 Exception handling in WCF
When an exception occurs in a WCF service, the service serializes the exception into a SOAP fault, and then sends the SOAP fault to the client.

By default unhandled exception details are not included in SOAP faults that are propagated to client applications for security reasons. 
Instead a generic SOAP fault is returned to the client.

For debugging purpose, if you want to include exception details in SOAP faults, enable IncludeExceptionDetailInFaults setting. 
This can be done in 2 ways shown below.
 
1. In the config file using service behavior configuration
<behaviors>
 <serviceBehaviors>
  <behavior name="includeExceptionDetails">
   <serviceDebug includeExceptionDetailInFaults="true"/>
  </behavior> 
 </serviceBehaviors>
</behaviors>
 * 
2. In code using Service Behavior attribute
[ServiceBehavior(IncludeExceptionDetailInFaults=true)]
public class CalulatorService : ICalculatorService
{...


Part 15 WCF의 예외 처리
WCF 서비스에서 예외가 발생하면 서비스는 예외를 SOAP 오류로 직렬화 한 다음 SOAP 오류를 클라이언트로 보냅니다.

기본적으로 처리되지 않은 예외 세부 정보는 보안상의 이유로 클라이언트 응용 프로그램에 전파되는 SOAP 오류에 포함되지 않습니다.
대신 일반 SOAP 오류가 클라이언트에 반환됩니다.

디버깅 목적으로 SOAP 오류에 예외 세부 정보를 포함하려면 IncludeExceptionDetailInFaults 설정을 활성화합니다.
아래에 표시된 두 가지 방법으로 수행 할 수 있습니다.
1. 서비스 동작 구성을 사용하는 구성 파일에서
2. 서비스 동작 구성을 사용하는 구성 파일에서 
 * 
 * 
 * WCF의 예외는 soap로 직렬화된다.
클라이언트에 반환되기 전에 떨어지며 기본적으로 예외 정보는 다음과 같다.
클라이언트로 전송되는 soap 저장소에 포함되지 않으며 
WCF가 수행하는 이유는 기본적으로 보안상의 이유와 디버깅 목적.
soap에 예외 세부사항을 포함시키려면 true로 설정한다. (구성파일이나 코드에서
*/
