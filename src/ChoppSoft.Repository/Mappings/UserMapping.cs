using ChoppSoft.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoppSoft.Repository.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Users");
        }
    }
}
