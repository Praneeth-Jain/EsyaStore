using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EsyaStore.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public int id { get; set; }
        public List<Products> ProductList { get; set; }

        public decimal AvgRating { get; set; }

        public IndexModel (ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            ProductList = _context.products.ToList();
        }
    }
}
