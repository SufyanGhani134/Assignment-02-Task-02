using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    public class SavingsAccount : BankAccount, ITransaction
    {
        // Fields
        public long InterestRate;   // Interest rate for the savings account
        public List<Transaction> TransactionList; // List to store object of class Transaction
        public SavingsAccount(string HolderName, double Balance, long interestRate, AccountCatogeroy accountType) :
            base(HolderName, Balance)
        {
            accountType.AddAccount(this);
            //adding object of class SavingsAccount to dictionary bankAccounts by AddAccount() method define in 
            //AccountCategory class
            InterestRate = interestRate;
            TransactionList = new List<Transaction>(); //creating an empty list of object of Transaction class
        }
        public override long CalculateInterest() //override CalculateInterest() method inherited from class BankAccount
        {
            return (long)(getBalance() * 0.01 * InterestRate);
        }

        public override bool Deposit(double amount) //override Deposit() method inherited from class BankAccount
        {
            setBalance(getBalance() + amount + CalculateInterest());
            return true;
        }
        public override void DisplayAccountInfo() //override DisplayAccountInfo() method inherited from class BankAccount
        {
            Console.WriteLine("         Account Info");
            Console.WriteLine($"Account Type:       Savings Account");
            Console.WriteLine($"Account Number :    {getAccountNumber()}");
            Console.WriteLine($"Holder's Name :     {getHolderName()}");
            Console.WriteLine($"Balance :           {getBalance()}");
            Console.WriteLine("------------------------------------------------------------------------");

        }

        public override bool Withdraw(double amount) //override Withdraw() method inherited from class BankAccount
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

        //define body of ExecuteTransaction method from ITransaction interface
        public void ExecuteTransaction(double amount, string type)
        {
            bool status = false;
            if(type.ToLower().Trim() == "deposit")
            {
                status = Deposit(amount);
            }else if(type.ToLower().Trim() == "withdraw")
            {
                status = Withdraw(amount);
                  
            }

            if(status == true)
            {

                Console.WriteLine("Transaction has been completed successfully!");
                PrintTransaction(amount, type, "Successful");
                //Create a new object from class Transaction by passing type, date&time and status of transaction to 
                //Transaction constructor
                Transaction transaction = new Transaction(type, DateTime.Now, amount, "Successful");
                //Adding transaction object in TransactionList of SavingsAccount object
                TransactionList.Add(transaction);
            }
            else
            {
                Console.WriteLine("Invalid Transaction!");
                //Create a new object from class Transaction by passing type, date&time and status of transaction to 
                //Transaction constructor
                Transaction transaction = new Transaction(type, DateTime.Now, amount, "Failed");
                //Adding transaction object in TransactionList of SavingsAccount object
                TransactionList.Add(transaction);
            }


        }

        //define body of PrintTransaction method from ITransaction interface
        public void PrintTransaction(double amount, string type, string status)
        {
            Console.WriteLine("         Transaction Details");
            Console.WriteLine("Date & Time : " + DateTime.Now);
            Console.WriteLine($"{type} amount :" + amount);
            Console.WriteLine($"Transaction Status :" + status);
            Console.WriteLine("------------------------------------------------------------------------");

        }

        //override DisplayTransactionHistory abstract method define in class BankAccount
        public override void DisplayTransactoinHistory()
        {
            Console.WriteLine($"Transaction History of {getHolderName()} with Accunt Number {getAccountNumber()} ");
            Console.WriteLine();
            //iterating through each object of class Transaction in TransactionList
            foreach(Transaction transaction in TransactionList)
            {
                Console.WriteLine($"{transaction.DateAndTime}");
                Console.WriteLine($"Transaction Type:     {transaction.Type}");
                Console.WriteLine($"Transaction Amount:     {transaction.TransactionAmount}");
                Console.WriteLine($"Transaction Status :  {transaction.Status}");
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------------------------------");
        }
    }
}
