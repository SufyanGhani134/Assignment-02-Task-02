using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    interface ITransaction
    {
        //make an interface to initialize ExecuteTransaction and PrintTransaction methods 

        void ExecuteTransaction(double amount, string type);
        void PrintTransaction(double amount, string type, string status);
    }
}
