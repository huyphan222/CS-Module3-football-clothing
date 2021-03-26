using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Entities
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [MaxLength(20)]
        public string CreateOder { get; set; }
        [Required]
        [MaxLength(20)]
        public string ShippedDate { get; set; }
        [Required]
        public long Freight { get; set; }
        [Required]
        [MaxLength(200)]
        public string ShipAddress { get; set; }
        public ICollection<OrderDetail> orderDetails { get; set; }

        
        public int UserId { get; set; }
        [ForeignKey("User")]
        public AppIdentityUser user { get; set; }



    }
}
