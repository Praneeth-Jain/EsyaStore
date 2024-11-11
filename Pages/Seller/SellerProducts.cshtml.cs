using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using EsyaStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.Seller
{
    public class SellerProductsModel : PageModel
    {
        private readonly ApplicationDbContext _context ;

        public List<Products> Products  { get; set; } = new List<Products>();

        public SellerProductsModel(ApplicationDbContext context)
        {
              _context = context;
        }

        public void OnGet()
        {
            var sellerId = HttpContext.Session.GetInt32("SellerId");
            var Role = HttpContext.Session.GetString("UserRole");
            if (Role != "Seller")
            {
                Response.Redirect("/Seller/SellerSignup");
                return;
            }
            Products = _context.products.Where(p => p.SellerId == sellerId).ToList();
        }
    }
}
