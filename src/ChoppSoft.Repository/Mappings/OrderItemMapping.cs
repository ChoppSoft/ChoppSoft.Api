using ChoppSoft.Domain.Models.Orders.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoppSoft.Repository.Mappings
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity)
                .IsRequired()
                .HasColumnType("decimal(10,4)");

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(10,4)");

            builder.Property(x => x.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(10,4)");

            builder.ToTable("OrderItems");
        }
    }
}
