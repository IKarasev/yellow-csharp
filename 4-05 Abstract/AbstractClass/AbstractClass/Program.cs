using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    // Creating interface that contains all required methods for all inherit classes
    public interface IAccount
    {
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
        string RudeLetterString();
    }

    // Creating abstract class. It is needed if abstract method would be used. Abstract methods
    // are used when each child class will have different behaviour for it.
    public abstract class Account : IAccount
    {
        private decimal balance;

        // abstract class definition. No operations inside needed as it'll be different for all child classes
        public abstract string RudeLetterString();

        public void PayInFunds(decimal amount)
        {
            balance += amount;
        }

        // this is virtual. All child classes will have it, but some can change it;
        public virtual bool WithdrawFunds(decimal amount)
        {
            if (balance < amount)
            {
                return false;
            }

            balance -= amount;
            return true;
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }

    // Create first child class, notice interface is not implemented here, as it already done in parent class
    public class CustomerAccount : Account
    {
        // ovveride abstract method from parent.
        // all abstract methods from parent have to be complited in child
        public override string RudeLetterString()
        {
            return "You are overdrawn";
        }
    }

    // Creating second child
    public class BabyAccount : Account
    {
        // Overide abstract method from parent
        public override string RudeLetterString()
        {
            return "Tell daddy you are overdrawn";
        }

        // Overide WithdrawFunds with some changes
        public override bool WithdrawFunds(decimal amount)
        {
            if (amount > 10)
            {
                return false;
            }
            return base.WithdrawFunds(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }
}
