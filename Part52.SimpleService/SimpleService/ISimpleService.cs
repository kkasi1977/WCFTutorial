﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "ISimpleService"을 변경할 수 있습니다.
    [ServiceContract]
    public interface ISimpleService
    {
        [OperationContract]
        string GetMessage(string name);
    }
}


/*Part 52, Configure wsHttpBinding to use transport security 

The following are the defaults of wsHttpBinding
Security Mode - Message
ClientCredentialType - Windows

We will customize wsHttpBinding to use
Transport Security Mode 
Basic ClientCredentialType 

The following MSDN article contains all the system provided bindings and their security defaults. 
http://msdn.microsoft.com/en-us/library/ms731092(v=vs.110).aspx

To get the most out of this video, 
Part 29 - Host WCF service in IIS (WCF Tutorial)
Part 9 - Enable message logging and tracing in WCF (WCF Tutorial) 
Part 101 - Implementing SSL in asp.net web application (ASP.NET Tutorial) 



52 부, 전송 보안을 사용하도록 wsHttpBinding 구성

다음은 wsHttpBinding의 기본값입니다.
보안 모드-메시지
ClientCredentialType-Windows

wsHttpBinding을 사용자 정의하여
운송 보안 모드
기본 ClientCredentialType

다음 MSDN 문서에는 모든 시스템 제공 바인딩 및 보안 기본값이 포함되어 있습니다.
http://msdn.microsoft.com/en-us/library/ms731092(v=vs.110).aspx

이 비디오를 최대한 활용하려면
29 부-IIS의 호스트 WCF 서비스 (WCF 자습서)
9 부-WCF에서 메시지 로깅 및 추적 사용 (WCF 자습서)
101 부-asp.net 웹 애플리케이션에서 SSL 구현 (ASP.NET 자습서)
*/