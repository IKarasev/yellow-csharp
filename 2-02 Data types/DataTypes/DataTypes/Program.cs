using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("__Literal Number types:");
            Console.WriteLine($"sbyte (8bits)   [{sbyte.MinValue} ; {sbyte.MaxValue}]");
            Console.WriteLine($"byte (8bits)    [{byte.MinValue} ; {byte.MaxValue}]");
            Console.WriteLine($"short (16bits)  [{short.MinValue} ; {short.MaxValue}]");
            Console.WriteLine($"ushort (16bits) [{ushort.MinValue} ; {ushort.MaxValue}]");
            Console.WriteLine($"int (32bits)    [{int.MinValue} ; {int.MaxValue}]");
            Console.WriteLine($"uint (32bits)   [{uint.MinValue} ; {uint.MaxValue}]");
            Console.WriteLine($"long (64bits)   [{long.MinValue} ; {long.MaxValue}]");
            Console.WriteLine($"ulong (64bits)  [{ulong.MinValue} ; {ulong.MaxValue}]");
            
            Console.WriteLine("\n__Real Number types:");
            Console.WriteLine($"float (7d after .)    [{float.MinValue} ; {float.MaxValue}]");
            Console.WriteLine($"double (15d after .)  [{double.MinValue} ; {double.MaxValue}]");
            Console.WriteLine($"decimal (28d after .) [{decimal.MinValue} ; {decimal.MaxValue}]");

            Console.WriteLine("\n__Text types:");
            Console.WriteLine($"char (16bits)   [{char.MinValue} ; {char.MaxValue}]");

            // Changing the Type of Data
            Console.WriteLine("\n__Changing the Type of Data");
            //      Widening and Narrowing 
            Console.WriteLine("Widening:");
            //      changin the type from "smaller" to "bigger"
            int i = 25;
            float f = i;
            Console.WriteLine($"{i.GetType()} i = {i}");
            Console.WriteLine($"{f.GetType()} f = i = {f}");

            Console.WriteLine("\nNarrowing:");
            //       narrowing needs explicit expression
            double d = 1.5;
            // f = d; - error, float < double
            f = Convert.ToSingle(d);
            Console.WriteLine($"{d.GetType()} d = {d}");
            Console.WriteLine($"{f.GetType()} f = Convert.ToSingle(d) = {d}");

            //      Casting
            Console.WriteLine("\nCasting:");
            f = (float)d;
            Console.WriteLine($"f = (float)d = {f}");

            //      Problem of casting fail
            d = 123456781234567890.999;
            i = (int)d;
            Console.WriteLine($"Casting overfit d = {d}\n   i = (int)d = {i}");

            //      Types of Data in Expressions
            Console.WriteLine("\nTypes of Data in Expressions");
            int j = 2;
            f = i/j;
            Console.WriteLine($"{i.GetType()} i = {i}");
            Console.WriteLine($"{j.GetType()} i = {j}");
            Console.WriteLine($"{f.GetType()} f = i/j = {f}");
            f = (float)i / (float)j;
            Console.WriteLine($"{f.GetType()} f = (float)i / (float)j = {f}");

            Console.ReadKey();
        }
    }
}
