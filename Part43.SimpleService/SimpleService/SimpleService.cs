using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace SimpleService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.PerSession)]
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




/*Part 43 Single concurrency mode in WCF 
 * 
 * WCF 서비스가 클라이언트 요청을 동시에 처리하는지 여부는 세 가지에 따라 다릅니다.
 * 1. 서비스 InstanceConextMode
 * 2. 서비스 ConcurrencyMode
 * 3. 바인딩이 세션을 지원하는지 여부
 * 
 * Setting service
 *  [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.PerCall)]
 *  [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.PerSession)]
 *  
 * Test 1
 * Instance Context Mode        : PerCAll 
 * Concurrency Mode              : Single
 * Binding supports session     : No    -> ex) basicHttpBinding
 * Concurrent Calls processed  : Yes    -> 쓰레드가 서비스의 메소드를 동시적으로 호출 처리된다.
 * Throughput Impact               : Positive
 * 
 * Test 2
 * Instance Context Mode        : PerCAll 
 * Concurrency Mode              : Single
 * Binding supports session     : Yes    -> ex) netTcpBinding
 * Concurrent Calls processed  : No     -> 쓰레드가 서비스의 메소드를 동시적으로 호출하지 않고 잠금이 발생한다.  처리중인 쓰레드가 완료될때가지 기다리다가 잠금이 풀리면 호출 처리된다.
 * Throughput Impact              : Negative
 * 
 * Test 3
 * Instance Context Mode        : PerSession 
 * Concurrency Mode              : Single
 * Binding supports session     : No -> ex) basicHttpBinding
 * Concurrent Calls processed  : Yes
 * Throughput Impact             : Positive
 * 
 * Test 4
 * Instance Context Mode        : PerSession 
 * Concurrency Mode              : Single
 * Binding supports session     : Yes   -> ex) netTcpBinding
 * Concurrent Calls processed  : Yes - Between Different client requests   No - For the request from the same client
 * Throughput Impact             : Positive - Between clients    Negative - For the same client request
 * 
 * Test 5
 * Instance Context Mode        : Single 
 * Concurrency Mode              : Single
 * Binding supports session     : No -> ex) basicHttpBinding
 * Concurrent Calls processed  : No
 * Throughput Impact             : Negative - Between clients and for the requests from the same client 
 * 
 * Test 6
 * Instance Context Mode        : Single 
 * Concurrency Mode              : Single
 * Binding supports session     : YES -> ex) netTcpBinding
 * Concurrent Calls processed  : No
 * Throughput Impact             : Negative - Between clients and for the requests from the same client 
*/