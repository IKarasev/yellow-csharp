using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{

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
    public class DictionaryBank : IBank
    {
        // bank stack could be realised with dictionaries
        Dictionary<string, IAccount> accountDictionary = new Dictionary<string, IAccount>();

        // adding account to hashtable with name as key
        public bool StoreAccount(IAccount account)
        {
            // before storing account we need to check if it already exist
            // otherwise run will drop exception
            if (accountDictionary.ContainsKey(account.GetName()))
                return false;

            accountDictionary.Add(account.GetName(), account);
            return true;
        }

        // retriving account from dictionary by name (key)
        public IAccount FindAccount(string name)
        {
            // before storing we also need to check if it exists
            if (accountDictionary.ContainsKey(name))
                return accountDictionary[name];
            else
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
        }
    }
}
