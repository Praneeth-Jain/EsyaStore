using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using EsyaStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.UserUI
{
    public class UserRegisterModel : PageModel
    {

        public readonly ApplicationDbContext _context;

        public UserRegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TuserRegistration tempUserRegistration { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost() {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = new Users { 
                Name = tempUserRegistration.Name,
                Email = tempUserRegistration.Email,
                Password = tempUserRegistration.Password,
                Contact = tempUserRegistration.Contect
            };


            _context.users.Add(user);
            _context.SaveChanges();

            return RedirectToPage("UserLogin");
        }
    }
}
