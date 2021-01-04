using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "SimpleService"을 변경할 수 있습니다.

    /*Part42 SessionMode Enumeration in WCF
     * Example 1 Set the service InstanceContextMode to Single and SessionMode to Allowed
     * setting 
     *          ServiceBehavior InstanceContextMode -> Single
     *          ServiceContract SessionMode -> SessionMode.Allowed   (Default) 
     * test1 : 
     *          Binding -> basicHttpBinding
     *          -> 세션을 지원하지 않는 basicHttpBinding을 사용하는 경우 서비스는 여전히 단일 서비스로 작동하지만 세션은 없습니다.
     * test2 : 
     *          Binding -> netTcpBinding   
     *          -> InstanceContextMode = InstanceContextMode.Single 로 설정하면 바인딩이 세션을 지원하는 netTcpBinding 이어도 
     *              클라이언트는 세션을 가져온 후 싱글로 동작한다. 
     *
     * Example 2 Now change SessionMode to Required. 
     * setting 
     *          ServiceBehavior InstanceContextMode -> Single
     *          ServiceContract SessionMode -> SessionMode.Required   
     * test1 : 
     *           Binding -> netTcpBinding 
     *          ->  If we use, netTcpBinding that support sessions, the service gets a session, and continue to work as a singleton service. 
     *              세션을 지원하는 netTcpBinding을 사용하면 서비스가 세션을 가져 와서 싱글 톤 서비스로 계속 작동합니다
     * test2 : 
     *           Binding -> basicHttpBinding
     *          ->On the other hand, if we use basicHttpBinding that does not support sessions, the following exception is thrown 
     *              반면 세션을 지원하지 않는 basicHttpBinding을 사용하면 다음과 같은 예외가 발생합니다.
     *               System.InvalidOperationException: Contract requires Session, but Binding 'BasicHttpBinding' doesn't support it or isn't configured properly to support it.          
     * 
     * 
     */
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]   
    public class SimpleService : ISimpleService
    {

        private int _number;
        public int IncrementNumber()
        {
            System.Console.WriteLine("Session ID: " + OperationContext.Current.SessionId); 

            _number = _number + 1;
            return _number;
        }

    }
}
