using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EsyaStore.Pages.Admin
{
    public class AdminsellerlistModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminsellerlistModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Sellers> SellersList { get; set; }

        public void OnGet()
        {
            SellersList = _context.sellers.ToList();

        }

        public IActionResult OnGetStatus(int? id, int? status)
        {
            var seller = _context.sellers.Find(id);
            if (seller != null)
            {
                if (status == 0)
                {
                    seller.isActiveSeller = 1;
                }
                else
                {
                    seller.isActiveSeller = 0;
                }
                _context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}





