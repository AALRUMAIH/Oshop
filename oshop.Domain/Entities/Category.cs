using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace oshop.Domain.Entities
{
    public class Category
    {
        [Key]
        public string category { get; set; }

    }
}
