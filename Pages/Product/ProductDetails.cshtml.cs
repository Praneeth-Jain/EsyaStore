using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.Product
{
    public class ProductDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Products Products { get; set; }
        public ProductDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            Products=_context.products.Find(id);
        }
    }
}
