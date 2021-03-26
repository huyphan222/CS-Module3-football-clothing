using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Entities
{
    public class Cart
    {
        [Key,ForeignKey("User")]
        public int UserId { get; set; }
       

        public AppIdentityUser appIdentityUser { get; set; }
        ICollection<CartDetail> cartDetails { get; set; }
    }
}
