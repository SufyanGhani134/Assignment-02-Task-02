using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    public class Transaction
    {
        public string Type;
        public DateTime DateAndTime;
        public double TransactionAmount;
        public string Status;
        public Transaction(string type, DateTime dateAndtime, double transactionAmount, string status)
        {
            Type = type;
            DateAndTime = dateAndtime;
            TransactionAmount = transactionAmount;
            Status = status;
        }
    }
}
