using System.ComponentModel.DataAnnotations;

namespace Talabat.models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
