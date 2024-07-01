using ChoppSoft.Domain.Models.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoppSoft.Repository.Mappings
{
    public class ResourceMapping : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Model)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.LicensePlate)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(x => x.Capacity)
                .IsRequired()
                .HasColumnType("decimal(10,4)");

            builder.ToTable("Resources");
        }
    }
}
