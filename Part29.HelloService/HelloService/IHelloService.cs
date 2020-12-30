using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IHelloService"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        string GetMessage(string name);
    }
}


/*Part 24 Self host a wcf service in console application
Part 24 Self hosting

Hosting a wcf service in any managed .net application is called as self hosting.
Console applications, WPF applications, WinForms applications are all examples of managed .net applications. 

Advantages of self hosting a WCF service in a console application 
1. Vary easy to setup. 
Specify the configuration in app.config file and with a few lines of code we have the service up and running.

2. Easy to debug as we don't have to attach a separate process that hosts the wcf service. 

3. Supports all bindings and transport protocols. 

4. Very flexible to control the lifetime of the services through the Open() and Close() methods of ServiceHost. 

Disadvantages of self hosting a wcf service in a console application
1. The service is available for the clients only when the service host is running.

2. Self hosting does not support automatic message based activation that we get when hosted within IIS.

3. Custom code required. 

In General, self-hosting is only suitable during the development and demonstration phase and not for hosting live WCF services. 


 * 파트 24 셀프 호스팅

관리되는 .net 애플리케이션에서 wcf 서비스를 호스팅하는 것을 자체 호스팅이라고합니다.
콘솔 애플리케이션, WPF 애플리케이션, WinForms 애플리케이션은 모두 관리되는 .net 애플리케이션의 예입니다.

콘솔 응용 프로그램에서 WCF 서비스를 자체 호스팅 할 때의 이점
1. 설정이 다양합니다.
app.config 파일에 구성을 지정하고 몇 줄의 코드로 서비스를 실행하고 있습니다.

2. wcf 서비스를 호스팅하는 별도의 프로세스를 첨부 할 필요가 없으므로 디버그가 쉽습니다.

3. 모든 바인딩 및 전송 프로토콜을 지원합니다.

4. ServiceHost의 Open () 및 Close () 메서드를 통해 서비스 수명을 매우 유연하게 제어합니다.

콘솔 애플리케이션에서 wcf 서비스 자체 호스팅의 단점
1. 서비스 호스트가 실행 중일 때만 클라이언트에서 서비스를 사용할 수 있습니다.

2. 셀프 호스팅은 IIS 내에서 호스팅 될 때받는 자동 메시지 기반 활성화를 지원하지 않습니다.

3. 사용자 지정 코드가 필요합니다.

일반적으로 자체 호스팅은 개발 및 데모 단계 중에 만 적합하며 라이브 WCF 서비스 호스팅에는 적합하지 않습니다.





 */