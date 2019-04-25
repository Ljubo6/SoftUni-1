using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P01_StudentSystem.Data.Models.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder
                .HasMany(s => s.HomeworkSubmissions)
                .WithOne(hm => hm.Student)
                .HasForeignKey(hm => hm.StudentId);

            builder.Property(s => s.Name).HasMaxLength(100).IsUnicode().IsRequired();

            builder.Property(s => s.PhoneNumber).HasColumnType("CHAR(10)");
        }
    }
}
