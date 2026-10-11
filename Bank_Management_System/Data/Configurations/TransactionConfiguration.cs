using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Transactions;

namespace Bank_Management_System.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Models.Transaction>
    {
        public void Configure(EntityTypeBuilder<Models.Transaction> builder)
        {
            builder.HasIndex(T => T.TransactionNumber)
                .IsUnique();

            builder.Property(T => T.transactionType)
                    .HasConversion<string>();
        }


    }

}
