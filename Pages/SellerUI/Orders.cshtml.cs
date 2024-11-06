using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.SellerUI
{
    public class OrdersModel : PageModel
    {
        public readonly ApplicationDbContext _context;

        public List<Order> listOfOrders { get; set; }
        public List<Users> listOfUsers { get; set; }

        public List<Products> listOfProducts { get; set; }    
        public OrdersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            listOfOrders = _context.orders.ToList();

            foreach (var o in listOfOrders)
            {
                listOfUsers = _context.users.Where(e=> e.Id == o.UserId).ToList();
                listOfProducts = _context.products.Where(e=> e.Id == o.ProductId).ToList();

            }


        }
    }
}
