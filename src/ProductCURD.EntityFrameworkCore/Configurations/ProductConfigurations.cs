using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCURD.Products;
using System;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ProductCURD.Configurations
{
    internal class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ConfigureByConvention();

            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ProcudtPrice).HasPrecision(18, 2).IsRequired();
            builder.Property(x => x.ProductDescription).HasMaxLength(1000);

            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();

            builder.ToTable("Product");

        }
    }
}
