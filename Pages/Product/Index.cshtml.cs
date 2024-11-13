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


        public List<Products> ProductList { get; set; }=new List<Products>();

        [BindProperty(SupportsGet =true)]
        public string SearchQuery { get; set; }

        [BindProperty(SupportsGet =true)]

        public List<string> Categories { get; set; }= new List<string>();
        public string SelectedCategory { get; set; }

        public decimal AvgRating { get; set; }

        public IndexModel (ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Categories = _context.products
               .Select(p => p.ProductCategory)
               .Distinct()
               .ToList();

            SelectedCategory = Request.Query["SelectedCategory"];

            var FilteredProducts =_context.products.AsQueryable();
            if(SearchQuery != null)
            {
               FilteredProducts=FilteredProducts.Where(r=>r.ProductName.Contains(SearchQuery));
            }
            if (!string.IsNullOrEmpty(SelectedCategory))
            {
                FilteredProducts = FilteredProducts.Where(p => p.ProductCategory == SelectedCategory);
            }
            ProductList = FilteredProducts.ToList();
        }
    }
}
