using Backend.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Maps;

public class ProductAttributeMap : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.ToTable("ProductAttribute");
        builder.HasIndex(pa => pa.Id);
        builder.Property(pa => pa.Id).ValueGeneratedOnAdd();
        builder.Property(pa => pa.Value).IsRequired();

        builder.HasOne(pa => pa.Product)
            .WithMany(p => p.ProductAttributes)
            .HasForeignKey(pa => pa.ProductId);
        
        builder.HasOne(pa => pa.Variant)
            .WithOne(v => v.ProductAttribute)
            .HasForeignKey<ProductAttribute>(pa => pa.VariantId);
    }
}