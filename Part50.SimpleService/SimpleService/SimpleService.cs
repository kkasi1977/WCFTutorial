using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "SimpleService"을 변경할 수 있습니다.
    public class SimpleService : ISimpleService
    {

        public string GetUserName()
        {
            Console.WriteLine("Is Authenticated: " + ServiceSecurityContext.Current.PrimaryIdentity.IsAuthenticated.ToString());
            Console.WriteLine("Authentication Type: " + ServiceSecurityContext.Current.PrimaryIdentity.AuthenticationType.ToString());
            Console.WriteLine("Username: " + ServiceSecurityContext.Current.PrimaryIdentity.Name.ToString());
            
            return "Authenticated Username: " + ServiceSecurityContext.Current.PrimaryIdentity.Name.ToString();
        }

    }
}
