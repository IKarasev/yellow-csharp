using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrayys
{
    class Program
    {
        static void Main(string[] args)
        {
            const int BOARD_X_SIZE = 3;
            const int BOARD_Y_SIZE = 3;

            // Declare arrays
            int[] scores = new int[3];

            // fill array via input
            for(int i = 0; i < scores.Length; i++)
            {
                scores[i] = ReadeIntVal("Enter score", 0, 100);
            }

            // Two dim array
            int[,] board = new int[BOARD_X_SIZE, BOARD_Y_SIZE];
            board[1, 1] = 1;

            // Array as lookup table
            // Here we'll miss 0 element => size of array 13
            // Also it's not needed to implicitly set array size if array is declared and initiated at same time
            string[] months = new string[]
            {
                null, // null element for non existent month 0
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            };

            int num = ReadeIntVal("Enter month number", 1, 12);
            Console.WriteLine($"Month {num}: {months[num]}");

            // Declare and init two dim array
            int[,] squareWeights = new int[3, 3]
            {
                { 1, 0, 1 },
                { 0, 2, 0 },
                { 1, 0, 1 }
            };


            Console.ReadKey();
        }

        static double ReadeDoubleVal(string intro = "Enter number", double min = 0.0, double max = 100.0)
        {
            double res = 0;
            do
            {
                Console.Write($"\n{intro} in range [{min};{max}]: ");
                res = double.Parse(Console.ReadLine());
            } while ((res < min) || (res > max));
            return res;
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
