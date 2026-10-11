using Bank_Management_System.Data;

namespace Bank_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (BankDbContext dbcontext = new ())
            {
                DatabaseSeeding.Seed(dbcontext);
            }


        }
    }
}
