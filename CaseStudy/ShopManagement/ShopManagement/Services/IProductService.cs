using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopManagement.Entities;


namespace ShopManagement.Services
{
    public interface IProductService
    {
        public Product GetProduct(int id);     
        public  IEnumerable<Product> GetAllProducts();
        public Product Add(Product product);
        public  Product Update(Product productChange);
        public  Product Delete(int id);

        

    }
}
