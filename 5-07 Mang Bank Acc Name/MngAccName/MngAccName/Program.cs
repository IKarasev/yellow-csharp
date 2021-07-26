using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngAccName
{
    public interface IAccount
    {
        string ValidateName(string inName);
        void SetName(string inName);
        string GetName();
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
    }

    public class Account : IAccount
    {
        private string name;
        private decimal balance;

        public Account(string inName, decimal inBalance)
        {
            this.name = inName;
            this.balance = inBalance;
        }

        // create method to validate name
        public string ValidateName(string inName)
        {
            if (inName == null || inName == "")
            {
                return "Name parameter null";
            }

            string trimmedName = name.Trim();
            if (trimmedName.Length == 0)
            {
                return "No text in the name";
            }
            
            return "";
        }

        public void SetName(string inName)
        {
            this.name = inName.Trim();
        }

        public string GetName()
        {
            return this.name;
        }

        public decimal GetBalance()
        {
            return this.balance;
        }

        public bool WithdrawFunds(decimal amount)
        {
            if (balance < amount)
            {
                return false;
            }
            this.balance -= amount;
            return true;
        }

        public void PayInFunds(decimal amount)
        {
            this.balance += amount;
        }
    }

    // good way to supply editing tool is via editor class
    public class AccountEditTextUI
    {
        private IAccount account;

        // constructor toset account. editor account cant exist without object it's editing
        public AccountEditTextUI(IAccount inAccount)
        {
            this.account = inAccount;
        }

        // edit name method
        public void EditName()
        {
            string nName;
            Console.WriteLine("Started name editor");
            while (true)
            {
                Console.Write("Enter the name: ");
                nName = Console.ReadLine();
                string reply = this.account.ValidateName(nName);
                if (reply.Length == 0)
                {
                    break;
                }
                Console.WriteLine($"Fail. {reply}");
            }

            this.account.SetName(nName);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Account a = new Account("Rob", 50);
            AccountEditTextUI nameEdit = new AccountEditTextUI(a);
            nameEdit.EditName();
            Console.WriteLine($"New name: {a.GetName()}");
            Console.ReadKey();
        }
    }
}
