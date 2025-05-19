using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.DiscountApplied)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.TotalItem)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.IsCancelled)
                .IsRequired();
        }
    }
}