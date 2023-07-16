using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    public class CheckingAccount : BankAccount, ITransaction
    {
        public List<Transaction> TransactionList;

        public CheckingAccount(string HolderName, double Balance, AccountCatogeroy accountType)
            : base(HolderName, Balance)
        {
            TransactionList = new List<Transaction>();
            accountType.AddAccount(this);
        }
        public override long CalculateInterest()
        {
            return (long)(getBalance() * 0.01 * 5);
        }

        public override void DisplayAccountInfo()
        {
            Console.WriteLine("         Account Info");
            Console.WriteLine($"Account Number :    {getAccountNumber()}");
            Console.WriteLine($"Holder's Name :     {getHolderName()}");
            Console.WriteLine($"Balance :           {getBalance()}");
            Console.WriteLine("------------------------------------------------------------------------");

        }

        public override bool Withdraw(double amount)
        {
            bool status = false;
            if (amount > getBalance())
            {
                Console.WriteLine("Error! Entered Amount to withdraw exceeds Account Balance limit.");
                Console.WriteLine("------------------------------------------------------------------------");

            }
            else
            {
                base.Withdraw(amount);
                status = true;
            }
            return status;
        }
        public void ExecuteTransaction(double amount, string type)
        {
            bool status = false;
            if (type.ToLower().Trim() == "deposit")
            {
                status = Deposit(amount);
            }
            else if (type.ToLower().Trim() == "withdraw")
            {
                status = Withdraw(amount);
            }

            if (status == true)
            {
                PrintTransaction(amount, type, "Successful");
                Transaction transaction = new Transaction(type, DateTime.Now, amount, "Successful");
                TransactionList.Add(transaction);
            }
            else
            {
                PrintTransaction(amount, type, "Failed");
                Transaction transaction = new Transaction(type, DateTime.Now, amount, "Failed");
                TransactionList.Add(transaction);
                Console.WriteLine("Invalid Transaction!");
                Console.WriteLine("------------------------------------------------------------------------");

            }


        }
        public void PrintTransaction(double amount, string type, string status)
        {
            Console.WriteLine("Transaction has been completed successfully!");
            Console.WriteLine("         Transaction Details");
            Console.WriteLine("Date & Time : " + DateTime.Now);
            Console.WriteLine($"{type} amount :" + amount);
            Console.WriteLine($"Transaction Status :" + status);
            Console.WriteLine("------------------------------------------------------------------------");

        }

        public override void DisplayTransactoinHistory()
        {
            Console.WriteLine($"Transaction History of {getHolderName()} with Accunt Number {getAccountNumber()} ");
            foreach (Transaction transaction in TransactionList)
            {
                Console.WriteLine($"{transaction.DateAndTime}");
                Console.WriteLine($"Transaction Type:     {transaction.Type}");
                Console.WriteLine($"Transaction Amount:     {transaction.TransactionAmount}");
                Console.WriteLine($"Transaction Status :  {transaction.Status}");

            }
        }
    }
}
