﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DownloadService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "IDownloadService"을 변경할 수 있습니다.
    [ServiceContract]
    public interface IDownloadService
    {
        [OperationContract]
        File DownloadDocument();
    }

    [DataContract]
    public class File
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public byte[] Content { get; set; }
    }
}

/*Part 35 MTOM in WCF

The default message encoding mechanism in WCF is Text, which base64 encodes data. 
This has the following 2 disadvantages 
1. Base64 encoding bloats the message size by approximately 33% 
2. Involves additional processing overhead to base64 encode and decode.

The preferred approach to send large binary messages in WCF is to use MTOM message encoding. 
MTOM is an interoperable standard and stands for Message Transmission Optimization Mechanism.
MTOM does not base64 encode data. 
This also means, the additional processing overhead to base64 encode and decode data is removed.  
Hence, MTOM can significantly improve the overall message transfer performance.

With Text Message encoding, the binary data is base64 encoded and it is embedded in the SOAP envelop. 
With MTOM, binary data is included as a MIME(Multipurpose Internet Mail Extensions) attachment. 



WCF의 Part 35 MTOM

WCF의 기본 메시지 인코딩 메커니즘은 base64가 데이터를 인코딩하는 텍스트입니다.
여기에는 다음과 같은 두 가지 단점이 있습니다.
1. Base64 인코딩으로 메시지 크기가 약 33 % 증가합니다.
2. base64 인코딩 및 디코딩에 추가 처리 오버 헤드가 포함됩니다.

WCF에서 큰 이진 메시지를 보내는 데 선호되는 방법은 MTOM 메시지 인코딩을 사용하는 것입니다.
MTOM은 상호 운용 가능한 표준이며 메시지 전송 최적화 메커니즘을 나타냅니다.
MTOM은 데이터를 base64로 인코딩하지 않습니다.
이는 또한 base64 인코딩 및 디코딩 데이터에 대한 추가 처리 오버 헤드가 제거됨을 의미합니다.
따라서 MTOM은 전체 메시지 전송 성능을 크게 향상시킬 수 있습니다.

텍스트 메시지 인코딩을 사용하면 바이너리 데이터가 base64로 인코딩되고 SOAP 엔 벨롭에 포함됩니다.
MTOM에서는 이진 데이터가 MIME (Multipurpose Internet Mail Extensions) 첨부 파일로 포함됩니다.
*/