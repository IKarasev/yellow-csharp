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
            int winType = ReadeIntVal("Enter windows type", 1, 3);

            // Switch operation
            switch (winType) {
                case 1:
                    handleCasement();
                    break;
                case 2:
                    handleStandard();
                    break;
                case 3:
                    handlePatio();
                    break;
                default:
                    Console.WriteLine("Wrong type number");
                    break;
            }


            // multiple cases in switch
            string command = "casement";
            switch (command) {
                case "c":
                case "casement":
                    handleCasement();
                    break;
                case "s":
                case "standard":
                    handleStandard();
                    break;
                case "p":
                case "patio":
                    handlePatio();
                    break;
                default:
                    Console.WriteLine("Wrong type");
                    break;
            }

            Console.ReadKey();
        }

        // methods to deal with different window types
        static void handleCasement() {
            Console.WriteLine("Handle Casement");
        }

        static void handleStandard() {
            Console.WriteLine("Handle Standard");
        }

        static void handlePatio() {
            Console.WriteLine("Handle patio");
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
