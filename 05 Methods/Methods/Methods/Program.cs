using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Program
    {
        static int classVar = 0;

        static void Main(string[] args)
        {
            Console.WriteLine($"\n__Vars in methods");
            int i = 5;
            Console.WriteLine($"i = {i}");
            int a = PlusOne(i);

            Console.WriteLine($"int a = PlusOne(i) = {a}");
            Console.WriteLine($"i after PlusOne = {i}");

            Console.WriteLine($"\nUsing func with params by ref\ni = {i}");
            IncreaseByRef(ref i, 5);
            Console.WriteLine($"After IncreaseBy(ref i, 5), i = {i}");

            Console.WriteLine($"\nUsing func with params by out reference\ni = {i}");
            ChangeValTo(out i, 5);
            Console.WriteLine($"After ChangeValTo(out i, 5), i = {i}");

            Console.WriteLine("\n__Using class vars to use in different methods of class\nvar before use = {0}",classVar);
            classVar = 15;
            Console.WriteLine($"var after aasign 15: var = {classVar}");
            ChangeClassVar();
            Console.WriteLine($"Class var after func = {classVar}");

            //double num = ReadeDoubleVal("Enter number", 1.0, 5.0);
            //Console.WriteLine($"You entered {num}");

            //num = ReadeDoubleVal(min: 18, intro: "Enter age", max: 65);
            //Console.WriteLine("Availabel age {0:0.##}", num);


            Console.ReadKey();
        }

        // Pass parameters as value
        static int PlusOne(int i)
        {
            i = i + 1;
            Console.WriteLine($"inside mehtod i = {i}");
            return i;
        }

        // Pass parameter as a reference (full control of param var in method)
        static void IncreaseByRef( ref int num, int incr)
        {
            num = num + incr;
        }

        // Pass parameter as a out reference (allows only val change of var)
        static void ChangeValTo(out int num, int incr)
        {
            num = incr;
        }

        // Using class vars in method
        static void ChangeClassVar(){
            Console.WriteLine($"Class var on func input: {classVar}");
            classVar = 222;
            Console.WriteLine($"Class var cahnged in func and = {classVar}");
        }
        
        static double ReadeDoubleVal(string intro = "Enter number", double min=0.0, double max=100.0)
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
