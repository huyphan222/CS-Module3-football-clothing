using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Entities
{
    public class Product
    {
        [Key]       
        public int ProductId { get; set; }
        [Required]
        [MaxLength(200)]          
        public string Name { get; set; }      
        [MaxLength(1000)]
        public string Description { get; set; }
        public string Photo { get; set; }
        [Required]
        public string Size { get; set; }
        [ForeignKey("CategoryID")]
        public int CategoryId { get; set; }
        public Category category { get; set; }
         public ICollection<OrderDetail> orderDetails { get; set; }

        public long OrigialPrice { get; set; }
        [Range(0,1)]
        public int Discount { get; set; }
        public long Price => OrigialPrice * (1 - Discount);



    }
}
