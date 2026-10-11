using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
        {
           builder.Property(C => C.customerType)
                    .HasConversion<string>();  // This line configures the customerType property to be stored as a string in the database.
        
            builder.HasIndex(C => C.NationalId)
                                .IsUnique();  



            builder.HasMany(C => C.customerAccounts)
                .WithOne(C => C.customer)
                .HasForeignKey(C => C.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        
        
        }
    }
}
