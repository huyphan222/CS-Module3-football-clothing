using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Models.ViewModels.CartItemViewModels
{
    public class CartItemViewModel
    {
        public int Quantity { get; set; }
        public CartProductViewModel CartProduct { get; set; }
    }
}
