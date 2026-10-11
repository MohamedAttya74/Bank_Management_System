using Bank_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Management_System.Data.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasIndex(B => B.MangerId).IsUnique();
            builder.HasIndex(B => B.Code).IsUnique();
            builder.HasOne(b => b.Manger)
                   .WithOne(m => m.Branch)
                   .HasForeignKey<Branch>(b => b.MangerId)
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
