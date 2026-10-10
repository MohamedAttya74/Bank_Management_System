using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models
{
    public  class Branch
    {

        public int BranchId { get; set; }  // PK 
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string PhoneNumber { get; set; }

        public int MangerId { get; set; }
        public Manger Manger { get; set; } // Navigation Prop


        public ICollection<Account> Accounts { get; set; } // Navigation Prop

    }
}
