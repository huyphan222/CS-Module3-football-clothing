using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ShopManagement.AppDbContexts;
using ShopManagement.Models.ViewModels.CartItemViewModels;

namespace ShopManagement.Controllers
{
    
    public class CartController : Controller
    {
        private readonly AppDbContext context;
        public const string CARTKEY = "cart";
        public CartController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        List<CartItemViewModel> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItemViewModel>>(jsoncart);
            }
            return new List<CartItemViewModel>();
        }

        void SaveCartSession(List<CartItemViewModel> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }

        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        [Route("/cart", Name = "cart")]
        public IActionResult Cart()
        {
            return View(GetCartItems());
        }
        public IActionResult AddToCart(int productid)
        {
            var product = context.products
        .Where(p => p.ProductId == productid)
        .FirstOrDefault();
            if (product == null)
                return NotFound("Không có sản phẩm");
            // Xử lý đưa vào Cart ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.CartProduct.ProductId == productid);
            if (cartitem != null)
            {

                cartitem.Quantity++;
            }
            else
            {
                //  Thêm mới
                cart.Add(new CartItemViewModel()
                {
                    Quantity = 1,
                    CartProduct = new CartProductViewModel()
                    {
                        ProductId = product.ProductId,
                        ProductName = product.Name,
                        productPhoto = product.Photo,
                        uniPrice = product.Price
                    }
                });
            }

            SaveCartSession(cart);

            return RedirectToAction(nameof(Cart));
        }

        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart([FromForm] int productid, [FromForm] int quantity)
        {

            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.CartProduct.ProductId == productid);
            if (cartitem != null)
            {

                cartitem.Quantity = quantity;
            }
            SaveCartSession(cart);

            return Ok();
        }

        [Route("/removecart/{productid:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] int productid)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.CartProduct.ProductId == productid);
            if (cartitem != null)
            {

                cart.Remove(cartitem);
            }
            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }
    }
}