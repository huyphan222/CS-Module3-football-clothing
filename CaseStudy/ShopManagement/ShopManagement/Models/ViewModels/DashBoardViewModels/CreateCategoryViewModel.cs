using ShopManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Models.ViewModels.DashBoardViewModel
{
    public class CreateCategoryViewModel
    {
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }
        public IEnumerable<Category> Categories { get; set; }             

    }
}
