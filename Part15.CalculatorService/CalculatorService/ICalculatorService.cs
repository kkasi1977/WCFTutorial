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

/* Part 16 Soap faults in WCF
WCF serializes exceptions to SOAP faults before reporting the exception information to the client. 
This is because exceptions are not allowed to be passed through a wcf service channel.

SOAP faults are in XML format and are platform independent.
A typical SOAP fault contains
1. FaultCode
2. FaultReason
3. Detail elements etc.

The Detail element can be used to include any custom xml

SOAP faults are formatted based on SOAP 1.1 or SOAP 1.2 speficications.
SOAP format depends on the binding.
BasicHttpBinding uses SOAP 1.1 whereas the other built-in WCF bindings use SOAP 1.2.

For the differences between SOAP 1.1 and 1.2 please refer to the following article. 
The differences are not that important from a developer perspective, as WCF formats the messages automatically based on the binding we have used to expose the service.
http://www.w3.org/2003/06/soap11-soap12.html

To view SOAP Fault messages, please enable message logging in WCF. 
We have discussed enabling message logging in Part9 of WCF video series.

 To view SOAP 1.2 fault message, set binding to wsHttpBinding. By default Message Security is turned on for wsHttpBinding.
Set the security mode for wsHttpBinding to None, so we could view the SOAP 1.2 fault message.

WCF는 예외 정보를 클라이언트에보고하기 전에 SOAP 오류에 대한 예외를 직렬화합니다.
wcf 서비스 채널을 통해 예외가 전달 될 수 없기 때문입니다.

SOAP 오류는 XML 형식이며 플랫폼에 독립적입니다.
일반적인 SOAP 오류에는 다음이 포함됩니다.
1. FaultCode
2. FaultReason
3. 세부 요소 등

Detail 요소는 모든 사용자 정의 xml을 포함하는 데 사용할 수 있습니다.

SOAP 결함은 SOAP 1.1 또는 SOAP 1.2 사양에 따라 형식이 지정됩니다.
SOAP 형식은 바인딩에 따라 다릅니다.
BasicHttpBinding은 SOAP 1.1을 사용하는 반면 다른 기본 제공 WCF 바인딩은 SOAP 1.2를 사용합니다.

SOAP 1.1과 1.2의 차이점은 다음 기사를 참조하십시오.
WCF는 서비스를 노출하는 데 사용한 바인딩을 기반으로 메시지를 자동으로 형식화하므로 개발자 관점에서 차이점은 그다지 중요하지 않습니다.
http://www.w3.org/2003/06/soap11-soap12.html

SOAP 오류 메시지를 보려면 WCF에서 메시지 로깅을 활성화하십시오. 
WCF 비디오 시리즈의 Part9에서 메시지 로깅 활성화에 대해 논의했습니다.

  SOAP 1.2 오류 메시지를 보려면 바인딩을 wsHttpBinding으로 설정하십시오. 기본적으로 메시지 보안은 wsHttpBinding에 대해 설정되어 있습니다.
wsHttpBinding의 보안 모드를 None으로 설정하여 SOAP 1.2 오류 메시지를 볼 수 있습니다.
 * 
*/

/* ## Part 16 Test step by step
 * 1. Microsoft Service Configuration Editor 로 app.config를 편집한다.
 * Diagnostics -> Log Auto Flush -> On
 * Diagnostics -> MessaegLogging -> On
 *      Message Logging -> LogEntireMessage -> True
 * 
 * 2. app.config의 다음 항목을 false로 수정한다. 
 *      serviceDebug includeExceptionDetailInFaults="false"
 * 3.  0 나누기 오류를 발생시킨다.
 * 4. 로그파일을 Microsoft Service Trace Viewer로 연다.
 *      - app_messages.svclog 
 * 5. 최종 오류메시지의 soap형태를 확인한다. 오류코드, 오류이유를 확인한다.  
 *    그러나 soap에 예외 세부사항이 포함되지는 않았다. ( 2번항목에서 false때문)
 * <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
        <s:Body>
            <s:Fault>
                <faultcode xmlns:a="http://schemas.microsoft.com/net/2005/12/windowscommunicationfoundation/dispatcher" xmlns="">a:InternalServiceFault</faultcode>
                <faultstring xml:lang="ko-KR" xmlns="">내부 오류로 인해 서버에서 요청을 처리할 수 없습니다. 오류에 대한 자세한 내용을 보려면 클라이언트에 예외 정보를 다시 보낼 수 있도록 서버에서 ServiceBehaviorAttribute 또는 <serviceDebug>구성 동작의 IncludeExceptionDetailInFaults를 설정하거나, Microsoft .NET Framework SDK 설명서마다 추적 기능을 설정하여 서버 추적 로그를 확인하십시오.</faultstring>
            </s:Fault>
        </s:Body>
    </s:Envelope>

 * 5.  app.config의 다음 항목을 true로 수정한다. 
 *      serviceDebug includeExceptionDetailInFaults="true"
 * 6. 0나누기 오류를 발생시킨다.
 * 7. 로그파일을 Microsoft Service Trace Viewer로 연다.
 *      - app_messages.svclog 
 * 8. 최종 오류메시지의 soap형태를 확인한다.  
 *     3가지 형태 로깅되어 있다.
 * <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
    <s:Body>
        <s:Fault>
            <faultcode xmlns:a="http://schemas.microsoft.com/net/2005/12/windowscommunicationfoundation/dispatcher" xmlns="">a:InternalServiceFault</faultcode>
            <faultstring xml:lang="ko-KR" xmlns="">0으로 나누려 했습니다.</faultstring>
            <detail xmlns="">
                <ExceptionDetail xmlns="http://schemas.datacontract.org/2004/07/System.ServiceModel" xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
                <HelpLink i:nil="true"></HelpLink>
                <InnerException i:nil="true"></InnerException>
                <Message>0으로 나누려 했습니다.</Message>
                <StackTrace>
                위치: CalculatorService.CalculatorService.Divide(Int32 Numerator, Int32 Denominator) 파일 C:\git\WCFTutorial\Part15.CalculatorService\CalculatorService\CalculatorService.cs:줄 16위치: SyncInvokeDivide(Object , Object[], Object[])위치: System.ServiceModel.Dispatcher.SyncMethodInvoker.Invoke(Object instance, Object[]inputs, Object[]&outputs)위치: System.ServiceModel.Dispatcher.DispatchOperationRuntime.InvokeBegin(MessageRpc&rpc)위치: System.ServiceModel.Dispatcher.ImmutableDispatchRuntime.ProcessMessage5(MessageRpc&rpc)위치: System.ServiceModel.Dispatcher.ImmutableDispatchRuntime.ProcessMessage41(MessageRpc&rpc)위치: System.ServiceModel.Dispatcher.ImmutableDispatchRuntime.ProcessMessage4(MessageRpc&rpc)위치: System.ServiceModel.Dispatcher.ImmutableDispatchRuntime.ProcessMessage31(MessageRpc&rpc)위치: System.ServiceModel.Dispatcher.ImmutableDispatchRuntime.ProcessMessage3(MessageRpc&rpc)위치: System.ServiceModel.Dispatcher.ImmutableDispatchRuntime.ProcessMessage2(MessageRpc&rpc)위치: System.ServiceModel.Dispatcher.ImmutableDispatchRuntime.ProcessMessage11(MessageRpc&rpc)위치: System.ServiceModel.Dispatcher.ImmutableDispatchRuntime.ProcessMessage1(MessageRpc&rpc)위치: System.ServiceModel.Dispatcher.MessageRpc.Process(Boolean isOperationContextSet)
                </StackTrace>
                <Type>System.DivideByZeroException</Type>
                </ExceptionDetail>
            </detail>
        </s:Fault>
    </s:Body>
    </s:Envelope>
 * 
 * 9. app.config의 서비스 바인딩을 변경한다. 
 *    basicHttpBinding -> wsHttpBinding
 * 10. 서비스를 실행한다. 
 * 11. 클라이언트의 서비스 참조를 업데이트 한다.
 * 12. 0나누기오류일으키고 로그확인하면 메시지가 보안이 되지 않았다.
 * 13 app.config에 bindings를 추가한다. 
 *  wsHttpBinding 의  security mode를  none으로 설정한다.
 *  14. 0나누기 오류를 발생하고 로그를 확인 후 soap 형태를 본다
 */

