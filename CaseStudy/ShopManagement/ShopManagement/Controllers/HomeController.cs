using EmployeePage.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopManagement.Entities;
using ShopManagement.Models;
using ShopManagement.Services;
using ShopManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Controllers
{


    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly IWebHostEnvironment hostingEnviroment;
        private readonly ICategoryService categoryService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IWebHostEnvironment hostingEnviroment , ICategoryService categoryService)
        {
            _logger = logger;
            this.productService = productService;
            this.hostingEnviroment = hostingEnviroment;
            this.categoryService = categoryService;
        }

       

        public IActionResult Index(int currenPage, int pageSize)
        {
            var Products = productService.GetAllProducts();
            var Categories = categoryService.GetAllCategory();
           


            if (currenPage == 0)
            {
                currenPage = 1;
            }
            if (pageSize == 0)
            {
                pageSize = 6;
            }
            var pager = new Pager(Products.Count(), currenPage, pageSize);

            var pagination = new Pagination<IndexViewModel>()
            {
                ListItems = Products.Skip((currenPage - 1) * pageSize).Take(pageSize),
                CategoriesList =  Categories,
                Pager = pager              
            };
            return View(pagination);
        }

        public IActionResult Detail(int? id)
        {
            Product product = productService.GetProduct(id.Value);

            if (product == null)
            {
                return View("Error", id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel
            {
                GetProduct = product
            };

            return View(homeDetailsViewModel);

        }


        public IActionResult Category(int? id, int currenPage, int pageSize)
        {
            var Products = productService.GetAllProducts();
            var Categories = categoryService.GetAllCategory();

            List<Product> productsNeed = new List<Product>();
            foreach (var item in Products)
            {
                if (item.CategoryId == id)
                {
                    productsNeed.Add(item);
                }
            }

            if (currenPage == 0)
            {
                currenPage = 1;
            }
            if (pageSize == 0)
            {
                pageSize = 6;
            }
            var pager = new Pager(productsNeed.Count(), currenPage, pageSize);

            var pagination = new Pagination<IndexViewModel>()
            {
                ListItems = productsNeed.Skip((currenPage - 1) * pageSize).Take(pageSize),
                CategoriesList = Categories,
                Pager = pager
            };
            return View(pagination);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
