using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string Id { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Id = HttpContext.Session.GetString("Id");

            var admin = HttpContext.Session.GetString("UserRole");
            Console.WriteLine(admin);
            


        }
    }
}
