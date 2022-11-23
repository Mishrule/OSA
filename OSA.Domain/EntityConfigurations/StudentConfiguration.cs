using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OSA.Domain.Entities;

namespace OSA.Domain.EntityConfigurations
{
    //public class StudentConfiguration : EntityTypeConfiguration<Student>
    //{
    //    public StudentConfiguration()
    //    {
    //        HasIndex(i => i.StudentNumber).IsUnique();
    //        HasKey(s => s.Id);

    //        HasRequired(s => s.Batch)
    //            .WithRequiredPrincipal(s => s.Student);

    //        HasMany(g => g.Guardians)
    //            .WithRequired(d => d.Student).HasForeignKey(f => f.Id);

    //    }
    //}

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
