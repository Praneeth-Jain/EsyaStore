using EsyaStore.Data.Context;
using EsyaStore.Pages.Shared.SignupModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EsyaStore.Pages
{
    public class SellerSignupModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SellerSignupModel(ApplicationDbContext context)
        {
            _context = context;
        }


        [BindProperty]
        public SignupModelClass seller { get; set; }
        public string ErrorMessage { get; set; }
        public void OnGet()
        {
            Console.WriteLine(TempData["Message"]);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var getSellers = _context.sellers
                          .Where(x => x.Email == seller.Username && x.Password == seller.Password)
                          .FirstOrDefault();

            if (getSellers != null)
            {
                HttpContext.Session.SetString("UserRole", "Seller");
                HttpContext.Session.SetInt32("SellerId", getSellers.Id);
                TempData["Message"] = "Login Success";
                TempData["link"] = "/Index";
              
                return RedirectToPage("/Seller/SellerHome");
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
        }
    }
}
