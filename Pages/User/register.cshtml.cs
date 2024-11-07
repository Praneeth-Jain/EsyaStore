using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EsyaStore.Model;
using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;

namespace EsyaStore.Pages.User
{
    public class registerModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public registerModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]

        public userregisterModelClass reg {  get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var newuser = new Users
            {
                Name = reg.Name,
                Email = reg.Email,
                Password = reg.Password,
                Contact = reg.Contact,

            };
            _context.users.Add(newuser);
            _context.SaveChanges();
            return RedirectToPage("/User/Login");  
        }
    }
}
