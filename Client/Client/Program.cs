using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleService.SimpleServiceClient client = new SimpleService.SimpleServiceClient();
            int number =  client.IncrementNumber();
            Console.WriteLine("Number after first call = " + number);
            number = client.IncrementNumber();
            Console.WriteLine("Number after second call = " + number);
            number = client.IncrementNumber();
            Console.WriteLine("Number after third call = " + number);
            Console.ReadLine();
        }
    }
}
