using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapping_View.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mapping_View.Data.Configurations
{
    internal class StudentCourseConfigurations : IEntityTypeConfiguration<StudentCourse>
    {
        void IEntityTypeConfiguration<StudentCourse>.Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable("Stud_Course");

            builder.Property(sc => sc.StudentId)
                   .HasColumnName("stud_ID");

            builder.Property(sc => sc.CourseId)
                   .HasColumnName("Course_ID");


            #region (M - M) (Student - Course) Relationship

            builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

            #endregion
        }
    }
}
