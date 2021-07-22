using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffAccs
{
    public interface IAccount
    {
        void PayInFunds(decimal amount); // add balance
        bool WithdrawFunds(decimal amount); // reduce balance
        decimal GetBalance();
        string GetName();
    }

    // general account class
    public class CustomerAccount : IAccount
    {
        // constructor
        public CustomerAccount(string inName, decimal inBalance)
        {
            balance = inBalance;
            name = inName;
        }

        public CustomerAccount(System.IO.TextReader textIn)
        {
            name = textIn.ReadLine();
            string balanceText = textIn.ReadLine();
            balance = decimal.Parse(balanceText);
        }

        private decimal balance = 0;
        private string name;

        public void PayInFunds(decimal amount)
        {
            balance += amount;
        }

        public virtual bool WithdrawFunds(decimal amount)
        {
            if (balance < amount)
                return false;

            balance -= amount;
            return true;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public string GetName()
        {
            return name;
        }

        // A better solution is to give the file save method a stream to save itself, rather than a filename
        public virtual void Save(System.IO.TextWriter textOut)
        {
            textOut.WriteLine(name);
            textOut.WriteLine(balance);
        }

        // creating method to store account in file
        public bool Save(string filename)
        {
            try
            {
                System.IO.TextWriter textOut = new System.IO.StreamWriter(filename);
                Save(textOut);
                textOut.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        // function to load an account data from file
        // using method overloading to manage IO only
        public static CustomerAccount Load(System.IO.TextReader textIn)
        {
            CustomerAccount result = null;
            try
            {
                string nameText = textIn.ReadLine();
                string balanceText = textIn.ReadLine();
                decimal balance = decimal.Parse(balanceText);
                result = new CustomerAccount(nameText, balance);
            }
            catch
            {
                return null;
            }
            return result;
        }
    }

    // Bank interface. Have two methods - finding account by name
    // and saving the account;
    public interface IBank
    {
        IAccount FindAccount(string name);
        bool StoreAccount(IAccount account);
    }

    // Class to store bank accounts
    public class DictionaryBank : IBank
    {
        Dictionary<string, IAccount> bankDictionary = new Dictionary<string, IAccount>();

        // adding account to hashtable with name as key
        public bool StoreAccount(IAccount account)
        {
            bankDictionary.Add(account.GetName(), account);
            return true;
        }

        // retriving account from hashtable by name (key)
        public IAccount FindAccount(string name)
        {
            return bankDictionary[name] as IAccount;
        }

        // Method to save all accounts in one file
        public void Save(System.IO.TextWriter textOut)
        {
            textOut.WriteLine(bankDictionary.Count);
            foreach (CustomerAccount acc in bankDictionary.Values)
            {
                acc.Save(textOut);
            }
        }

        // Loading all accounts to bank
        public static DictionaryBank Load(System.IO.TextReader textIn)
        {
            DictionaryBank res = new DictionaryBank();
            string countString = textIn.ReadLine();
            int count = int.Parse(countString);

            for (int i = 0; i < count; i++)
            {
                CustomerAccount account = CustomerAccount.Load(textIn);
                res.bankDictionary.Add(account.GetName(), account);
            }
            return res;
        }
    }

    // Creating child class to CustomerAccount
    public class BabyAccount : CustomerAccount
    {
        private string parentName;

        public string GetParantName()
        {
            return parentName;
        }

        // override withdraw method
        public override bool WithdrawFunds(decimal amount)
        {
            if (amount > 10)
                return false;

            return base.WithdrawFunds(amount);
        }

        // constructor
        public BabyAccount(string inName, decimal inBalance, string inPName) : base(inName, inBalance)
        {
            parentName = inPName;
        }

        // overriding save method
        public override void Save(System.IO.TextWriter textOut)
        {
            base.Save(textOut);
            textOut.WriteLine(parentName);
        }

        // method to load bb acc
        // bad way (if we change parent method we should change this method as well:
        //public static BabyAccount Load(System.IO.TextReader textIn)
        //{
        //    BabyAccount res = null;
        //    try
        //    {
        //        string name = textIn.ReadLine();
        //        string balanceText = textIn.ReadLine();
        //        decimal balance = decimal.Parse(balanceText);
        //        string parent = textIn.ReadLine();
        //        res = new BabyAccount(name, balance, parent);
        //    } catch
        //    {
        //        return null;
        //    }
        //    return res;
        //}

        // good way use constructor with access to parent one
        public BabyAccount(System.IO.TextReader textIn) : base(textIn)
        {
            parentName = textIn.ReadLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BabyAccount babyJane = new BabyAccount("Jane", 20, "John");

            Console.ReadKey();
        }
    }
}
