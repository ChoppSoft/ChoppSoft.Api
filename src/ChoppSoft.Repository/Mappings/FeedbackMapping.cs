using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ChoppSoft.Domain.Models.Feedbacks;

namespace ChoppSoft.Repository.Mappings
{
    public class FeedbackMapping : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Comments)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(x => x.Rating)
                .IsRequired()
                .HasColumnType("integer");

            builder.ToTable("FeedBacks");
        }
    }
}
