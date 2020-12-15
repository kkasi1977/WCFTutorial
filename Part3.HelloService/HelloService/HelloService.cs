using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "HelloService"을 변경할 수 있습니다.
    public class HelloService : IHelloServiceChanged
    {
        public string GetMessage(string name)
        {
            return "Hello " + name;
        }
    }
}
