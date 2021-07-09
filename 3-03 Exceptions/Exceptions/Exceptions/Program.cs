using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            int age;
            try
            {
                // Code to test
                Console.Write("Enter age: ");
                age = int.Parse(Console.ReadLine());
                Console.WriteLine("Thank you!");
            } catch (Exception e)
            {
                // If error occures
                Console.WriteLine($"Smth got wrong: {e.Message}");
            } finally
            {
                // do smth regardless exception or not
                Console.WriteLine("finally run");
            };

            // Trow custom exception
            try
            {
                throw new Exception("Boom!");
            } catch (Exception e)
            {
                Console.WriteLine($"Thrown {e.Message} exemption");
            };

            Console.ReadKey();
        }

        static int ReadeIntVal(string intro = "Enter number", int min = 0, int max = 100)
        {
            int res = 0;
            do
            {
                Console.Write($"\n{intro} in range [{min};{max}]: ");
                res = int.Parse(Console.ReadLine());
            } while ((res < min) || (res > max));
            return res;
        }
    }
}
