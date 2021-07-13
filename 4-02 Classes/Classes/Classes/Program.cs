using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    // Enumerated type with multiple states
    enum AccountState
    {
        New,
        Active,
        UnderAudit,
        Frozen,
        Closed
    }

    // Structure
    class Account
    {
        public AccountState State; // Using enumerated type with preset states
        public string Name;
        public string Address;
        public int AccountNumber;
        public int Balance;
        public int Overdraft;
    }

    class Program
    {

        public static void printAccount(Account a)
        {
            Console.WriteLine($"Account of {a.Name}");
            Console.WriteLine($"State: {a.State}");
            Console.WriteLine($"Balance: {a.Balance}");
        }

        const int MAX_ACCOUNTS = 50;

        static void Main(string[] args)
        {
            // Creating struct var
            Account RobAcc = new Account();

            // Assign value to struct param
            RobAcc.Name = "Rob";
            RobAcc.State = AccountState.Active; // Assign state to enum val
            RobAcc.Balance = 10000;

            Console.ReadKey();
        }
    }
}
