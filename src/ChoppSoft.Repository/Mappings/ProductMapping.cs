using ChoppSoft.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoppSoft.Repository.Mappings
{
    internal class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Identifier)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Brand)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Capacity)
                .IsRequired()
                .HasColumnType("decimal(10,4)");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(10,4)");

            builder.ToTable("Products");
        }
    }
}
