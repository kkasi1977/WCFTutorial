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

/* ## Part 19 Strongly Typed SOAP Faults
In Part 18, we discussed throwing a generic SOAP fault using FaultException class. 
Instead of throwing a generic SOAP fault, we can create strongly typed SOAP faults and throw them. 
Creating our own strongly typed SOAP faults allow us to include any additional custom information about the exception that has occurred.

Three steps to create a Strongly Typed SOAP fault : 
Step 1: Create a class that represents your SOAP fault.
Decorate the class with DataContract attribute and the properties with DataMember attribute. 
[DataContract]
public class DivideByZeroFault
{
    [DataMember]
    public string Error { get; set; }
    [DataMember]
    public string Details { get; set; }
}

Step 2 : In the service data contract, use FaultContractAttrigute to specify which operations can throw which SOAP faults.
[ServiceContract]
public interface ICaluatorService
{
    [FaultContract(typeof(DivideByZeroFault))]]
    [OperationContract]
    int Divide(int Numerator, int Denominator);
}

Step 3 : In the service implementation create an instance of the strongly typed SOAP fault and throw it using FaultException<T>  
 * try
 * {
 *      return Numberator / Denominator;
 * }
 * catch (DivideByZeroException ex)
 * {
 *      DivideByZeroFault divideByZeroFault = new DivideByZeroFault();
 *      divideByZeroFault.Error = ex.Message;
 *      divideByZeroFault.Details = "Denominator cannot be ZERO";
 *      
 *      throw new FaultException<DivideByZeroFault>(divideByZeroFault);
 * }
 *  
 * As we have changed the WCF service, update the service reference in the client application and modify the catch block as shown below.
 * 
 * ...
 * catch (FaultException<CalculatorService.DivideByZeroFault> faultException)
 * {
 *       lblResult.Text = faultException.Detail.Error + " - " +faultException.Detail.Details;
 * }
 *  
 *Part 19 강력한 형식의 SOAP 오류
Part 18에서 우리는 FaultException 클래스를 사용하여 일반적인 SOAP 오류를 던지는 것에 대해 논의했습니다.
일반 SOAP 오류를 발생시키는 대신 강력한 유형의 SOAP 오류를 생성하여 발생시킬 수 있습니다.
강력한 유형의 SOAP 오류를 생성하면 발생한 예외에 대한 추가 사용자 지정 정보를 포함 할 수 있습니다.

Strongly Typed SOAP 오류를 만드는 세 단계 :
1 단계 : SOAP 오류를 나타내는 클래스를 만듭니다.
DataContract 특성으로 클래스를 장식하고 DataMember 특성으로 속성을 장식합니다.
....

2 단계 : 서비스 데이터 계약에서 FaultContractAttrigute를 사용하여 SOAP 오류를 발생시킬 수있는 작업을 지정합니다.
....

3 단계 : 서비스 구현에서 강력한 형식의 SOAP 오류 인스턴스를 만들고 FaultException <T>를 사용하여 throw합니다.
 * ....
WCF 서비스를 변경 했으므로 클라이언트 응용 프로그램에서 서비스 참조를 업데이트하고 아래와 같이 catch 블록을 수정합니다.
 * ....
*/

