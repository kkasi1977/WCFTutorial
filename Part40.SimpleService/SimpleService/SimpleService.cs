using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "SimpleService"을 변경할 수 있습니다.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class SimpleService : ISimpleService
    {
        /*Part 40 
            To retrieve SessionId from the client application
                procyClassInstance.InnerChannel.SessionId
         */

        private int _number;
        public int IncrementNumber()
        {
            System.Console.WriteLine("Session ID: " + OperationContext.Current.SessionId); 

            _number = _number + 1;
            return _number;
        }
         
    }
}
