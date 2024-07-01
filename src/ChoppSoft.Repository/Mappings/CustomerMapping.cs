using ChoppSoft.Domain.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoppSoft.Repository.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Document)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasMany(x => x.Addresses)
                   .WithOne(x => x.Customer)
                   .HasForeignKey(x => x.CustomerId);

            builder.ToTable("Customers");
        }
    }
}
