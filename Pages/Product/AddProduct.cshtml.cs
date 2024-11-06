using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using EsyaStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EsyaStore.Pages.Product
{
  public class AddProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        [BindProperty]
        public ProductModel Addproduct { get; set; }

        public AddProductModel(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostAddProduct() {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(Addproduct.ProductImg.FileName);
            var filepath = Path.Combine(_env.WebRootPath, "uploads", filename);
            var filestream = new FileStream(filepath, FileMode.Create);
            Addproduct.ProductImg.CopyToAsync(filestream);
            var newProd = new Products
            {
                ProductName = Addproduct.ProductName,
                ProductDescription = Addproduct.ProductDescription,
                ProductCategory = Addproduct.ProductCategory,
                ProductPrice = Addproduct.ProductPrice,
                ProductQuantity = Addproduct.ProductQuantity,
                Manufacturer=Addproduct.Manufacturer,
                ProdImgUrl = filename
            };
            _context.products.Add(newProd);
            _context.SaveChanges();
            TempData["ProductsMsg"] = "Product Added Successfully";
            return RedirectToPage("/Product/Index");
        }
    }
}