using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "SimpleService"을 변경할 수 있습니다.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SimpleService : ISimpleService
    {

        private int _number;
        public int IncrementNumber()
        {
            _number = _number + 1;
            return _number;
        }
         
    }
}
