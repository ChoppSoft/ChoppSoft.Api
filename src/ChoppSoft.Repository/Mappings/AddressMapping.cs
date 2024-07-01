using ChoppSoft.Domain.Models.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoppSoft.Repository.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Street)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            builder.Property(e => e.Number)
                   .IsRequired()
                   .HasColumnType("varchar(10)");

            builder.Property(e => e.AdditionalInformation)
                   .IsRequired()
                   .HasColumnType("varchar(20)");

            builder.Property(e => e.District)
                   .IsRequired()
                   .HasColumnType("varchar(50)");

            builder.Property(e => e.City)
                   .IsRequired()
                   .HasColumnType("varchar(50)");

            builder.Property(e => e.State)
                   .IsRequired()
                   .HasColumnType("varchar(50)");

            builder.Property(e => e.PostalCode)
                   .IsRequired()
                   .HasColumnType("varchar(20)");

            builder.Property(e => e.Country)
                   .IsRequired()
                   .HasColumnType("varchar(50)");

            builder.ToTable("Addresses");
        }
    }
}
