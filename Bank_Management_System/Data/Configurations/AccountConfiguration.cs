using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {

            builder.HasIndex(A => A.AccountNumber)
                   .IsUnique();

            builder.Property(A => A.AccountType)
                   .HasConversion<string>();

            builder.HasMany(C => C.customerAccounts)
                   .WithOne(C => C.account)
                   .HasForeignKey(C => C.AccountId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
