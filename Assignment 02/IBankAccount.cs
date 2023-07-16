using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    //make an interface to initialize Deposit and withdraw methods 
    interface IBankAccount
    {
        bool Deposit(double amount);
        bool Withdraw(double amount);
    }
}
