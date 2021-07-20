using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProgram
{
    // Account interface
    public interface IAccount
    {
        string GetName();
    }

    // Bank interface. Have two methods - finding account by name
    // and saving the account;
    public interface IBank
    {
        IAccount FindAccount(string name);
        bool StoreAccount(IAccount account);
    }

    // Class to store bank accounts
    public class ArrayBank : IBank
    {
        // aray of references to bank account
        private IAccount[] accounts;

        // constructor that sets the number of allowed bank accounts
        public ArrayBank(int bankSize)
        {
            accounts = new IAccount[bankSize];
        }

        // Creating the method to hold new account in first empty array cell
        public bool StoreAccount(IAccount account)
        {
            int pos;
            for (pos = 0; pos < accounts.Length; pos++)
            {
                if (accounts[pos] == null)
                {
                    accounts[pos] = account;
                    return true;
                }
            }
            return false;
        }

        // Find account method from IBank
        public IAccount FindAccount(string name)
        {
            int pos;
            for (pos = 0; pos < accounts.Length; pos++)
            {
                // if cell is empty - skip it
                if (accounts[pos] == null)
                {
                    continue;
                }
                if (accounts[pos].GetName() == name)
                {
                    return accounts[pos];
                }
            }
            return null;
        }
    }

    // Account class
    public class Account : IAccount
    {
        private string name;
        private decimal balance;

        public string GetName()
        {
            return this.name;
        }

        public Account(string inName, decimal inBalance)
        {
            this.name = inName;
            this.balance = inBalance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAccount acc = new Account("Rob", 50);

            ArrayBank ourBank = new ArrayBank(100);

            if (ourBank.StoreAccount(acc) == true)
            {
                Console.WriteLine("Account added to bank");
            } else
            {
                Console.WriteLine("Failed to add account");
            }

            IAccount storedAccount = ourBank.FindAccount("Rob");
            if (storedAccount != null) Console.WriteLine("Account found in bank");

            Console.ReadKey();
        }
    }
}
