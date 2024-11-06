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

        [BindProperty]
        public Products Products { get; set; }
        public ProductDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            
            Products=_context.products.Find(id);

        }
        public IActionResult OnPostAddCart() {
            if(ProductDetailId == 0)
            {
                return BadRequest("Product is not selected");
            }
            var newCart = new Cart
            {
                ProductId = ProductDetailId ,
                UserId=2
            };
            _context.cart.Add(newCart);
            _context.SaveChanges();
            return RedirectToPage("/Product/Cart");

        }
    }
}
