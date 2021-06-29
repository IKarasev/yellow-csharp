using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 150;
            double f = 1234.56789;
            Console.WriteLine("Using Placeholders in Print Strings");
            Console.WriteLine("i: {0} f: {1}", i, f);
            Console.WriteLine("i: {1} f: {0}", f, i);

            Console.WriteLine("\nAdjusting real number precision");
            Console.WriteLine("i: {0:0} f: {1:0.00}", i, f);

            Console.WriteLine("\nSpecifying the number of printed digits");
            Console.WriteLine("i: {0:0000} f: {1:00000.00}", i, f);

            Console.WriteLine("\nReally Fancy Formatting");
            Console.WriteLine("i: {0:#,##0} f: {1:##,##0.00}", i, f);

            Console.WriteLine("\n__Printing in columns__");
            Console.WriteLine("Right justyfied:");
            for (int k = 0; k < 2; k++)
            {
                for (int l = 0; l < 2; l++)
                {
                    Console.WriteLine("k: {0,3:0} l: {1,3:0}", k, l);
                }
            }

            Console.WriteLine("Left justyfied:");
            for (int k = 0; k < 2; k++)
            {
                for (int l = 0; l < 2; l++)
                {
                    Console.WriteLine("k: {0,-3:0} l: {1,-3:0}", k, l);
                }
            }
            Console.ReadKey();
        }
    }
}
