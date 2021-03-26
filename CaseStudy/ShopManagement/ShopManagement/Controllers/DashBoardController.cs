using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.AppDbContexts;
using ShopManagement.Entities;
using ShopManagement.Models.ViewModels.DashBoardViewModel;
using ShopManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashBoardController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly AppDbContext context;

        public DashBoardController(ICategoryService categoryService, IProductService productService, AppDbContext context)
        {
            this.categoryService = categoryService;
            this.productService = productService;
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var GetAllCategory = categoryService.GetAllCategory();
            return View(GetAllCategory);
        }

 

   
        [HttpGet]
        public IActionResult CreateCategory()
        {
            var GetAllCategories = categoryService.GetAllCategory();

            CreateCategoryViewModel createCategoryViewModel = new CreateCategoryViewModel()
            {
                Categories = GetAllCategories
            };

            return View(createCategoryViewModel);
        }

        
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                Category newCategory = new Category
                {
                  Name = model.Name
                };
                categoryService.Add(newCategory);
                return RedirectToAction("index");
            }
            var GetAllCategories = categoryService.GetAllCategory();

            CreateCategoryViewModel createCategoryViewModel = new CreateCategoryViewModel()
            {
                Categories = GetAllCategories
            };
            return View(createCategoryViewModel);
        }

       


    }
}
