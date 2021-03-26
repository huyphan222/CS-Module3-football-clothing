using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Models.ViewModels.CartItemViewModels
{
    public class CartProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string productPhoto { get; set; }
        public long uniPrice { get; set; }
    }
}
