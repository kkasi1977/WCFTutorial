using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System;

namespace CalculatorService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "CalculatorService"을 변경할 수 있습니다.
    public class CalculatorService : ICalculatorService
    {

        public int Divide(int Numerator, int Denominator)
        {
            /*
             * Part 18 Throwing fault exceptions from a WCF service
             * 이 예외는 분명히 WCF 서비스 내에서 처리되지 않으므로 계속해서 WCF서비스를 빌드하여 서비스가 실행되도록 한다.
             * 닷넷 오류발생시 클라이언트와 서버간의 채널에 오류가 발생될 것임.
             * 통신 채널에 오류가 발생하는 것을 원하지 않는 경우 오류를 통해 예외를 확인, 
             * 그래서 .NET예외를 던지는 대신
             * 새로운 FaultException이 발생하면 이 오류 예외 생성자가 오버로드 된 여러 버전의 코드를 지정해 본다.
             * WCF 서비스에서 FaultException이 발생하면 오류가 발생되지 않는다.
             * 이것이  WCF 서비스가 FaultException을 throw해야하는 이유이다. 
             * .NET예외는 .NET 클라이언트인경우 예외를 처리할 수있지만 다른 플랫폼의 클라이언트인경우 예외를 이해할 수 없다.
             * WCF 서비스를 상호 운용 할 수 있도록 하려면 서비스는 .NET 예외 대신 FaultException을 throw해야 한다.
            */
            if (Denominator == 0)
            {
                //.NET오류를 발생시킨다.
                //throw new DivideByZeroException();

                //서비스는 .NET예외 대신 오류 예외를 발생시킨다.
                //이렇게 되면 클라이언트에서 예외처리를 하면 클라이언트와 서비스 서버간 세션이 찟어지지 않는다.
                throw new FaultException("Denominator cannot be ZERO", new FaultCode("DivideByZeroFault"));
            }

            return Numerator / Denominator;
        }

    }
}
