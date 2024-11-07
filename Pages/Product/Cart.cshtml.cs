using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using EsyaStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.Product
{
    public class CartModel : PageModel
    {
    private readonly ApplicationDbContext _context;
        public List<CartViewModel> CartProducts { get; set; } = new List<CartViewModel>();
        public Cart DeleteCart { get; set; }

        public string UserRole { get; set; }

        public CartModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            UserRole = HttpContext.Session.GetString("UserRole");
            if (UserRole != "User") {
                Response.Redirect("/User/Login");
                return;
            }

            var usrId = HttpContext.Session.GetInt32("Id");

            {
                CartProducts = (from cart in _context.cart
                                join product in _context.products on cart.ProductId equals product.Id
                                where cart.UserId == usrId
                                select new CartViewModel
                                {
                                    Product = product,
                                    CartId = cart.CartId
                                }).ToList();
            }
            
        }
        public IActionResult OnPostDeleteFromCart(int? Cartid)
        {
            DeleteCart = _context.cart.Find(Cartid);
            _context.cart.Remove(DeleteCart);
            _context.SaveChanges();
            return RedirectToPage("/Product/Cart");
        }
        public IActionResult OnPostOrder()
        {
            var usrid = HttpContext.Session.GetInt32("Id");
            var BuyCartItems = _context.cart.Where(c => c.UserId == usrid).ToList();

            if (!BuyCartItems.Any())
            {
                return RedirectToPage("/Product/Index");
            }

            foreach (var item in BuyCartItems) {
                var BuyProduct = _context.products.Find(item.ProductId);
                if (BuyProduct == null||BuyProduct.ProductQuantity<1) {
                    continue;
                }
                var newOrder = new Order
                {
                    OrderNo = Guid.NewGuid().ToString(),
                    UserId = item.UserId,
                    ProductId = item.ProductId,
                };
                _context.orders.Add(newOrder);

                BuyProduct.ProductQuantity -= 1;
                _context.products.Update(BuyProduct);

                _context.cart.Remove(item);
            }
            _context.SaveChanges();


            return RedirectToPage("/Product/Order");
        }
    }
}
