using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchOp
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = ReadeIntVal();
            Console.ReadKey();
        }

        static int ReadeIntVal(string intro = "Enter number", int min = 0, int max = 100)
        {
            int res = 0;
            do
            {
                Console.Write($"\n{intro} in range [{min};{max}]: ");
                try {
                    res = int.Parse(Console.ReadLine());
                } catch (Exception e)
                {
                    Console.WriteLine($"Smth got wrong, try again: {e.Message}");
                    res = min - 1;
                }
            } while ((res < min) || (res > max));
            return res;
        }
    }
}
