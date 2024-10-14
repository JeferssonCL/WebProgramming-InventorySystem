using Backend.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Maps;

public class PaymentTransactionMap : IEntityTypeConfiguration<PaymentTransaction>
{
    public void Configure(EntityTypeBuilder<PaymentTransaction> builder)
    {
        builder.ToTable("PaymentTransaction");
        builder.HasIndex(pt => pt.Id);
        builder.Property(pt => pt.Id).ValueGeneratedOnAdd();
        builder.Property(pt => pt.Amount).IsRequired();

        builder.HasOne(pt => pt.Order)
            .WithOne(o => o.PaymentTransaction)
            .HasForeignKey<PaymentTransaction>(pt => pt.OrderId);
    }
}