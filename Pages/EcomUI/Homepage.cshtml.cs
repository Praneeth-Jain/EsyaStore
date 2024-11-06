using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.EcomUI
{
    public class HomepageModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.SetString("Login", "0");
            HttpContext.Session.SetString("Role", "user");
            HttpContext.Session.SetString("Id", "");
        }
    }
}
