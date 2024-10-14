using Backend.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Maps;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        builder.HasIndex(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.StockQuantity).IsRequired();

        builder.HasOne(p => p.OrderItem)
            .WithOne(oi => oi.Product)
            .HasForeignKey<OrderItem>(oi => oi.ProductId);
        
        builder.HasMany(p => p.Images)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId);

        builder.HasMany(p => p.ProductAttributes)
            .WithOne(pa => pa.Product)
            .HasForeignKey(pa => pa.ProductId);

        builder.HasMany(p => p.Categories)
            .WithMany(c => c.Products);
    }
}