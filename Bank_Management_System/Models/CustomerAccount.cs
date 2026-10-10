using Bank_Management_System.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models
{
    public class CustomerAccount
    {
        public int CustomerId { get; set; } // Foreign key to the Customer entity
        public Customer customer { get; set; }

        public int AccountId { get; set; }  // Foreign key to the Account entity
        public Account account { get; set; }
        public DateOnly OwnerShipStartDate { get; set; }
        public OwnerShipType OwnerShipType { get; init; }
        public AccountStatus AccountStatus { get; set; }
    }
}
