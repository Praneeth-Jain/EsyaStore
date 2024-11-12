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
        public IActionResult OnPostOrder(int CartID,int Quantity,string Address)
        {
            var usrid = HttpContext.Session.GetInt32("Id");
            var BuyCartItems = _context.cart.Find(CartID);

            if (BuyCartItems==null)
            {
                return RedirectToPage("/Product/Index");
            }

            
                var BuyProduct = _context.products.Find(BuyCartItems.ProductId);
                if (BuyProduct == null||BuyProduct.ProductQuantity < Quantity) {
                TempData["AlertMessage"] = $"{Quantity} items are not in stock";
                    return RedirectToPage("/Product/Cart");
                }
                var newOrder = new Order
                {
                    OrderNo = Guid.NewGuid().ToString(),
                    UserId = BuyCartItems.UserId,
                    ProductId = BuyCartItems.ProductId,
                    Quantity=Quantity,
                    Address = Address
                };
                _context.orders.Add(newOrder);

                BuyProduct.ProductQuantity -= Quantity;
                _context.products.Update(BuyProduct);

                _context.cart.Remove(BuyCartItems);
            
            _context.SaveChanges();


            return RedirectToPage("/Product/Order");
        }
    }
}
