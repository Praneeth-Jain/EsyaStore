using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using EsyaStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.Seller
{
    public class EditProductModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;


        [BindProperty]
        public Products SelectedProduct { get; set; }

        public IFormFile NewImage { get; set; }

        public EditProductModel(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public void OnGet(int id)
        {
            var sellerId = HttpContext.Session.GetInt32("SellerId");
            var Role = HttpContext.Session.GetString("UserRole");
            if (Role != "Seller")
            {
                Response.Redirect("/Seller/SellerSignup");
                return;
            }
            var Product=_context.products.Find(id);
            if (Product.SellerId != sellerId)
            {
                Response.Redirect("/Seller/SellerSignup");
                return;
            }
            SelectedProduct = Product;
        }
        public IActionResult OnPostEditPage()
        {
            
            
            var EditedProduct=_context.products.Find(SelectedProduct.Id);
            if (EditedProduct != null)
            {
                if (NewImage != null) {
                    var filename = Guid.NewGuid().ToString() + Path.GetExtension(NewImage.FileName);
                    var filepath = Path.Combine(_env.WebRootPath, "uploads", filename);
                    var filestream = new FileStream(filepath, FileMode.Create);
                    NewImage.CopyToAsync(filestream);
                }
                
               
                EditedProduct.ProductName=SelectedProduct.ProductName;
                EditedProduct.ProductPrice = SelectedProduct.ProductPrice;
                EditedProduct.ProductQuantity = SelectedProduct.ProductQuantity;
                EditedProduct.ProductDescription = SelectedProduct.ProductDescription;
                EditedProduct.Manufacturer = SelectedProduct.Manufacturer;
                EditedProduct.ProductCategory = SelectedProduct.ProductCategory;
                _context.SaveChanges();
            }
            return RedirectToPage("/Seller/SellerHome");

        }
    }
}
