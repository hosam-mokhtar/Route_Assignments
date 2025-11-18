
namespace Assignment.DAL.Data.Configurations
{
    public class DepartmentConfigurations : BaseEntityConfigurations<Department>, IEntityTypeConfiguration<Department>
    {
        //new => keyword to hide warning
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);

            builder.Property(d => d.Name).HasColumnType(SqlServerTypes.NVarChar(20));
            builder.Property(d => d.Code).HasColumnType(SqlServerTypes.NVarChar(20));
            builder.Property(d => d.Description).HasColumnType(SqlServerTypes.NVarChar(200));


            builder.HasMany(d => d.Employees)
                 //.WithOne()                           By Convention
                   .WithOne(e => e.Department)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.SetNull);


            base.Configure(builder);
        }
    }
}
