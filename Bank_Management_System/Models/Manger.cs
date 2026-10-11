using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Models
{
    public class Manger
    {
        public int MangerId { get; set; }
        public string FullName  { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly HireData { get; set; }

        public Branch Branch  { get; set; }

    }
}
