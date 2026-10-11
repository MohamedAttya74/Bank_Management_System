using Bank_Management_System.Data;
using Bank_Management_System.Enums;
using Bank_Management_System.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System
{
    public static class BankMangment
    {

        public static void AddCustomer(BankDbContext dbContext)
        {
            Console.WriteLine("==== Add New Customer === ");

            string fullName = Prompt("Enter First Name :    ");
            string NationalId = Prompt("Enter National ID :   ");
            DateOnly dateOnly;
            while (DateOnly.TryParse(Prompt("Enter Date of Birth (yyyy-MM-dd) :  "), out dateOnly) == false)
            {
                DisplayError("Invalid Date Format. Please enter in yyyy-MM-dd format.");
            }
            string phoneNumber = Prompt("Enter Phone Number :   ");
            string email = Prompt("Enter Email :    ");
            string address = Prompt("Enter Address :  ");

            Console.WriteLine("Customer Type : \n      1) Individual \n        2) Business");

            CustomerType customerType = Prompt("Enter Customer Type (1 or 2) :  ") switch
            {
                "1" => CustomerType.Individual,
                "2" => CustomerType.Business,
                _ => CustomerType.Individual
            };

            if(dbContext.Customers.Any(C => C.NationalId == NationalId)) 
            {
                DisplayError("Customer with this National ID already exists.");
                return;
            }
            Customer customer = new Customer
            {
                FullName = fullName,
                Email = email,
                NationalId = NationalId,
                DateOfBirth = dateOnly,
                PhoneNumber = phoneNumber,
                Address = address,
                customerType = customerType

            };

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }

        public static void OpenAccountForCustomer(BankDbContext dbContext)
        {
            Console.WriteLine("===== Open Account For Customer");

            int AccNum = default;
            string AccountNumber = Prompt("Enter Account Number :  ");

            while (int.TryParse(AccountNumber, out AccNum))
                DisplayError("Invalid Account Number. Please enter a valid integer.");


            Console.WriteLine("AccountType:\n       1)Saving        2)Current       3)Business");
            AccountType type = Prompt("Choice ") switch
            {
                "1" => AccountType.Savings,
                "2" => AccountType.Current,
                "3" => AccountType.Business,
                _ => AccountType.Savings
            };



            string BranchCode = Prompt("Enter Branch Code :  ");


            int CusId = default;
            string customerId = Prompt("Enter Customer Id :  ");
            while (int.TryParse(customerId, out CusId))
                DisplayError("Invalid Customer Id. Please enter a valid integer.");




            Console.WriteLine("OwnerShipRole :\n       1)PrimaryHolder        2)CoHolder       ");
            OwnerShipType ownerShipType = Prompt("Choice ") switch
            {
                "1" => OwnerShipType.PrimaryHolder,
                "2" => OwnerShipType.CoHolder,
                _ => OwnerShipType.PrimaryHolder
            };

            if (!dbContext.Branches.Any(B => B.Code.ToLower() == BranchCode.ToLower()))
            {
                DisplayError($"Branch with this code : {BranchCode} does not exist.");
            }
            if (!dbContext.Customers.Any(C => C.CustomerId.ToString() == customerId))
            {
                DisplayError($"This Customer With Id : {customerId} does not exist ");
            }

            var AccountId = dbContext.Accounts.FirstOrDefault(C => C.AccountNumber.ToString() == AccountNumber).AccountId;

            var BranchId = dbContext.Branches.FirstOrDefault(B => B.Code.ToLower() == BranchCode.ToLower()).BranchId;

            Account NewAccount = new Account
            {
                AccountNumber = AccNum,
                AccountType = type,
                CurrentBalance = 0,
                OpeningDate = DateOnly.FromDateTime(DateTime.Now),
                BranchId = BranchId
            };

            dbContext.Accounts.Add(NewAccount);
            dbContext.SaveChanges();

            var Link = new CustomerAccount()
            {
                CustomerId = CusId,
                OwnerShipStartDate = DateOnly.FromDateTime(DateTime.Now),
                OwnerShipType = ownerShipType,
                AccountStatus = AccountStatus.Active,
                AccountId = AccountId
            };
            dbContext.CustomerAccounts.Add(Link);
            dbContext.SaveChanges();

        }


        private static string Prompt (string Lable)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{Lable}: ");
            Console.ResetColor();
            return Console.ReadLine() ?? string.Empty;
        }


        private static void DisplaySuccess(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Message);
            Console.ResetColor();
        }

        private static void DisplayError(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Message);
            Console.ResetColor();

        }

    }
}
        
