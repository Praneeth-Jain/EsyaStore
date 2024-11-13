using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using EsyaStore.Model;
using EsyaStore.Pages.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EsyaStore.Pages.Seller
{
    public class ReviewsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<ReviewViewModel> reviews { get; set; } = new List<ReviewViewModel>();

        public ReviewsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int id)
        {
        //    var UserRole = HttpContext.Session.GetString("UserRole");
        //    if (UserRole != "Seller")
        //    {
        //        Response.Redirect("/Seller/SellerSignup");
        //        return;
        //    }
            reviews = (from reviews in _context.reviews join user in _context.users on 
                       reviews.UserID equals user.Id where reviews.ProductID==id
                       select new ReviewViewModel
                       {
                           Username=user.Name,
                           UserEmail=user.Email,
                           Stars=reviews.Stars,
                           ReviewDescription=reviews.ReviewDescription,
                           ReviewDate=reviews.ReviewDate,
                       }
                       ).ToList();
            

        }
    }
}