using Backend.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Maps;

public class VariantMap : IEntityTypeConfiguration<Variant>
{
    public void Configure(EntityTypeBuilder<Variant> builder)
    {
        builder.ToTable("Variant");
        builder.HasIndex(v => v.Id);
        builder.Property(v => v.Id).ValueGeneratedOnAdd();
        builder.Property(v => v.Name).IsRequired();

        builder.HasMany(v => v.ProductAttributes)
            .WithOne(pa => pa.Variant)
            .HasForeignKey(pa => pa.VariantId);
    }
}