using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.AppDbContexts;
using ShopManagement.Entities;
using ShopManagement.Models.ViewModels.DashBoardViewModel;
using ShopManagement.Models.ViewModels.ProductViewModels;
using ShopManagement.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Controllers
{
    [Authorize(Roles  = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment hostingEnviroment;

        public ProductController(IProductService productService, AppDbContext context, IWebHostEnvironment hostingEnviroment)
        {
            this.productService = productService;
            this.context = context;
            this.hostingEnviroment = hostingEnviroment;
        }

        [HttpGet]
        public IActionResult AllProducts()
        {
            var GetAllProduct = productService.GetAllProducts();
            return View(GetAllProduct);
        }

        public IActionResult DetailProduct(int? id)
        {
            Product product = productService.GetProduct(id.Value);

            if (product == null)
            {
                return View("Product Not Found", id.Value);
            }

            ProductDetailViewModel dashBoardDetailViewModel = new ProductDetailViewModel()
            {
                Product = product
            };
            return View(dashBoardDetailViewModel);

        }

        public IActionResult DetailProductByCategory(int? id)
        {
            List<Product> productsNeed = new List<Product>();

            var getProducts = productService.GetAllProducts();
            foreach (var item in getProducts)
            {
                if(item.CategoryId == id)
                {
                    productsNeed.Add(item);
                }                  
            }
            return View(productsNeed);          
        }





        private string ProcessUploadedFileCreate(CreateProductViewModel model)
        {
            string uniqueFilename = null;
            if (model.PhotoPath != null)
            {
                string uploadsFolder = Path.Combine(hostingEnviroment.WebRootPath, "images");
                uniqueFilename = Guid.NewGuid().ToString() + "_" + model.PhotoPath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFilename);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    model.PhotoPath.CopyTo(filestream);
                }
            }
            return uniqueFilename;
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFilename = ProcessUploadedFileCreate(model);
                Product product = new Product
                {                                      
                    Name = model.Name,
                    OrigialPrice = model.OrigialPrice,
                    Description = model.Description,
                    Discount = model.Discount,
                    Size = model.Size,
                    CategoryId = model.CategoryId,
                    Photo = uniqueFilename
                };
                productService.Add(product);
                return RedirectToAction("AllProducts","Product");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var getProduct = productService.GetProduct(id);
            EditProductViewModel editProductViewModel = new EditProductViewModel
            {
                Name = getProduct.Name,
                OrigialPrice = getProduct.OrigialPrice,
                Size = getProduct.Size,
                Description = getProduct.Description,
                Discount = getProduct.Discount,
                CategoryId = getProduct.CategoryId,
                existingPhotoPath = getProduct.Photo
            };
            return View(editProductViewModel);
        }



        [HttpPost]
        public IActionResult EditProduct(EditProductViewModel model)
        {

            if (ModelState.IsValid)
            {
                Product getProduct = productService.GetProduct(model.id);
                getProduct.Name = model.Name;
                getProduct.OrigialPrice = model.OrigialPrice;
                getProduct.Size = model.Size;
                getProduct.Description = model.Description;
                getProduct.Discount = model.Discount;
                getProduct.CategoryId = model.CategoryId;
                               
                if (model.PhotoPath != null)
                {
                    if (model.existingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnviroment.WebRootPath, "images", model.existingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    getProduct.Photo = ProcessUploadedFileEdit(model);

                }


                productService.Update(getProduct);
                return RedirectToAction("DetailProduct", "Product", new { id = model.id }); ;
            }
            return View();

            string ProcessUploadedFileEdit(EditProductViewModel model)
            {
                string uniqueFilename = null;
                if (model.PhotoPath != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnviroment.WebRootPath, "images");
                    uniqueFilename = Guid.NewGuid().ToString() + "_" + model.PhotoPath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFilename);

                    using (var filestream = new FileStream(filePath, FileMode.Create))
                    {
                        model.PhotoPath.CopyTo(filestream);
                    }
                }

                return uniqueFilename;
            }
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            Product product = productService.GetProduct(id);

            if (product == null)
            {
                return View("Product Not Found", id);
            }

            productService.Delete(product.ProductId);
            return RedirectToAction("AllProducts");
                    
        }



    }
}
