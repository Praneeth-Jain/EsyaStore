using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EsyaStore.Model;
using System.Reflection.Metadata.Ecma335;

namespace EsyaStore.Pages
{
    public class LoginModel : PageModel
    {
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

        return RedirectToPage("/Product");
        }
    }
}
