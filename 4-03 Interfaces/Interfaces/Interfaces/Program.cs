using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    // Creating interface: the "list" of possible methods for children interfaces and classes
    public interface IAccount
    {
        void AddBalance(decimal a);
        bool WithdrawBalance(decimal a);
        decimal GetBalance();
    }

    public interface IPrintToPaper
    {
        void Print();
    }


    // Implemetnting interface in class
    public class Account : IAccount
    {
        private decimal balance;

        // Interface require class to implement its methods
        public decimal GetBalance()
        {
            return balance;
        }

        public void AddBalance(decimal a)
        {
            balance += a;
        }

        public bool WithdrawBalance(decimal a)
        {
            if (balance < a)
            {
                return false;
            };
            
            balance -= a;
            return true;
        }
    }

    // Implementing another class with same interface (different frmom Account). Also implement second interface
    public class BabyAccount : IAccount, IPrintToPaper
    {
        decimal balance;

        public void AddBalance(decimal a)
        {
            balance += a;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        // here difference, can't withdraw more than 10 at time
        public bool WithdrawBalance(decimal a)
        {
            if (a > 10)
            {
                return false;
            }
            if (balance < a)
            {
                return false;
            }
            balance -= a;
            return true;
        }

        // implementing method from second interface
        public void Print()
        {
            Console.WriteLine($"Baby Account\n    Cur balance: {balance}");
        }
    }

    class Program
    {
        const int MAX_ACC = 50;

        static void Main(string[] args)
        {
            // using interface
            IAccount acc = new Account();
            acc.AddBalance(1000);
            Console.WriteLine($"Balance: {acc.GetBalance()}");

            // can create array of interfaces, where members could be of different class implementinting this interface
            IAccount[] accs = new IAccount[MAX_ACC];
            accs[0] = new Account();
            accs[1] = new BabyAccount();

            accs[0].AddBalance(50);
            accs[1].AddBalance(50);

            Console.WriteLine($"1 account balance: {accs[0].GetBalance()}");
            Console.WriteLine($"2 account balance: {accs[1].GetBalance()}");

            Console.WriteLine("\nWithdraw from first account 10");
            if (accs[0].WithdrawBalance(10))
            {
                Console.WriteLine($"OK. Balance: {accs[0].GetBalance()}");
            } else
            {
                Console.WriteLine("Insufficient funds");
            }

            Console.WriteLine("\nWithdraw from 2 acc 15");
            if (accs[1].WithdrawBalance(15))
            {
                Console.WriteLine($"OK. Balance: {accs[1].GetBalance()}");
            }
            else
            {
                Console.WriteLine("Fail");
            }

            Console.ReadKey();
        }
    }
}
