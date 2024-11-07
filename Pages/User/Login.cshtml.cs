using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EsyaStore.Model;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using EsyaStore.Data.Context;

namespace EsyaStore.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]

        public userloginModelClass user { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var getUsers = _context.users
                          .Where(x => x.Email == user.Email && x.Password == user.Password)
                          .FirstOrDefault();

            if (getUsers != null)
            {
                HttpContext.Session.SetString("UserRole", "User");
                HttpContext.Session.SetInt32("Id", getUsers.Id);
                

                return RedirectToPage("../Product/Index");
            }
            else { return Page(); } 
        }
    }
}
