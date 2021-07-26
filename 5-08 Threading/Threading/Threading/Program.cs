using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading
{
    class Program
    {
        static private void busyLoop()
        {
            long count;
            for (count=0; count < 1000000000L; count++)
            {

            }
        }

        static void Main(string[] args)
        {
            // this is "delegate". it sets starting point of new thread
            // it can refer to a method that does not return a value or accept any parameters
            ThreadStart busyLoopMethod = new ThreadStart(busyLoop);

            // creating thread val
            Thread t1 = new Thread(busyLoopMethod); // thread still not running
            t1.Start(); //starting thread
            //busyLoop(); // it goes at same time

            // it is possible to create many threads
            int i;
            for (i = 0; i < 20; i++)
            {
                Thread t2 = new Thread(busyLoopMethod);
                t2.Start();
            }
        }
    }
}
