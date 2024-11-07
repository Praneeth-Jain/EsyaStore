using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {

            HttpContext.Session.SetString("Login", "0");
            HttpContext.Session.SetString("Role", "User");
            HttpContext.Session.SetString("Id", "0");

            Console.WriteLine($"The value of the login is set to {HttpContext.Session.GetString("Login")}");

            return RedirectToPage("/EcomUI/Homepage");
        }
    }
}
