using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using EsyaStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.UserUI
{
    public class UserLoginModel : PageModel
    {
        public readonly ApplicationDbContext _context;
        [BindProperty]
        public TuserLogin tempUserLogin {  get; set; }

        public UserLoginModel(ApplicationDbContext context)
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
            
            var user = _context.users.Where(x => x.Email == tempUserLogin.Email && x.Password == tempUserLogin.Password).FirstOrDefault();

            if (user == null) {
                return RedirectToPage("UserLogin");
            }

            return RedirectToPage("../EcomUI/Homepage");
        }
    }
}
