using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Core.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core.Data.Configurations
{
    internal class StudentCourseConfigurations : IEntityTypeConfiguration<StudentCourse>
    {
        void IEntityTypeConfiguration<StudentCourse>.Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable("Stud_Course");

            builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder.Property(sc => sc.StudentId)
                   .HasColumnName("stud_ID");

            builder.Property(sc => sc.CourseId)
                   .HasColumnName("Course_ID");
        }
    }
}
