﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net.Security;

namespace HelloService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IHelloService"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract(ProtectionLevel = ProtectionLevel.None)]
        string GetMessageWithoutAnyProtection();

        [OperationContract(ProtectionLevel = ProtectionLevel.Sign)]
        string GetSignedMessage();

        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        string GetSignedAndEncryptedMessage();
    }
}

/*Part 48 Controlling WCF message protection using ProtectionLevel parameter 

The following 6 attributes has the ProtectionLevel named parameter, which implies that 
ProtectionLevel can be specified using any of the below 6 attributes. 
ServiceContractAttribute
        OperationContractAttribute
                FaultContractAttribute
                MessageContractAttribute
                        MessageHeaderAttribute
                        MessageBodyMemberAttribute

Forexample ProtectionLevel specified at an operation contract level overrides the ProtectionLevel 
specified at the service contract level. 

When we use wsHttpBinding, by default the messages are encrypted and signed. 
Encryption provides confidentiality and signing provides integrity. 
To customize the level of message protection use ProtectionLevel parameter. 

Please Note: ProtectionLevel enum is present in System.Net.Security namespace.

ProtectionLevel enum has the following values
None - No protection. Message is not signed and not encrypted. Provides only authentication. 

Sign - No encryption but is digitally signed to ensure the integrity of the message 

EncryptAndSign - Message is encrypted and then signed to ensure confidentiality and integrity of 
the message   


48 부 ProtectionLevel 매개 변수를 사용하여 WCF 메시지 보호 제어

다음 6 개 속성에는 ProtectionLevel이라는 매개 변수가 있으며 이는 아래 6 개 속성 중 하나를 사용하여 
ProtectionLevel을 지정할 수 있음을 의미합니다.
ServiceContractAttribute
        OperationContractAttribute
                FaultContractAttribute
                MessageContractAttribute
                        MessageHeaderAttribute
                        MessageBodyMemberAttribute

예를 들어 작업 계약 수준에서 지정된 ProtectionLevel은 서비스 계약 수준에서 지정된 ProtectionLevel을 
재정의합니다.

wsHttpBinding을 사용하면 기본적으로 메시지가 암호화되고 서명됩니다.
암호화는 기밀성을 제공하고 서명은 무결성을 제공합니다.
메시지 보호 수준을 사용자 지정하려면 ProtectionLevel 매개 변수를 사용하십시오.

참고 : ProtectionLevel 열거 형은 System.Net.Security 네임 스페이스에 있습니다.

ProtectionLevel 열거 형에는 다음 값이 있습니다.
없음-보호되지 않습니다. 메시지가 서명되지 않았고 암호화되지 않았습니다. 인증 만 제공합니다.

서명-암호화되지 않지만 메시지의 무결성을 보장하기 위해 디지털 서명 됨

EncryptAndSign-메시지의 기밀성과 무결성을 보장하기 위해 메시지를 암호화 한 다음 서명합니다.

*/

