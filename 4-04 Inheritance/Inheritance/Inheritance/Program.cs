using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public interface IAccount
    {
        void AddBalance(decimal a);
        bool WithdrawBalance(decimal a);
        decimal GetBalance();
        void PrintIt();
    }

    // Implemetnting interface in class
    public class CustomerAccount : IAccount
    {   
        // to use var in child class it should be protected instead of private
        protected decimal balance;
        protected string Name;

        // Interface require class to implement its methods
        public decimal GetBalance()
        {
            return balance;
        }

        public void AddBalance(decimal a)
        {
            balance += a;
        }

        // To override method in child class its should be virtual
        public virtual bool WithdrawBalance(decimal a)
        {
            if (balance < a)
            {
                return false;
            };

            balance -= a;
            return true;
        }

        public void PrintIt()
        {
            Console.WriteLine($"Type: regular account\nBalance: {balance}");
        }

        // Constructors
        // Constructors are available for child classes
        public CustomerAccount(string inName, decimal inBalance)
        {
            Name = inName;
            balance = inBalance;
        }
    }

    // BabyAccount inherits Account and implements interface IAccount
    // So we need to ovveride only withdrawal method
    // Sealed means BabyAccount could not be parant to other classes
    public sealed class BabyAccount : CustomerAccount, IAccount
    {
        public override bool WithdrawBalance(decimal a)
        {
            if (a > 10 || balance < a)
            {
                return false;
            };

            // Instead of writing whole method we can use methods from parent class using "base"
            return base.WithdrawBalance(a);
        }

        // if we want "override" non virtual method from parant we can redefine it using "new"
        public new void PrintIt()
        {
            Console.WriteLine($"Type: Baby Account\nBalance: {balance}");
        }

        // In order tu use constructors in child class it should exist in parent class
        public BabyAccount(string inName, decimal inBalance) :
            base (inName, inBalance)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAccount acc = new CustomerAccount();
            IAccount bacc = new BabyAccount();

            acc.AddBalance(50);
            bacc.AddBalance(100);

            Console.WriteLine("Withdraw 15 from acc");
            if (acc.WithdrawBalance(15))
            {
                Console.WriteLine($"OK. Balance: {acc.GetBalance()}");
            }
            else
            {
                Console.WriteLine("Withdraw fail");
            }

            Console.WriteLine("Withdraw 15 from baby acc");
            if (bacc.WithdrawBalance(15))
            {
                Console.WriteLine($"OK. Balance: {bacc.GetBalance()}");
            } else
            {
                Console.WriteLine("Withdraw fail");
            }

            acc.PrintIt();
            bacc.PrintIt();

            Console.ReadKey();
        }
    }
}
