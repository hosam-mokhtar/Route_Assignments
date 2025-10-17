
namespace Assignment.DAL.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }                     //User Id
        public DateTime CreatedOn { get; set; }                //Insertion Date
        public int LastModifiedBY { get; set; }                //User Id
        public DateTime LastModifiedOn { get; set; }           //Modified Date
        public bool IsDeleted { get; set; }                    //To Apply Soft Delete

    }
}
