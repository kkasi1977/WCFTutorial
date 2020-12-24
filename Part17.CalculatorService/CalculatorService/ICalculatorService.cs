using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculatorService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "ICalculatorService"을 변경할 수 있습니다.
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        int Divide(int Numerator, int Denominator);
    }
}

/*Part 17 Unhandled exceptions in WCF
Please watch Part 16 from WCF video Series, before proceeding

An unhandled exception in the WCF service, will cause the communication channel to fault and the session will be lost.
Once the communication channel is in faulted state, we cannot use the same instance of the proxy class anymore.

BasicHttpBinding does not have sessions.
So when there is an unhandled exception, it only faults the server channel.
The client proxy is still OK, because with BasicHttpBinding the channel is not maintaining sessions, and when the client calls again it is not expecting the channel to maintain any session.

wsHttpBinding have secure session.
So when there is an unhandled exception, it faults the server channel.
At this point the existing client proxy is useless as it is also faulted, because with wsHttpBinding the channel is maintaining a secure session, and when the client calls again it expects the channel to maintain the same session. 
The same session does not exist at the server channel anymore, as the unhandled exception has already torn down the channel and the session along with it.
 * 
 * 
 * Part 17 WCF의 처리되지 않은 예외
계속하기 전에 WCF 비디오 시리즈의 Part 16을 시청하십시오.

WCF 서비스에서 처리되지 않은 예외로 인해 통신 채널에 오류가 발생하고 세션이 손실됩니다.
통신 채널이 오류 상태가되면 더 이상 동일한 프록시 클래스 인스턴스를 사용할 수 없습니다.

BasicHttpBinding에는 세션이 없습니다.
따라서 처리되지 않은 예외가 발생하면 서버 채널에만 오류가 발생합니다.
BasicHttpBinding을 사용하면 채널이 세션을 유지하지 않고 클라이언트가 다시 호출 할 때 채널이 세션을 유지할 것으로 기대하지 않기 때문에 클라이언트 프록시는 여전히 정상입니다.

wsHttpBinding에는 보안 세션이 있습니다.
따라서 처리되지 않은 예외가 있으면 서버 채널에 오류가 발생합니다.
이 시점에서 기존 클라이언트 프록시는 오류가 발생하기 때문에 쓸모가 없습니다. wsHttpBinding을 사용하면 채널이 보안 세션을 유지하고 클라이언트가 다시 호출 할 때 채널이 동일한 세션을 유지하기를 기대하기 때문입니다.
처리되지 않은 예외가 이미 채널과 함께 세션을 해체했기 때문에 동일한 세션이 더 이상 서버 채널에 존재하지 않습니다.
*/