
namespace Assignment.DAL.Data.Configurations
{
    public class EmployeeConfigurations : BaseEntityConfigurations<Employee>, IEntityTypeConfiguration<Employee>
    {
        //new => keyword to hide warning
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType(SqlServerTypes.NVarChar(50));
            builder.Property(e => e.Address).HasColumnType(SqlServerTypes.NVarChar(150));
            builder.Property(e => e.Salary).HasColumnType(SqlServerTypes.Decimal(10, 2));


            builder.Property(e => e.Gender).HasConversion(
                (EmployeeGender) => EmployeeGender.ToString(), 
                (gender) => (Gender)Enum.Parse(typeof(Gender),gender));

            builder.Property(e => e.EmployeeType).HasConversion(
                (EmployeeType) => EmployeeType.ToString(), 
                (type) => (EmployeeType)Enum.Parse(typeof(EmployeeType), type));


            base.Configure(builder);
        }
    }
}
