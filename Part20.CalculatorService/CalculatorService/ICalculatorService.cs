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
        /*Part 19 Strongly Typed SOAP Faults*/
        [FaultContract(typeof(DivideByZeroFault))]
        [OperationContract]
        int Divide(int Numerator, int Denominator);
    }
}

/* 간략히 스텝 기술
 *  Step1 :  오류처리기(GlobalErrorHanler) 작성
 *  Step2 :  에러핸들러 특성 클래스 작성 (GlobalErrorHandlerBehavorAttribute)
 *  Step3 :  CalculatorService 특성에 GlobalErrorHandlerBehavorAttribute 특성 기술
 */
/* 연계 설명
 * - GlobalErrorHandlerBehavorAttribute 클래스는 Attribute를 상속받는 특성 클래스로서 
 *   생성자는 오류처리기(GlobalErrorHanler)를 파라미터로 받고 
 *   ApplyDispatchBehavior() 메소드는 채널 디스패처의  에러핸들러에 파라미터를 연결시킨다. 
 * - GlobalErrorHandlerBehavorAttribute 특성 클래스는 서비스 클래스(CalculatorService)의 특성에 기술된다. 
 * - 서비스 클래스(CalculatorService)가 서비스 될때 오류처리기는 GlobalErrorHandlerBehavorAttribute로 집중화 될 것이다.
*/

/*Part 20 Centralized Exception Handling in WCF 

How to handle all WCF service exceptions in one central location? 
In an ASP.NET web applications we can use Application_Error() event handler method in Global.aspx to log 
 all the exceptions and redirect the user to a custom error page
In WCF, to centralize exception handling and to reutrn a general fault reason to the client, we implement IErrorHandler interface.
Three steps to centralize exception handling in WCF

Step 1: Implement IErrorHandler interface
public class GlobalErrorHandler : IErrorHandler
{
    public bool HandleError(Exception error)
    {
        //log the actual exception for the IT Team to investigate
        // return true to indicate that the exception is handled 
        return true; 
    }

    public void ProvideFault(Exception error, MessageVersion version, ref Messge fault)
    {
        if(error is FaultException)
            return;
        // Return a general service error message to the client
        FaultException faultException = new FaultException("A general service error occured");
        MessageFault messageFault = faultException.CreateMessageFault();
        fault = Message.CreateMessage(version, messgaeFault, null);
    }
}
  
IErrorHandler inerface has 2 methods
    ProvideFault()
    HandleError() 
 
    1) ProvideFault() - This method gets called automatically when there is an unhandled exception or a fault.
        In this method we have the opportunity to write code to convert the unhandled exception into a generic fault that can be returned to the client.

    2) HandleError() - This method gets called asynchronously after ProvideFault() method is called and the error message is returned to the client.
        This means that this method allows us to write code to log the exception without blocking the client call.
 
Step 2 : Create a custom Service Behavior Attribute to let WCF know that we want to use the GlobalErrorHandler calss whenever an unhandled exception occurs.
 
 * public class GlobalErrorHandlerBehaviourAttribute : Attribute, IServiceBehavior
    {
        ....
    } 

Step 3: Decoreate CalculatorService class in CalculatorService.cs file with GlobalErrorHandlerBehaviourAttribute.
    [GlobalErrorHandlerBehaviour(typeof(GlobalErrorHandler))]
    public class CalculatorService : IcalculatorService {...}
 
Part 20 WCF의 중앙 집중식 예외 처리
하나의 중앙 위치에서 모든 WCF 서비스 예외를 처리하는 방법은 무엇입니까?
ASP.NET 웹 응용 프로그램에서 Global.aspx의 Application_Error () 이벤트 처리기 메서드를 사용하여 
모든 예외를 기록하고 사용자를 사용자 지정 오류 페이지로 리디렉션 할 수 있습니다.
WCF에서는 예외 처리를 중앙 집중화하고 일반적인 오류 원인을 클라이언트에 반환하기 위해 IErrorHandler 인터페이스를 구현합니다.
WCF에서 예외 처리를 중앙 집중화하는 3 단계

1 단계 : IErrorHandler 인터페이스 구현
...

IErrorHandler inerface에는 두 가지 메서드가 있습니다.
    ProvideFault ()
    HandleError ()
 * 
    1) ProvideFault ()-이 메서드는 처리되지 않은 예외 또는 오류가있을 때 자동으로 호출됩니다.
        이 메서드에서는 처리되지 않은 예외를 클라이언트에 반환 할 수있는 일반 오류로 변환하는 코드를 작성할 수 있습니다.

    2) HandleError ()-이 메서드는 ProvideFault () 메서드가 호출되고 오류 메시지가 클라이언트에 반환 된 후 비동기 적으로 호출됩니다.
        즉,이 메서드를 사용하면 클라이언트 호출을 차단하지 않고 예외를 기록하는 코드를 작성할 수 있습니다.

2 단계 : 사용자 지정 서비스 동작 특성을 만들어 WCF에 처리되지 않은 예외가 발생할 때마다 GlobalErrorHandler calss를 사용할 것임을 알린다.

    public class GlobalErrorHandlerBehaviourAttribute : Attribute, IServiceBehavior
    {
        ....
    } 
  
3 단계 : GlobalErrorHandlerBehaviourAttribute를 사용하여 CalculatorService.cs 파일의 CalculatorService 클래스를 장식합니다.
      [GlobalErrorHandlerBehaviour(typeof(GlobalErrorHandler))]
        public class CalculatorService : IcalculatorService {...}
 * 
 * 
 * 

 * 
 */
