using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System;

namespace CalculatorService
{

    // GlobalErrorHandlerBehavior클래스 구현된것을 보면 생성자가 하나 있고 생성자는 Type 유형의 매개변수를 받는다. 
    // 여기 CalculatorService 에서 GlobalErrorHandler 클래스의 타입을 넘긴다.
   [GlobalErrorHandlerBehavior(typeof(GlobalErrorHandler))] 
    public class CalculatorService : ICalculatorService
    {

        public int Divide(int Numerator, int Denominator)
        {
            //try
            //{ 
                return Numerator / Denominator;
            //}
            //catch(DivideByZeroException ex)
            //{
            //    /*Part 19 Stongly Typed SOAP Faults*/
            //    DivideByZeroFault divideByZeroFault = new DivideByZeroFault();
            //    divideByZeroFault.Error = ex.Message;
            //    divideByZeroFault.Details = "Denominator cannot be ZERO";

            //    throw new FaultException<DivideByZeroFault>(divideByZeroFault);
            //}

            
        }

    }
}
