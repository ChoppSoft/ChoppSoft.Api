using ChoppSoft.Domain.Models.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoppSoft.Repository.Mappings
{
    public class PaymentMapping : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount)
                .IsRequired()
                .HasColumnType("decimal(10,4)");

            builder.Property(x => x.Method)
                .IsRequired()
                .HasColumnType("integer");

            builder.ToTable("Payments");
        }
    }
}
