using Bank_Management_System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public AccountType AccountType { get; set; }

        public DateOnly OpeningDate { get; set; }

        public ICollection<CustomerAccount> customerAccounts { get; set; }


        public int BranchId { get; set; }
        public Branch branch { get; set; }


        public ICollection<Transaction> transactions { get; set; }



    }
}
