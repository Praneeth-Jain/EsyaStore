using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.Seller
{
    public class ReviewsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Reviews> reviews { get; set; } = new List<Reviews>();

        public ReviewsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            var UserRole = HttpContext.Session.GetString("UserRole");
            if (UserRole != "Seller")
            {
                Response.Redirect("/Seller/SellerSignup");
                return;
            }
            reviews = _context.reviews.Where(R => R.ProductID == id).ToList();

        }
    }
}