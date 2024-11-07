using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.Product
{
    public class ProductDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public int ProductDetailId { get; set; }

        public string UserRole { get; set; }

        [BindProperty]
        public Products Products { get; set; }
        public ProductDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            UserRole = HttpContext.Session.GetString("UserRole");
            Products=_context.products.Find(id);
        }
        public IActionResult OnPostAddCart() {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "User")
            {
                return RedirectToPage("/User/Login");
            }
            
            var cartUsrId = (int)HttpContext.Session.GetInt32("Id");
            if(ProductDetailId == 0)
            {
                return BadRequest("Product is not selected");
            }
            var newCart = new Cart
            {
                ProductId = ProductDetailId ,
                UserId=cartUsrId
            };
            _context.cart.Add(newCart);
            _context.SaveChanges();
            return RedirectToPage("/Product/Cart");

        }
    }
}
