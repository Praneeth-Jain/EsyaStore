using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using EsyaStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.ProductUI
{
    public class AddProductModel : PageModel
    {
        [BindProperty]
        public TaddProduct tempAddProduct { get; set; }

        public readonly ApplicationDbContext _context;

        public AddProductModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            if(HttpContext.Session.GetString("Role") != "Seller")
            {
                return RedirectToPage("../SellerUI/SellerLogin");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }

            var newProduct = new Products
            {
              ProductName = tempAddProduct.ProductName,
              ProductDescription = tempAddProduct.ProductDescription,
              ProductCategory = tempAddProduct.ProductCategory,
              ProductPrice = tempAddProduct.ProductPrice,
              ProductQuantity = tempAddProduct.ProductQuantity, 
              Manufacturer = tempAddProduct.Manufacturer,
              
            };

            if (tempAddProduct.ProductImage != null && tempAddProduct.ProductImage.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                var fileName = Guid.NewGuid() + Path.GetExtension(tempAddProduct.ProductImage.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await tempAddProduct.ProductImage.CopyToAsync(stream);
                }

                newProduct.ProdImgUrl = $"/uploads/{fileName}";
            }

            _context.products.Add(newProduct);
            
            await _context.SaveChangesAsync();

            return RedirectToPage("../EcomUI/Homepage");
        }
    }
}
