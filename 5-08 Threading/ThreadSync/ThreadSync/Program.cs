using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSync
{
    class Program
    {
        static int sum = 0;

        // empty object to hold as a token
        static object sync = new object();

        static private void SumArray(int start, int end)
        {
            int i;
            for (i = start; i< end; i++)
            {
                sum++;
            }
        }

        // creating methods that split up sumArray
        // remember: thread delegates accept methods with NO input and output
        static void Sum1()
        {
            SumArray(0, 5000000);
        }

        static void Sum2()
        {
            SumArray(5000000, 9999999);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("count directly");
            SumArray(0, 9999999);
            Console.WriteLine($"    sum = {sum}");
            sum = 0;

            Console.WriteLine("Start counting via threads");

            // Creating first thread
            ThreadStart ts1 = new ThreadStart(Sum1);
            Thread t1 = new Thread(ts1);
            t1.Start();

            // Creating second thread
            ThreadStart ts2 = new ThreadStart(Sum2);
            Thread t2 = new Thread(ts2);
            t2.Start();

            Console.WriteLine($"    sum = {sum}"); // doesn't work well. Need sync

            

            Console.ReadKey();
        }
    }
}
