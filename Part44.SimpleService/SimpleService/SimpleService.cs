using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace SimpleService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, 
        InstanceContextMode = InstanceContextMode.PerCall)]
    public class SimpleService : ISimpleService
    {

        public List<int> GetEvenNumbers()
        {
            Console.WriteLine("Thread {0} started processing GetEvenNumbers at {1} ", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());
            List<int> listEvenNumbers = new List<int>();
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(200);
                if (i % 2 == 0)
                {
                    listEvenNumbers.Add(i);
                }
            }
            Console.WriteLine("Thread {0} started completed GetEvenNumbers at {1} ", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());
            return listEvenNumbers;
        }

        public List<int> GetOddNumbers()
        {
            Console.WriteLine("Thread {0} started processing GetOddNumbers at {1} ", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());
            List<int> listOddNumbers = new List<int>();
            for (int i = 0; i <= 10; i++)
            {
                Thread.Sleep(200);
                if (i % 2 != 0)
                {
                    listOddNumbers.Add(i);
                }
            }
            Console.WriteLine("Thread {0} started completed GetOddNumbers at {1} ", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToString());
            return listOddNumbers;
        }
    }
}




/*Part 44 Multiple concurrency mode in WCF 
 
When concurrency mode is set to Multiple, requests are processed concurrently by the service instance irrespective of the Service Instance Context Mode and whethe if the binding supports session or not.
동시성 모드가 다중으로 설정되면 서비스 인스턴스 컨텍스트 모드 및 바인딩이 세션을 지원하는지 여부에 관계없이 서비스 인스턴스에서 요청을 동시에 처리합니다.
 
 Instance Context Mode	: PerCall
Concurrency Mode		: Multiple
Binding supports session 	: No
Concurrent Calls Processed	: Yes
Throughput Impact	: Positive

Instance Context Mode	: PerCall
Concurrency Mode		: Multiple
Binding supports session 	: Yes
Concurrent Calls Processed	: Yes
Throughput Impact	: Positive

Instance Context Mode	: PerSession
Concurrency Mode		: Multiple
Binding supports session 	: No
Concurrent Calls Processed	: Yes
Throughput Impact	: Positive

Instance Context Mode	: PerSession
Concurrency Mode		: Multiple
Binding supports session 	: Yes
Concurrent Calls Processed	: Yes
Throughput Impact	: Positive

Instance Context Mode	: Single
Concurrency Mode		: Multiple
Binding supports session 	: No
Concurrent Calls Processed	: Yes
Throughput Impact	: Positive

Instance Context Mode	: Single
Concurrency Mode		: Multiple
Binding supports session 	: Yes
Concurrent Calls Processed	: Yes
Throughput Impact	: Positive
 
 */