using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using EsyaStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace EsyaStore.Pages.ProductUI
{
    public class ProductListModel : PageModel
    {

        [BindProperty]
        public string tempCategory { get; set; }

        [BindProperty]
        public List<Products> listOfProducts {  get; set; }
        public readonly ApplicationDbContext _context;

        [BindProperty]
        public string[] UniqueCategories { get; set; }
        public ProductListModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(string category)
        {

            // If a category is passed as a query parameter, filter the products by category
            if (!string.IsNullOrEmpty(category))
            {
                listOfProducts = _context.products
                    .Where(p => p.ProductCategory == category)
                    .ToList();
                 // Set the selected category to the property (for form binding)
            }
            else
            {
                // If no category is passed, show all products
                listOfProducts = _context.products.ToList();
            }

            // Get unique categories from the database
            UniqueCategories = _context.products
                .Select(p => p.ProductCategory)
                .Distinct()
                .ToArray();
            tempCategory = "";
        }

        public void OnPost() {

            RedirectToPage("ProductDetails");
        }

        public IActionResult OnPostProductCategory()
        {
            Console.WriteLine(tempCategory);
            // When a category is clicked, redirect to the same page with the selected category
            return RedirectToPage("ProductList", new { category = tempCategory });
        }

    }
}
