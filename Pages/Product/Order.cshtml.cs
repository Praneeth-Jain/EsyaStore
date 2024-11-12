using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using EsyaStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EsyaStore.Pages.Product
{
    public class OrderModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<OrderViewModel> userOrders { get; set; }=new List<OrderViewModel>();

        public string UserRole { get; set; }
        public OrderModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            UserRole = HttpContext.Session.GetString("UserRole");
            if (UserRole != "User")
            {
                RedirectToPage("User/Login");
            }
            var userid = HttpContext.Session.GetInt32("Id");
            userOrders = (from order in _context.orders
                          join product in _context.products on order.ProductId equals product.Id
                          where order.UserId == userid
                          select new OrderViewModel
                          {
                              OrderId = order.Id,
                              OrderNo=order.OrderNo,
                              ProductName = product.ProductName,
                              ProductImage = product.ProdImgUrl, 
                              OrderDate = order.OrderDate,
                              OrderStatus = order.OrderStatus,
                              Quanity=order.Quantity,
                              Address=order.Address
                          }).ToList();

        }
        public IActionResult OnPostCancelOrder(int orderId)
        {
            var order = _context.orders.Find(orderId);
            if (order != null)
            {
                var product = _context.products.Find(order.ProductId);
                if (product != null)
                {
                    product.ProductQuantity += 1;
                    _context.products.Update(product);
                }
                order.OrderStatus = 0;
                _context.orders.Update(order);
                _context.SaveChanges();
            }
            return RedirectToPage();
        } 
    }
}
