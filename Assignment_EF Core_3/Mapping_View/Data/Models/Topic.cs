using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping_View.Data.Models
{
    internal class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }


        #region (1 - M) (Topic- Course) Relationship
        public List<Course> Courses { get; set; }
        #endregion
    }
}
