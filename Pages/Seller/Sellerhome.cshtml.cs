using EsyaStore.Data.Context;
using EsyaStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EsyaStore.Pages.Seller
{
    public class SellerhomeModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SellerhomeModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Sellerorderviewmodel> orders {  get; set; }= new List<Sellerorderviewmodel>();
        public void OnGet()
        {

            var sellerId = HttpContext.Session.GetInt32("SellerID");
            orders = (from order in _context.orders
                          join products in _context.products on order.ProductId equals products.Id
                          where products.SellerId == sellerId
                          select new Sellerorderviewmodel
                          {
                              OrderId = order.Id,
                              OrderNo = order.OrderNo,
                              OrderDate = order.OrderDate,
                              OrderStatus = order.OrderStatus,
                              UserId = order.UserId,
                              ProductId = products.Id,
                              ProductName = products.ProductName,
                              ProductDescription = products.ProductDescription,
                              ProductPrice = products.ProductPrice,
                              ProductCategory = products.ProductCategory,
                              Manufacturer = products.Manufacturer,
                              ProdImgUrl = products.ProdImgUrl
                          }).ToList();
        }
    }
}
