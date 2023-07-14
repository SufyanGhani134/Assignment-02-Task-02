using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02_Task_02
{
    interface IBankAccount
    {
        void Deposit(double amount);
        void Withdraw(double amount);
    }

    interface ITransaction
    {
        void ExecuteTransaction(double amount);
        void PrintTransaction(double amount);
    }
    public abstract class BankAccount : IBankAccount
    {
        protected string AccountNumber;
        protected string HolderName;
        protected double Balance;

        public BankAccount(string accountNumber, string holderName, double balance)
        {
            AccountNumber = accountNumber;
            HolderName = holderName;
            Balance = balance;
        }

        public string getAccountNumber() { return AccountNumber; }
        public virtual void Deposit(double amount)
        {
            Balance += amount;
        }
        public virtual void Withdraw(double amount)
        {
            Balance -= amount;
        }
        public abstract void DisplayAccountInfo();
        public abstract long CalculateInterest(long interestRate);

    }

    public class AccountCatogeroy
    {
        public string AccountType;
        private Dictionary<string, BankAccount> bankAccounts;
        public AccountCatogeroy(string accountType)
        {
            AccountType = accountType;
            bankAccounts = new Dictionary<string, BankAccount>();
        }
        public void AddAccount(BankAccount bankAccount)
        {
            bankAccounts.Add(bankAccount.getAccountNumber(), bankAccount);
        }
    }

    public class SavingsAccount : BankAccount, ITransaction
    {
        public long InterestRate;
        public List<Transaction> TransactionList;
        public SavingsAccount(string AccountNumber, string HolderName, double Balance, long interestRate, AccountCatogeroy accountType) :
            base(AccountNumber, HolderName, Balance)
        {
            accountType.AddAccount(this);
            InterestRate = interestRate;
            TransactionList = new List<Transaction>();
        }

        public override void Deposit(double amount)
        {
            Balance += amount + CalculateInterest(InterestRate);
        }

        public override void DisplayAccountInfo()
        {
            Console.WriteLine("         Account Info");
            Console.WriteLine($"Account Number :    {AccountNumber}");
            Console.WriteLine($"Holder's Name :     {HolderName}");
            Console.WriteLine($"Balance :           {Balance}");
        }
        public override long CalculateInterest(long InterestRate)
        {
            return (long)(Balance * 0.01 * InterestRate);
        }

        public void ExecuteTransaction(double amount)
        {
            Deposit(amount);
            PrintTransaction(amount);
            Transaction transaction = new Transaction("deposit", DateTime.Now, amount);
            TransactionList.Add(transaction);

        }

        public void PrintTransaction(double amount)
        {
            Console.WriteLine("         Transaction Details");
            Console.WriteLine("Date & Time : " + DateTime.Now);
            Console.WriteLine("Deposited Amount :" + amount);
            DisplayAccountInfo();
        }
    }

    public class CheckingAccount : BankAccount, ITransaction
    {
        public CheckingAccount(string AccountNumber, string HolderName, double Balance, AccountCatogeroy accountType)
            : base(AccountNumber, HolderName, Balance)
        {
            accountType.AddAccount(this);
        }
        public override void Withdraw(double amount)
        {
            if (amount < Balance)
            {
                Console.WriteLine("Error! Entered Amount to withdraw exceeds Account Balance limit.");
            }
            else
            {
                base.Withdraw(amount);
            }
        }
        public override void DisplayAccountInfo()
        {
            Console.WriteLine("         Account Info");
            Console.WriteLine($"Account Number :    {AccountNumber}");
            Console.WriteLine($"Holder's Name :     {HolderName}");
            Console.WriteLine($"Balance :           {Balance}");
        }
        public override long CalculateInterest(long InterestRate)
        {
            return (long)(Balance * 0.01 * InterestRate);
        }

        public void ExecuteTransaction(double amount)
        {
            Withdraw(amount);
            PrintTransaction(amount);
        }

        public void PrintTransaction(double amount)
        {
            Console.WriteLine("         Transaction Details");
            Console.WriteLine("Date & Time : " + DateTime.Now);
            Console.WriteLine("Withdraw Amount :" + amount);
            DisplayAccountInfo();
        }
    }

    public class LoanAccount : BankAccount, ITransaction
    {
        public LoanAccount(string AccountNumber, string HolderName, double Balance, AccountCatogeroy accountType)
            : base(AccountNumber, HolderName, Balance)
        {
            accountType.AddAccount(this);
        }
        public override void DisplayAccountInfo()
        {
            Console.WriteLine("         Account Info");
            Console.WriteLine($"Account Number :    {AccountNumber}");
            Console.WriteLine($"Holder's Name :     {HolderName}");
            Console.WriteLine($"Balance :           {Balance}");
        }
        public override long CalculateInterest(long InterestRate)
        {
            return (long)(Balance * 0.01 * InterestRate);
        }

        public void ExecuteTransaction(double amount)
        {
            Deposit(amount);
            PrintTransaction(amount);
        }

        public void PrintTransaction(double amount)
        {
            Console.WriteLine("         Transaction Details");
            Console.WriteLine("Date & Time : " + DateTime.Now);
            Console.WriteLine("Deposited Amount :" + amount);
            DisplayAccountInfo();
        }
    }

    public class Transaction
    {
        public string Type;
        public DateTime DateAndTime;
        public double TransactionAmount;
        public Transaction(string type, DateTime dateAndtime, double transactionAmount)
        {
            Type = type;
            DateAndTime = dateAndtime;
            TransactionAmount = transactionAmount;
        }
    }
    public class Bank
    {
        public List<AccountCatogeroy> AccountTypes;
        public Bank()
        {
            AccountTypes = new List<AccountCatogeroy>();
        }
        public void AddAccount(AccountCatogeroy accountType)
        {
            AccountTypes.Add(accountType);
        }

        //public void DepositToAccount(string accountNumber, double amount)
        //{
        //    bool isAccount = false;
        //    foreach(BankAccount account in bankAccounts)
        //    {
        //        if (accountNumber== account.getAccountNumber()) 
        //        {
        //            account.Deposit(amount);
        //            isAccount = true;
        //        }
        //    }
        //    if (!isAccount)
        //    {
        //        Console.WriteLine("Invalid Account Number!");
        //    }
            //}

        //public void WithDrawFromAccount(string accountNumber, double amount)
        //{
        //    bool isAccount = false;
        //    foreach (BankAccount account in bankAccounts)
        //    {
        //        if (accountNumber == account.getAccountNumber())
        //        {
        //            account.Withdraw(amount);
        //            isAccount = true;
        //        }
        //    }
        //    if (!isAccount)
        //    {
        //        Console.WriteLine("Invalid Account Number!");
        //    }
        //}
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            AccountCatogeroy savingsAccount = new AccountCatogeroy("SavingsAccount");
            SavingsAccount Ben = new SavingsAccount("ABC123456", "Ben", 100, 5, savingsAccount);
            SavingsAccount Henry = new SavingsAccount("XYZ987654", "Henry", 230,2, savingsAccount);
            Ben.ExecuteTransaction(100);
            Ben.ExecuteTransaction(800);

            bank.AddAccount(savingsAccount);

            AccountCatogeroy checkingAccount = new AccountCatogeroy("Checking Account");
            CheckingAccount Daniel = new CheckingAccount("abc098765", "Daniel", 200, checkingAccount);
            bank.AddAccount(checkingAccount);
            Console.WriteLine(Guid.NewGuid());
            Console.ReadKey();
        }
    }
}
