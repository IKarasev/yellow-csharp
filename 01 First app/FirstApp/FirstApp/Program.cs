using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // intro vars
            double w, h, woodLength, glassArea;
            
            // asking for vars via console
            Console.Write("Window with (sm): ");
            w = double.Parse(Console.ReadLine());
            Console.Write("Window height (sm^2): ");
            h = double.Parse(Console.ReadLine());

            // Calc length and area
            woodLength = 2 * (w + h) + 3.25;
            glassArea = 2 * (2 + h);

            // Output results
            Console.WriteLine($"The length of wood is {woodLength} sm");
            Console.WriteLine($"The area of glass is {glassArea} sm^2");

            Console.ReadKey();
        }
    }
}
