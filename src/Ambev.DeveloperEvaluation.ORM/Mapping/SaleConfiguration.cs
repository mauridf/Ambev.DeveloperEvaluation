﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SaleNumber)
                .IsRequired();

            builder.Property(x => x.SaleDate)
                .IsRequired();

            builder.Property(x => x.CustomerId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.BranchId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.BranchName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasConversion<string>();

            builder.HasMany(x => x.Items)
                .WithOne()
                .HasForeignKey("SaleId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}