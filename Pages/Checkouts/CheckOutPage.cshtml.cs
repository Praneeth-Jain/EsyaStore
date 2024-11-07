using EsyaStore.Data.Context;
using EsyaStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using EsyaStore.Data.Entity;

namespace EsyaStore.Pages.Checkouts
{
    public class CheckOutPageModel : PageModel
    {
        [BindProperty]
        public BillingAddress tempBillAddress {  get; set; }

        
        public Products itemproducts { get; set; }

        public readonly ApplicationDbContext _context;

        public CheckOutPageModel(ApplicationDbContext context)
        {
            _context = context;
        }   

        public void OnGet(int CheckoutproductId)
        {
            HttpContext.Session.SetString("CheckoutProductId", $"{CheckoutproductId}");
            itemproducts = _context.products.Find(CheckoutproductId);
        }

        public IActionResult OnPost()
        {

            Console.WriteLine(int.Parse(HttpContext.Session.GetString("Id")));
            Console.WriteLine(int.Parse(HttpContext.Session.GetString("CheckoutProductId")));

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(HttpContext.Session.GetString("Id") == null)
            {
                return RedirectToAction("../UserUI/UserLogin");
            }

            var newOrder = new Order
            {
                UserId = int.Parse(HttpContext.Session.GetString("Id")),
                ProductId = int.Parse(HttpContext.Session.GetString("CheckoutProductId")),
                OrderDate = DateTime.Now,
                Address = tempBillAddress.Address,
                City = tempBillAddress.City,
                State = tempBillAddress.State,
                ZIPCode = tempBillAddress.ZIPCode,

            };

            _context.orders.Add(newOrder);
            _context.SaveChanges();

            string baseUrl = Environment.GetEnvironmentVariable("BaseUrl") ?? "http://localhost:5047";
            return Redirect($"{baseUrl}/EcomUI/Homepage");


            
        }
    }
}
