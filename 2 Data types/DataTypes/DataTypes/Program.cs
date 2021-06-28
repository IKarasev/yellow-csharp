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


            Console.ReadKey();
        }
    }
}
