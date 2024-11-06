using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.Product
{
    public class CartModel : PageModel
    {
    private readonly ApplicationDbContext _context;
        public List<dynamic> CartProducts { get; set; } = new List<dynamic>();
        public Cart DeleteCart { get; set; }


        public CartModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            CartProducts = (from cart in _context.cart
                            join product in _context.products on cart.ProductId equals product.Id
                            where cart.UserId == 2
                            select  new
                            {
                                Product = product,
                                CartId = cart.CartId
                            }).ToList<dynamic>();
        }
        public IActionResult OnPostDeleteFromCart(int? Cartid)
        {
            DeleteCart = _context.cart.Find(Cartid);
            _context.cart.Remove(DeleteCart);
            _context.SaveChanges();
            return RedirectToPage("/Product/Cart");
        }
        //public IActionResult OnPostOrder()
        //{
        //    var orderno = new Guid().ToString();

        //    return Page();
        //}
    }
}
