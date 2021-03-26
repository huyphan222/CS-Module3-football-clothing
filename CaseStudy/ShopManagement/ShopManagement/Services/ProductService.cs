using Microsoft.EntityFrameworkCore;
using ShopManagement.AppDbContexts;
using ShopManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext context;

        public ProductService(AppDbContext context)
        {
            this.context = context;
         }


        public Product Add(Product product)
        {
            context.Add(product);
            context.SaveChanges();
            return product;
        }

        public Product Delete(int id)
        {
            Product product = context.products.Find(id);
            if (product != null)
            {
                context.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        public Product GetProduct(int id)
        {
            return context.products.Find(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.products;
        }

        public Product Update(Product productChange)
        {
            var product = context.products.Attach(productChange);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return productChange;
        }

     
    }
}
