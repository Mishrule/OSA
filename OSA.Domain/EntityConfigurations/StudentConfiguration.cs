using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OSA.Domain.Entities;

namespace OSA.Domain.EntityConfigurations
{


    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasIndex(i => i.StudentNumber).IsUnique();
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Batch).WithOne(s => s.Student);

            builder.HasMany(g => g.Guardians)
                .WithOne(d=>d.Student)
                .HasForeignKey(f => f.Id);
        }
    }
}
