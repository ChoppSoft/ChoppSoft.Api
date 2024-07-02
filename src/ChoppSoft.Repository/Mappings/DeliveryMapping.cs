using ChoppSoft.Domain.Models.Deliveries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoppSoft.Repository.Mappings
{
    public class DeliveryMapping : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnType("integer");

            builder.ToTable("Deliveries");
        }
    }
}
