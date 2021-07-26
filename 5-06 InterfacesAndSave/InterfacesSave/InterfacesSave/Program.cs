using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesSave
{
    // Interface with save methods
    public interface IAccount
    {
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
        string GetName();
        
        bool Save(string filename);
        void Save(System.IO.TextWriter textOut);
    }

    // loading is treaky, as we don't know the type of acc, so we need to change save method
    // to write type in the file
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

        // here we add writing the type
        public virtual void Save(System.IO.TextWriter textOut)
        {
            textOut.WriteLine(this.GetType().Name);
            textOut.WriteLine(name);
            textOut.WriteLine(balance);
        }

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

        public BabyAccount(System.IO.TextReader textIn) : base(textIn)
        {
            parentName = textIn.ReadLine();
        }
    }

    public interface IBank
    {
        IAccount FindAccount(string name);
        bool StoreAccount(IAccount account);
    }

    public class DictionaryBank : IBank
    {
        Dictionary<string, IAccount> bankDictionary = new Dictionary<string, IAccount>();

        public bool StoreAccount(IAccount account)
        {
            bankDictionary.Add(account.GetName(), account);
            return true;
        }

        public IAccount FindAccount(string name)
        {
            return bankDictionary[name] as IAccount;
        }

        public void Save(System.IO.TextWriter textOut)
        {
            textOut.WriteLine(bankDictionary.Count);
            foreach (CustomerAccount acc in bankDictionary.Values)
            {
                acc.Save(textOut);
            }
        }

        // We need to change load method to address the new line in file (account type)
        public static DictionaryBank Load(System.IO.TextReader textIn)
        {
            DictionaryBank res = new DictionaryBank();
            string countString = textIn.ReadLine();
            int count = int.Parse(countString);

            for (int i = 0; i < count; i++)
            {
                string className = textIn.ReadLine();
                // instead of directly reading the file we use factory class method
                IAccount account = AccountFactory.MakeAccount(className, textIn);
                res.bankDictionary.Add(account.GetName(), account);
            }
            return res;
        }
    }

    // adding new class to store general methods regardless accounts
    // that logically don't belong into account class
    class AccountFactory
    {
        // method to get account based on it type name
        public static IAccount MakeAccount(string name, System.IO.TextReader textIn)
        {
            switch (name)
            {
                case "CustomerAccount":
                    return new CustomerAccount(textIn);
                case "BabyAccount":
                    return new BabyAccount(textIn);
                default:
                    return null;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
