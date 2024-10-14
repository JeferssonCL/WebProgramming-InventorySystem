using Backend.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Maps;

public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItem");
        builder.HasIndex(oi => oi.Id);
        builder.Property(oi => oi.Id).ValueGeneratedOnAdd();
        builder.Property(oi => oi.Quantity).IsRequired();
        builder.Property(oi => oi.UnitPrice).IsRequired();
        builder.Property(oi => oi.DiscountPercent).IsRequired();
        builder.Property(oi => oi.TotalPrice).IsRequired();

        builder.HasOne(oi => oi.Product)
            .WithOne(p => p.OrderItem)
            .HasForeignKey<OrderItem>(oi => oi.ProductId);
    }
}