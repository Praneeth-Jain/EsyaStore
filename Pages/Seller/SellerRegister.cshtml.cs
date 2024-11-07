using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using EsyaStore.Pages.Shared.RegisterModelClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace EsyaStore.Pages
{
    public class SellerRegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;


        public SellerRegisterModel(ApplicationDbContext context )
        {
            _context = context;
        }



        [BindProperty]
        public RegisterModelClass RegistredSeller { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
        

            {
                return Page();

            }
            

            var newsell = new Sellers
            {
               Name = RegistredSeller.Name,
               Email = RegistredSeller.Email,
               Password = RegistredSeller.Password,
               Contact = RegistredSeller.Contact,
               Location = RegistredSeller.Location,
               
            };
            _context.sellers.Add(newsell);
            _context.SaveChanges();
            
            return RedirectToPage("/Seller/SellerSignup");
        }
        public void OnGet()
        {
        }
    }
}
