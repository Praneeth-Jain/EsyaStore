using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages
{
    public class AdminLoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        
        public string ErrorMessage { get; set; }

        private const string AdminUsername = "admin";
        private const string AdminPassword = "admin";

        public void OnGet()
        {
            ErrorMessage = string.Empty;
        }

        public IActionResult OnPost()
        {
            if (Username == AdminUsername && Password == AdminPassword)
            {
                HttpContext.Session.SetString("UserRole", "Admin");
                HttpContext.Session.SetString("AdminUsername", AdminUsername);
                return RedirectToPage("/Admin/AdminHome"); 
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
        }
    }
}
