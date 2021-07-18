using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegating
{
    // creating delegate desription
    // return type and params types should be the same as in methods to wich process will
    // be delegated
    public delegate decimal CalculateFee(decimal balance);

    class Program
    {
        // Creating methods that will implement delegate
        public static decimal RipoffFee(decimal balance)
        {
            Console.WriteLine("Using RipofFee");
            if (balance < 0)
            {
                return 100;
            }
            else
            {
                return 1;
            }
        }

        public static decimal FriendlyFee(decimal balance)
        {
            Console.WriteLine("Using Friendly Fee");
            if (balance < 0)
            {
                return 10;
            }
            else
            {
                return 0;
            }
        }

        static void Main(string[] args)
        {
            // creating delegation var
            CalculateFee ca;

            // teling var to use Ripoff Fee
            ca = new CalculateFee(RipoffFee);
            ca(-1);

            // telling to use Friendly fee
            ca = new CalculateFee(FriendlyFee);
            ca(-1);

            Console.ReadKey();
        }
    }
}
