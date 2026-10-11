using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Enums
{
    public enum TransactionType : byte
    {
        deposit = 1, 
        withdrawal = 2,
        transfer = 3, 
        payment = 4

    }
}
