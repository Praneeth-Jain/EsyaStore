using EsyaStore.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.Admin
{
    public class AdminHomeModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        
        public int Count { get; set; }

        public List<TopSellingProduct> TopProducts { get; set; }

        public List <ProductsCart> CartProds { get; set; }

        public AdminHomeModel(ApplicationDbContext context) {
            _context = context;
        }

        public void OnGet()
        {
            Count = _context.orders.Count();

             TopProducts = _context.orders
            .AsEnumerable() 
            .GroupBy(o => o.ProductId)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => new TopSellingProduct
            {
                ProductName = _context.products.FirstOrDefault(p => p.Id == g.Key)?.ProductName ?? "Unknown",
                SalesCount = g.Count()
            })
            .ToList();


            CartProds = _context.cart
                .AsEnumerable().GroupBy(o => o.ProductId)
                .OrderByDescending(g => g.Count())
                .Take(5).Select(
                g=> new ProductsCart
                {
                    ProductNAme=_context.products.FirstOrDefault(p => p.Id == g.Key)?.ProductName ?? "Unknown",
                    Count = g.Count()
                }
                ).ToList();

        }
    }
}
public class TopSellingProduct
{
    public string ProductName { get; set; }
    public int SalesCount { get; set; }
}

public class ProductsCart
{
    public string ProductNAme { get; set; }
    public int Count { get; set; }
}
