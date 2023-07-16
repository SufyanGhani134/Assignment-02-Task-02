using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creation of an object from class Bank 
            Bank bank = new Bank();  
            //Creation of objects from AccountCategory class each specify type of bankAccounts
            AccountCatogeroy savingsAccount = new AccountCatogeroy("Savings Account");
            AccountCatogeroy checkingAccount = new AccountCatogeroy("Checking Account");
            AccountCatogeroy loanAccount = new AccountCatogeroy("Loan Account");
            //adding instances of class AccountCategory in a List in the Object of Bank class 
            bank.AddAccount(savingsAccount);
            bank.AddAccount(checkingAccount);
            bank.AddAccount(loanAccount);

            //Creating an object "Ben" from SavingsAccount class inherited from abstract class BankAccount and passing
            //savingsAccount instance which will add the bankAccount object "Ben" in a dictionary  bankAccounts with the Accoun Number
            //as key and bankAccount as value
            SavingsAccount Ben = new SavingsAccount("Ben", 200, 5,savingsAccount);
            //Method defined in class SavingAccounts to display BankAccount info inherited from class BankAccount
            //as abstract method 
            Ben.DisplayAccountInfo();

            //Creating an object "Henry" from CheckingAccount class inherited from abstract class BankAccount and passing
            //checkingAccount instance which will add the bankAccount object "Henry" in a dictionary  bankAccounts with the Account Number
            //as key and bankAccount as value
            CheckingAccount Henry = new CheckingAccount("Henry", 500, checkingAccount);
            //Method defined in class CheckingAccount to display BankAccount info inherited from class BankAccount
            //as abstract method
            Henry.DisplayAccountInfo();

            // Creating an object "Daniel" from LoanAccount class inherited from abstract class BankAccount and passing
            //LoanAccount instance which will add the bankAccount object "Daniel" in a dictionary  bankAccounts with the Account Number
            //as key and bankAccount as value
            LoanAccount Daniel = new LoanAccount("Daniel", 0, loanAccount, 10);
            //Method defined in class LoanAccount to display BankAccount info inherited from class BankAccount
            //as abstract method
            Daniel.DisplayAccountInfo();

            Console.WriteLine();
            Console.WriteLine("         Transactions");
            //ITransaction is an interface which have two methods ExecuteTransaction and PrintTransaction which are 
            //overidden in each Account Category to perform Transactions and display the details of transaction
            Ben.ExecuteTransaction(300, "Deposit"); 
            Ben.ExecuteTransaction(10, "withdraw");
            Ben.ExecuteTransaction(50, "Depos");
            //DisplayTransactionHistory is an abstract method define in class BankAccount and overide in each class SavingsAccount
            // that displays all the transactions of the object created from SavingsAccount class.
            Ben.DisplayTransactoinHistory();

            Console.WriteLine();
            Console.WriteLine("         Transactions");
            Henry.ExecuteTransaction(300, "Deposit");
            Henry.ExecuteTransaction(10, "withdraw");
            Henry.ExecuteTransaction(50, "Depos");
            //DisplayTransactionHistory is an abstract method define in class BankAccount and overide in each class CheckingAccount
            // that displays all the transactions of the object created from CheckingAccount class.
            Henry.DisplayTransactoinHistory();

            Console.WriteLine();
            Console.WriteLine("         Transactions");
            Daniel.ExecuteTransaction(300, "getloan");
            Daniel.ExecuteTransaction(1000, "payloan");
            Daniel.ExecuteTransaction(50, "payloan");
            //DisplayTransactionHistory is an abstract method define in class BankAccount and overide in each class LoanAccount
            // that displays all the transactions of the object created from LoanAccount class.
            Daniel.DisplayTransactoinHistory();

            //ExecuteTransaction method from ITransaction interface is overiden in class Bank to perform transactions 
            //across bank accounts
            bank.ExecuteTransaction(300, "transferMoney");
            Console.ReadKey();
        }
    }
}
