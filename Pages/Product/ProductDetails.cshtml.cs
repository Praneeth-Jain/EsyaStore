using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.Product
{
    public class ProductDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public int ProductDetailId { get; set; }

        public string UserRole { get; set; }

        public bool HasPurchased { get; set; }

        public bool HasRevieved { get; set; }

        [BindProperty]
        public int StarsCount { get; set; }

        [BindProperty]
        public string ReviewDescription { get; set; }

        [BindProperty]
        public Reviews Review { get; set; } = new Reviews();
        public List<Reviews> ProductReviews { get; set; } = new List<Reviews>();

        [BindProperty]
        public Products Products { get; set; }
        public ProductDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
            UserRole = HttpContext.Session.GetString("UserRole");
            Products=_context.products.Find(id);

            var userId = HttpContext.Session.GetInt32("Id");
            if (userId.HasValue)
            {
                HasPurchased = _context.orders
                    .Any(order => order.UserId == userId && order.ProductId == id);
            }
            ProductReviews = _context.reviews
                .Where(review => review.ProductID == id)
                .OrderByDescending(review => review.ReviewDate)
                .ToList();

            HasRevieved = _context.reviews.Any(r => r.UserID == userId && r.ProductID == id);
            
            
        }
        public IActionResult OnPostAddCart() {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "User")
            {
                return RedirectToPage("/User/Login");
            }
            
            var cartUsrId = (int)HttpContext.Session.GetInt32("Id");
            if(ProductDetailId == 0)
            {
                return BadRequest("Product is not selected");
            }
            var newCart = new Cart
            {
                ProductId = ProductDetailId ,  
                UserId=cartUsrId
            };
            _context.cart.Add(newCart);
            _context.SaveChanges();
            return RedirectToPage("/Product/Cart");

        }
        public IActionResult OnPostReview()
        {
            var userId = HttpContext.Session.GetInt32("Id");
            if (userId == null || ProductDetailId == 0)
            {
                return BadRequest("User or product information is missing.");
            }



            Review.UserID = (int)userId;
            Review.ProductID = ProductDetailId;
            Review.ReviewDate = DateTime.Now;
            Review.Stars = StarsCount;
            Review.ReviewDescription = ReviewDescription;

            _context.reviews.Add(Review);
            _context.SaveChanges();

            return RedirectToPage(new { id = ProductDetailId });
        }
    }
}




  