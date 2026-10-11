using Bank_Management_System.Data;
using Bank_Management_System.Enums;
using Bank_Management_System.Models;
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

            string fullName = Promt("Enter First Name :    ");
            string NationalId = Promt("Enter National ID :   ");
            DateOnly dateOnly;
            while (DateOnly.TryParse(Promt("Enter Date of Birth (yyyy-MM-dd) :  "), out dateOnly) == false)
            {
                DisplayError("Invalid Date Format. Please enter in yyyy-MM-dd format.");
            }
            string phoneNumber = Promt("Enter Phone Number :   ");
            string email = Promt("Enter Email :    ");
            string address = Promt("Enter Address :  ");

            Console.WriteLine("Customer Type : \n      1) Individual \n        2) Business");

            CustomerType customerType = Promt("Enter Customer Type (1 or 2) :  ") switch
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


        private static string Promt (string Lable)
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
