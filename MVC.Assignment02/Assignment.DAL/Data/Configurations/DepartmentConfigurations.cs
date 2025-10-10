namespace Assignment.DAL.Data.Configurations
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10,10);

            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
            builder.Property(d => d.Description).HasColumnType("varchar(200)");


            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GETDATE()");               //insertion time only
            builder.Property(d => d.LastModifiedOn).HasComputedColumnSql("GETDATE()");        //update time

        }
    }
}
