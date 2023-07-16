using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    class Bank:ITransaction //initializing class Bank inheriting ITransaction interface
    {
        private List<AccountCatogeroy> AccountTypes; //define a list of bank account types as private field 
        private List<BankAccount> AllAccountsList;  //define a list of all bank accounts as private field
        public Bank() //constructor of class Bank
        {
            AccountTypes = new List<AccountCatogeroy>();   //Initializing an empty list of objects of class AccountCategory
            AllAccountsList = new List<BankAccount>();     //Initializing an empty list of objects of class BankAccount
        }

        //Method that adds object of AccountCategory in list of AccountTypes
        public void AddAccount(AccountCatogeroy accountType)
        {
            AccountTypes.Add(accountType);   
        }

        //a method that gets each bankAccounts dictionary from  getter define in object of class AccountCategory
        //placed in list AccountTypes and save the values in AllAccountsList
        public void getAllAccounts()
        {
            foreach(var account in AccountTypes) //iterating throught AccountTypes List objects
            {
                //iterating through the bankAccounts dictionary returned from GetKeyValuePairs getter
                foreach (var item in account.GetKeyValuePairs()) 
                {
                    //Add values of bankAccounts dictionary in AllAccountsList
                    AllAccountsList.Add(item.Value);
                }
            }
        }

        //ExecuteTransaction method from ITransation interface that transfer money from one account to another account
        public void ExecuteTransaction(double amount, string type)
        {
            getAllAccounts(); //generate a list of all bank accounts as defined in this method
            if(type == "transferMoney") 
            {
                Console.WriteLine("Enter Your Account Number :");
                Guid AccountFrom = Guid.Parse(Console.ReadLine());  //get Account Number from which money is being transferred 
                Console.WriteLine("Enter Account Number you want to transfer money :");
                Guid AccountTo = Guid.Parse(Console.ReadLine());    //get Account Number from which money is being transferred
                //flags for Account Numbers if present or not
                bool isAccountFrom = false; 
                bool isAccountTo = false;
                //iterate through AllAccountsList items
                foreach (var item in AllAccountsList)  
                {
                    //check if AccountFrom matches with the Account Number of any bankAccount from AllAccountsList
                    //with the help of getAccountNumber() getter. Also check if the transfer amount doesn't exceed the 
                    //Account Balance with the help of getBalance() getter
                    if (item.getAccountNumber() == AccountFrom && item.getBalance() > amount)
                    {
                        //set new Balance by subtracting amount from AccountFrom Balance
                        item.setBalance(item.getBalance() - amount);
                        isAccountFrom = true; //set flag true for AccountFrom present
                    }

                    //check if AccountTo matches with the Account Number of any bankAccount from AllAccountsList
                    //with the help of getAccountNumber() getter.
                    if (item.getAccountNumber() == AccountTo)
                    {
                        //set new Balance by adding amount to AccountTo Balance
                        item.setBalance(item.getBalance() + amount);
                        isAccountTo = true; //set flag true for AccountTo present
                    }
                }

                //check if any of the Account Number is not present
                if (!isAccountFrom || !isAccountTo) 
                {
                    Console.WriteLine("     Invalid Transaction!");
                    Console.WriteLine("Please check account numbers or transfer amount!");
                }
                else
                {
                    //if Transaction takes place it will execute PrintTransaction method from ITransaction interface
                    //that will display the transaction details
                    PrintTransaction(amount, type, "successful");
                }

            }
            else //if Transaction Type is not correct
            {
                Console.WriteLine("     Invalid Transaction!!");
            }
        }
        //PrintTransaction method from ITransaction interface will display all details of the transaction
        public void PrintTransaction(double amount, string type, string status)
        {
            Console.WriteLine("Transaction has been completed successfully!");
            Console.WriteLine("         Transaction Details");
            Console.WriteLine("Date & Time : " + DateTime.Now);
            Console.WriteLine($"{type} amount :" + amount);
            Console.WriteLine($"Transaction Status :" + status);
            Console.WriteLine("------------------------------------------------------------------------");

        }
    }
}
