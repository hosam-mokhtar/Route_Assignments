
namespace Assignment.DAL.Data.Configurations
{
    public class BaseEntityConfigurations<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GETDATE()");               //insertion time only
            builder.Property(d => d.LastModifiedOn).HasComputedColumnSql("GETDATE()");        //update time
        }
    }
}
