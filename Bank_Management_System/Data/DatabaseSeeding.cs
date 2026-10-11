using Bank_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Data
{
    public static class DatabaseSeeding
    {
        public static void Seed(BankDbContext context)
        {
            if (!context.Mangers.Any())
            {
                List<Manger> managers = new List<Manger>
                {
                    new Manger()
                    {
                        FullName= "Mohamed Ali",
                        Email= "mohamed.ali@example.com" ,
                        PhoneNumber= "1234567890",
                        HireData= new DateOnly(2020, 1, 15),

                    },
                    new Manger()
                    {
                        FullName= "Sara Ahmed",
                        Email= "sara.ahmed@example.com" ,
                        PhoneNumber= "0987654321",
                        HireData= new DateOnly(2021, 3, 10),

                    },
                    new Manger()
                    {
                        FullName= "Ahmed Hassan",
                        Email= "ahmed.hassan@example.com" ,
                        PhoneNumber= "555-1234",
                        HireData= new DateOnly(2022, 6, 1),

                    }
                };

                context.Mangers.AddRange(managers);
                context.SaveChanges();

            }




            if (!context.Branches.Any())
            {
                List<Branch> branches = new List<Branch>
                {
                    new Branch()
                    {
                        BranchName = "Downtown Branch",
                        Code =  "CA01",
                        BranchAddress = "123 Main St, Cityville",
                        PhoneNumber = "555-1234",
                        MangerId = 1
                        

                    },
                    new Branch()
                    {
                    BranchName = "Alex Branch",
                        Code =  "ALEX",
                        BranchAddress ="456 Oak Ave, Townsville",
                        PhoneNumber = "555-5678",
                        MangerId = 2

                    },
                    
                };

                context.Branches.AddRange(branches);
                context.SaveChanges();
            }
        }



    }
}
