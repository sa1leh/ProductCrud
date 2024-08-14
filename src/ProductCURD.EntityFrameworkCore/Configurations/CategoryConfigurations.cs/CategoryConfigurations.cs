using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCURD.Categories;
using System;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ProductCURD.Configurations.CategoryConfigurations.cs
{
    internal class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ConfigureByConvention();

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(80);

            builder.ToTable("Categories");
        }
    }
}
