using ChoppSoft.Domain.Models.Warehouses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoppSoft.Repository.Mappings
{
    public class WarehouseMapping : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Description)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(e => e.Location)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.HasMany(x => x.Products)
                   .WithOne(x => x.Warehouse)
                   .HasForeignKey(x => x.WarehouseId);

            builder.ToTable("Warehouses");
        }
    }
}
