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
    internal class CourseInstructorConfigurations : IEntityTypeConfiguration<CourseInstructor>
    {
        void IEntityTypeConfiguration<CourseInstructor>.Configure(EntityTypeBuilder<CourseInstructor> builder)
        {
            builder.ToTable("Course_Inst");

            builder.HasKey(ci => new { ci.InstructorId, ci.CourseId });

            builder.Property(ci => ci.InstructorId)
                   .HasColumnName("inst_ID");

            builder.Property(ci => ci.CourseId)
                   .HasColumnName("Course_ID");

            builder.Property(ci => ci.Evaluate)
                   .HasColumnType(SqlServerTypes.NVarChar(200));


            #region (M - M) (Instructor - Course) Relationship

            builder.HasKey(ci => new { ci.InstructorId, ci.CourseId });

            #endregion
        }
    }
}
