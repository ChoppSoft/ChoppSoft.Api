using ChoppSoft.Domain.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoppSoft.Repository.Mappings
{
    internal class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnType("integer");

            builder.Property(x => x.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(10,4)");

            builder.ToTable("Orders");
        }
    }
}
