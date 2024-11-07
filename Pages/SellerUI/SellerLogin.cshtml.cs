using EsyaStore.Data.Context;
using EsyaStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.SellerUI
{
    public class SellerLoginModel : PageModel
    {
        [BindProperty]
        public TsellerLogin tempSellerLogin { get; set; }

        public readonly ApplicationDbContext _context;
        public SellerLoginModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _context.sellers.Where(x => x.Email == tempSellerLogin.Email && x.Password == tempSellerLogin.Password).FirstOrDefault();

            if (user == null)
            {
                return RedirectToPage("SellerLogin");
            }

            HttpContext.Session.SetString("Role", "Seller");
            HttpContext.Session.SetString("Login", "1");
            HttpContext.Session.SetString("Id", $"{user.Id}");

            return RedirectToPage("../EcomUI/Homepage");
        }
    }
}
