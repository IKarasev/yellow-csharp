using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusObj
{
    // creating account interface
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

        private decimal balance = 0;
        private string name;

        public void PayInFunds(decimal amount)
        {
            balance += amount;
        }

        public bool WithdrawFunds(decimal amount)
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

        // creating method to store account in file
        public bool Save(string filename)
        {
            try
            {
                System.IO.TextWriter textOut = new System.IO.StreamWriter(filename);
                textOut.WriteLine(name);
                textOut.WriteLine(balance);
                textOut.Close();
            } catch
            {
                return false;
            }
            return true;
        }

        // function to load an account data from file
        public static CustomerAccount Load(string filename)
        {
            CustomerAccount result = null;
            System.IO.TextReader textIn = null;

            try
            {
                textIn = new System.IO.StreamReader(filename);
                string nameText = textIn.ReadLine();
                string balanceText = textIn.ReadLine();
                decimal balance = decimal.Parse(balanceText);
                result = new CustomerAccount(nameText, balance);
            }
            catch
            {
                return null;
            }
            finally
            {
                if (textIn != null)
                    textIn.Close();
            }
            return result;
        }
    }  

    class Program
    {
        static void Main(string[] args)
        {
            string fname = "test.txt";
            // testing saving and loading
            CustomerAccount acc = new CustomerAccount("John", 1000);
            if (acc.Save(fname))
            {
                Console.WriteLine($"Account {acc.GetName()} is saved in {fname}");
            } else
            {
                Console.WriteLine("Save failed");
            }

            // loading the account:
            CustomerAccount loaded = CustomerAccount.Load(fname);
            if (loaded == null)
            {
                Console.WriteLine($"Failed to load account from {fname}");
            } else
            {
                Console.WriteLine($"Account [{loaded.GetName()}] is loaded.\nBalance: {loaded.GetBalance()}");
            }

            Console.ReadKey();
        }
    }
}
