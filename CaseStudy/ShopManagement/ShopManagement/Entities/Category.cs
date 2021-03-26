using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
