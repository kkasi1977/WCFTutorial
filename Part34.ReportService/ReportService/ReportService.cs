using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace ReportService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "ReportService"을 변경할 수 있습니다.

    //[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]  //Step2 교착상태해결하려면 ConcurrencyMode를 설정한다
    public class ReportService : IReportService
    {
        #region IReportService 멤버

        public void ProcessReport()
        {
            for (int i = 1; i <= 100; i++ )
            {
                Thread.Sleep(100);
                // Get the callback channel to send messages to the client
                OperationContext.Current.GetCallbackChannel<IReportServiceCollback>().Progress(i);
            }
        }

        #endregion
    }
}

