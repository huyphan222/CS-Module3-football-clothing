using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.AppDbContexts
{
    public class AppDbContext : IdentityDbContext<AppIdentityUser,AppIdentityRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public  DbSet<Cart> carts { get; set; }
        public DbSet<CartDetail> cartDetails {get; set;}
        public DbSet<Category> categories { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<AppIdentityRole> appIdentityRoles { get; set; }
        public DbSet<AppIdentityUser> appIdentityUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                 new Category()
                 {
                     CategoryId = 1,
                     Name = "Premier League"
                 },
                 new Category()
                 {
                     CategoryId = 2,
                     Name = "SeriA"
                 }
                );



            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                  ProductId = 1,
                  Name = "Ao Chelsea 2020-2021",
                  CategoryId = 1,
                  OrigialPrice = 220000,
                  Photo = "~/images/AoChelsea2020.jpg",
                  Size = "M,L,XL",
                  
                  



                },
                new Product()
                {
                       ProductId = 2,
                       Name = "Ao Chelsea 2020-2021",
                       CategoryId = 1,
                       OrigialPrice = 220000,
                       Photo = "~/images/AoChelsea2020.jpg",
                       Size = "M,L,XL"

                },
                new Product()
                 {
                          ProductId = 3,
                          Name = "Ao Chelsea 2020-2021",
                          CategoryId = 1,
                          OrigialPrice = 220000,
                          Photo = "~/images/AoChelsea2020.jpg",
                          Size = "M,L,XL"
                 
                }
                );


        }











    }
}
