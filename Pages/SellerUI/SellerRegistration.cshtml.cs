using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using EsyaStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.SellerUI
{
    public class SellerRegistrationModel : PageModel
    {

        [BindProperty]
        public TsellerRegistration tempSellerRegister {  get; set; }

        public readonly ApplicationDbContext _context;

        public SellerRegistrationModel(ApplicationDbContext context)
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
            var seller = new Sellers
            {
                Name = tempSellerRegister.Name,
                Email = tempSellerRegister.Email,
                Password = tempSellerRegister.Password,
                Contact = tempSellerRegister.Contact,
                Location = tempSellerRegister.Location,
            };

            _context.sellers.Add(seller);
            _context.SaveChanges();

          

            return RedirectToPage("../EcomUI/Homepage");
        }
    }
}
