using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P01_StudentSystem.Data.Models.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder
                .HasMany(c => c.Resources)
                .WithOne(r => r.Course)
                .HasForeignKey(r => r.CourseId);

            builder
                .HasMany(c => c.HomeworkSubmissions)
                .WithOne(hs => hs.Course)
                .HasForeignKey(hs => hs.CourseId);

            builder.Property(c => c.Name).HasMaxLength(80).IsUnicode().IsRequired();

            builder.Property(c => c.Description).IsUnicode();
        }
    }
}
