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
        private decimal balance;
        public int Overdraft;

        // static var, belongs to class not to class memeber and shared between all members
        public static decimal InterestRateCharged;

        private static decimal minIncome = 1000;
        private static int minAge = 18;

        // Constructors
        public Account()
        {
            Console.WriteLine("Account created");
        }

        // constructor ovveride
  
        public Account(string NewName, AccountState NewState = AccountState.Active, decimal NewBalance = 0)
        {
            Name = NewName;
            State = NewState;
            balance = NewBalance;
            Console.WriteLine("-------------\nCreated account:");
            PrintDetails();
        }

        public void AddBalance(decimal a) {
            balance += a;   
        }

        public bool WithdrawBalance(decimal a)
        {
            if (balance < a)
            {
                return false;
            }
            balance -= a;
            return true;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Account of {Name}");
            Console.WriteLine($"State: {State}");
            Console.WriteLine($"Balance: {balance}");
        }

        // Static class method shared between all memebers and belongs to class itself
        public static bool AccountAllowed(int age, decimal income)
        {
            if ((age >= minAge) && (income > minIncome))
            {
                return true;
            } else
            {
                return false;
            }
        }
    }

    class Program
    {

        public static void printAccount(Account a)
        {
            Console.WriteLine($"Account of {a.Name}");
            Console.WriteLine($"State: {a.State}");
            Console.WriteLine($"Balance: {a.GetBalance()}");
        }

        const int MAX_ACCOUNTS = 50;

        static void Main(string[] args)
        {
            // Creating struct var
            Account RobAcc = new Account();

            // Assign value to struct param
            RobAcc.Name = "Rob";
            RobAcc.State = AccountState.Active; // Assign state to enum val
            RobAcc.AddBalance(100);

            Account TempAcc;
            TempAcc = RobAcc; // this created reference to RobAcc
            TempAcc.Name = "Jim";

            Console.WriteLine($"RobAcc name = {RobAcc.Name}");

            if (RobAcc.WithdrawBalance(1000))
            {
                Console.WriteLine($"Withdraw succesfull. Current balance: {RobAcc.GetBalance()}");
            } else
            {
                Console.WriteLine("Insuffisient balance.");
            }

            if (RobAcc.WithdrawBalance(50))
            {
                Console.WriteLine($"Withdraw succesfull. Current balance: {RobAcc.GetBalance()}");
            }
            else
            {
                Console.WriteLine("Insuffisient balance.");
            }

            // statice vars of class
            // RobAcc.InterestRateCharged = 10; // error, static member of class doen't belong to class member
            // but to class itself
            Account.InterestRateCharged = 10; // all class members will share same InterstRateCharged value.

            // Static method of class - shared between all class members
            if (Account.AccountAllowed(18, 10000))
            {
                Console.WriteLine("Account allowed");
            }
            else
            {
                Console.WriteLine("Account refused");
            };

            // create class member via constructor
            Account IAcc = new Account("Ilya", NewBalance:1000);

            Console.ReadKey();
        }
    }
}
