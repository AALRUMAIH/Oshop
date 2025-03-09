using System.ComponentModel.DataAnnotations;

namespace oshop.Domain.Entities // Ensure this is correct
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } // Make sure these properties are exactly as shown

        [Required]
        public double Price { get; set; }

        [Required]
        public String Category { get; set; }

        [Url]
        public string Image { get; set; }

    }
}
