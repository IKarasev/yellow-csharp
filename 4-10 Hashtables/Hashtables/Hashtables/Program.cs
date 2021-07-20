using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtables
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
    public class HashBank : IBank
    {
        // instead of array we can use hashtable
        Hashtable bankHashtable = new Hashtable();

        // adding account to hashtable with name as key
        public bool StoreAccount(IAccount account)
        {
            bankHashtable.Add(account.GetName(), account);
            return true;
        }

        // retriving account from hashtable by name (key)
        public IAccount FindAccount(string name)
        {
            // we need to use as - bankHashtable[name] returns reference to IAccount object
            // as will return null if non item found or it is not IAccount
            return bankHashtable[name] as IAccount;
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
