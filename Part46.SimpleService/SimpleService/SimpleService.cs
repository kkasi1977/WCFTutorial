using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace SimpleService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SimpleService : ISimpleService
    {
        public void DoWork()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Thread {0} processing request @ {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
        }
    }
}
/*
 * 처리량 - 주어진 시간에 수행된 작업의 양 
 * 서비스인스턴스 컨텍스트 모드와 동시성 모드는 실제로 확인한 처리량에 영항을 미친다. 
 * 이외 조절 모드도 처리량에 영향을 미친다. 
 * 제한 설정은 구성파일 또는 코드에서 지정가능하다.
 */