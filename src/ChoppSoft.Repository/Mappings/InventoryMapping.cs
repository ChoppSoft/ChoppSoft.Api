using ChoppSoft.Domain.Models.Inventories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoppSoft.Repository.Mappings
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Quantity)
                   .IsRequired()
                   .HasColumnType("decimal(10,4)");

            builder.ToTable("Inventories");
        }
    }
}
