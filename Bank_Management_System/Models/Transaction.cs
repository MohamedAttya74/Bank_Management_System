using Bank_Management_System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int TransactionNumber { get; set; }
        public TransactionType transactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Note  { get; set; }
        public decimal Amount { get; set; }
        public int  AccountId { get; set; }
        public Account account { get; set; }




    }
}
