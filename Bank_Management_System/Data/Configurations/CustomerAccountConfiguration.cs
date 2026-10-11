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
    public class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
           builder.HasKey(Ca => new { Ca.CustomerId, Ca.AccountId }); // Composite primary key
           builder.Property(Ca => Ca.AccountStatus)
                   .HasConversion<string>();
           builder.Property(Ca => Ca.OwnerShipType)
                   .HasConversion<string>();
        }
    }
}
