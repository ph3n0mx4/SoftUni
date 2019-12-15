namespace P01_StudentSystem.Data.Configurations
{
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> student)
        {
            student.HasKey(s => s.StudentId);

            student
                .Property(s => s.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(100);

            student
                .Property(s => s.PhoneNumber)
                .IsRequired(false)
                .IsUnicode(false)
                .HasMaxLength(10)
                .IsFixedLength(true);

            student
                .Property(s => s.RegisteredOn)
                .IsRequired(true)
                .HasColumnType("SMALLDATETIME"); 

            student
                .Property(s => s.Birthday)
                .IsRequired(false)
                .HasColumnType("SMALLDATETIME");
        }
    }
}
