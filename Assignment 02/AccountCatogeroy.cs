using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    public class AccountCatogeroy
    {
        public string AccountType;  //initializong AccountType as public string
        //initializing a dictionary with Guid as key and BankAccount object as value
        private Dictionary<Guid, BankAccount> bankAccounts; 
        public AccountCatogeroy(string accountType)  //Constructor to build AccountCategory object by passing account type name as string
        {
            AccountType = accountType;  
            bankAccounts = new Dictionary<Guid, BankAccount>(); //Create a dictionary of bank accounts of a specific category
                                                                //by using account number as string and bankAccount object as value
        }
        public void AddAccount(BankAccount bankAccount)
        {
            bankAccounts.Add(bankAccount.getAccountNumber(), bankAccount);  //Add bankAccount object to the bankaccounts dictionary
            Console.WriteLine($"Your {AccountType} Account has been created successfully!");
            Console.WriteLine("------------------------------------------------------------------------");
        }

        public Dictionary<Guid, BankAccount> GetKeyValuePairs() { return bankAccounts; }

    }
}
