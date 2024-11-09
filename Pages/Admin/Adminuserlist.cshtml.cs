using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EsyaStore.Data.Entity;
using EsyaStore.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace EsyaStore.Pages.Admin
{
    public class AdminuserlistModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AdminuserlistModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Users> UsersList { get; set; }

        public void OnGet()
        {
            // Retrieve the list of users from the database
            UsersList = _context.users.ToList();
        }

        // Synchronous handler method to toggle the user status (enable/disable)
        public IActionResult OnGetStatus(int? id, int? status)
        {
            var user = _context.users.Find(id);
            if (user != null)
            {
                if (status == 0)
                {
                    user.isActiveUser = 1;
                }
                else
                {
                    user.isActiveUser = 0;
                }
                _context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
