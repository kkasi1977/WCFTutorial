using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace SimpleService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "SimpleService"을 변경할 수 있습니다.
    public class SimpleService : ISimpleService
    {
        public void DoWork()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Thread {0} processing request @ {1}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
        }
    }
}
