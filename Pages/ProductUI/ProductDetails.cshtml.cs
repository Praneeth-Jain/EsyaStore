using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EsyaStore.Pages.ProductUI
{
    public class ProductDetailsModel : PageModel
    {
        public readonly ApplicationDbContext _context;
       
        public Products ProductDetails { get; set; }
        public List<Products> listOfProducts { get; set; }
        public ProductDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int productId)
        {
            Console.WriteLine($"The value of the login is {HttpContext.Session.GetString("Login")}");

            if (HttpContext.Session.GetString("Login") == "0")
            {
               return RedirectToPage("../UserUI/UserLogin");
            }

            Console.WriteLine(productId);
            ProductDetails = _context.products.Where(Users => Users.Id == productId).FirstOrDefault();

            listOfProducts = _context.products.ToList();
            
            return Page();
        }
    }
}
