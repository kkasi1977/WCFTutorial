using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

//https://www.google.com/search?rlz=1C1QJDB_enKR905KR905&sxsrf=ALeKk03qmjWKKZferqK4uuJLAPBAlm8lNA%3A1609321715257&ei=80zsX--KD6KRlwSE6p3ICw&q=ip+%EB%81%9D%EC%A0%90+%EC%97%90+%EC%9D%B4%EB%AF%B8+%EC%88%98%EC%8B%A0%EA%B8%B0%EA%B0%80+%EC%9E%88%EC%8A%B5%EB%8B%88%EB%8B%A4&oq=ip+%EB%81%9D%EC%A0%90+%EC%97%90+%EC%9D%B4%EB%AF%B8+%EC%88%98%EC%8B%A0%EA%B8%B0%EA%B0%80+%EC%9E%88%EC%8A%B5%EB%8B%88%EB%8B%A4&gs_lcp=CgZwc3ktYWIQA1D6bli4dWDXeGgAcAB4AIABAIgBAJIBAJgBAKABAaoBB2d3cy13aXrAAQE&sclient=psy-ab&ved=0ahUKEwiv0KrJtvXtAhWiyIUKHQR1B7kQ4dUDCA0&uact=5

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(SampleService.SampleService)))
            {
                host.Open();
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
