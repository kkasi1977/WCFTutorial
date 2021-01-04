using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace ReportService
{
    /*ConcurrencyMode.Reentrant -> 교착을 피해 클라이언트의 Response Collback을 받을 수 있다.*/
    /*ConcurrencyMode.Single 에서 클라이언트 Response 콜백을 없애려면 단방향으로 처리하면 된다. 교착을 피할 수 있다.*/
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
    public class ReportService : IReportService 
    {
 
        public void ProcessReport()
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(50);
                OperationContext.Current.GetCallbackChannel<IReportServiceCallback>().ReportProgress(i);
            }
        }

 
    }
}
