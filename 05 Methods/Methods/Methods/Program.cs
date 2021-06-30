using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"\n__Vars in methods");
            int i = 5;
            Console.WriteLine($"i = {i}");
            int a = PlusOne(i);

            Console.WriteLine($"int a = PlusOne(i) = {a}");
            Console.WriteLine($"i after PlusOne = {i}");

            double num = ReadeDoubleVal("Enter number", 1.0, 5.0);
            Console.WriteLine($"You entered {num}");

            num = ReadeDoubleVal(min: 18, intro: "Enter age", max: 65);
            Console.WriteLine("Availabel age {0:0.##}", num);
            Console.ReadKey();
        }

        static int PlusOne(int i)
        {
            i = i + 1;
            Console.WriteLine($"inside mehtod i = {i}");
            return i;
        }

        static double ReadeDoubleVal(string intro, double min, double max)
        {
            double res = 0;
            do
            {
                Console.Write($"\n{intro} in range [{min};{max}]: ");
                res = double.Parse(Console.ReadLine());
            } while ((res < min) || (res > max));
            return res;
        }
    }
}
