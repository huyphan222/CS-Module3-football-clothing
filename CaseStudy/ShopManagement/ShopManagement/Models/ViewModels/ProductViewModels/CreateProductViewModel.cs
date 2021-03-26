using Microsoft.AspNetCore.Http;
using ShopManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Models.ViewModels.ProductViewModels
{
    public class CreateProductViewModel
    {
     
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }   
        [Required]
        public string Size { get; set; }
        [Required(ErrorMessage ="You have to choose Category")]
        [Display(Name = "Tournaments")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Enter Price")]
        [Display(Name = "Price")]
        public long OrigialPrice { get; set; }
        [Range(0, 1)]
        public int Discount { get; set; }
        public long Price => OrigialPrice * (1 - Discount);
        [Display(Name ="Photo")]
        public IFormFile PhotoPath { get; set; }




    }
}
