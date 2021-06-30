using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditions
{
    class Program
    {
        static void Main(string[] args)
        {
            // for condition
            Console.Write("Enter number 1-10: ");
            int i = int.Parse(Console.ReadLine());
            if (i < 3)
            {
                Console.WriteLine($"{i} < 3");
            } else if (i >= 3 && i < 7)
            {
                Console.WriteLine($"3 <= {i} < 7");
            } else if ( i == 9) {
                Console.WriteLine("You entered 9");
            } else
            {
                Console.WriteLine($"{i} >= 7");
            }

            Console.ReadKey();
        }
    }
}
