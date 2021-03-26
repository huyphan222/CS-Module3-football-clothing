using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Models.ViewModels.ProductViewModels
{
    public class EditProductViewModel:CreateProductViewModel
    {
        public int id { get; set; }
        public string existingPhotoPath { get; set; }
    }
}
