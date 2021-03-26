
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
       
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product product { get; set; }
        [ForeignKey("Order")]
        public int OderId { get; set; }
        public Orders orders { get; set; }

    }
}
