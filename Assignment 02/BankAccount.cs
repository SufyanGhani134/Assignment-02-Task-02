using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    public abstract class BankAccount : IBankAccount
    {
        //private bankaccount fields
        private Guid AccountNumber;
        private string HolderName;
        private double Balance;

        public BankAccount(string holderName, double balance)
        {
            AccountNumber = Guid.NewGuid();
            HolderName = holderName;
            Balance = balance;
        }

        public Guid getAccountNumber() { return AccountNumber; } //define a getter to get account number in un-related classes 
        public string getHolderName() { return HolderName; } //define a getter to get account number in un-related classes 
        public double getBalance() { return Balance; } //define a getter to get account number in un-related classes 
        public void setBalance(double amount) { Balance = amount; }
        public virtual bool Deposit(double amount)  //define deposit method from IBankAccount interface as virtual to override in inherited classes
        {
            Balance += amount;
            return true;
        }
        public virtual bool Withdraw(double amount)  //define withdraw method from IBankAccount interface as virtual to override in inherited classes
        {
            Balance -= amount;
            return true;
        }
        public abstract void DisplayAccountInfo();  //initialize an abstract method to display account info
        public abstract void DisplayTransactoinHistory();  //initialize an abstract method to display account info
        public abstract long CalculateInterest();  //initialize an abstract method to calculate interest from interset rate

    }
}
