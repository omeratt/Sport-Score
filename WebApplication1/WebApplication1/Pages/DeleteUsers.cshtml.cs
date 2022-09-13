using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Pages
{
    [Authorize(Roles = "Admin")]
    public class DeleteUsersModel : PageModel
    {
        private WebApplication1.Model.ApplicationDbContext _context;
        public DbSet<ApplicationUser> Users { get; set; }
        public string succ = "false";
        public DeleteUsersModel(WebApplication1.Model.ApplicationDbContext context)
        {
            _context = context;
            Users = _context.Users;
            //ViewData["succ"] = succ;
        }

        //[BindProperty]

        //public async Task<IActionResult> OnGetAsync()
        //{

            
            
            
        //    return Page();
        //}

        public async Task<IActionResult> OnPostAsync(string email)
        {
            
            if (email == null)
            {
                return NotFound();
            }

            ApplicationUser olduser = await Users.FirstOrDefaultAsync(u => u.Email.Equals(email));

            if (olduser != null)
            {
                //Users.Remove(olduser);
                _context.Remove(olduser);
                await _context.SaveChangesAsync();
                succ = "true";
                ViewData["succ"] = succ;
            }
            
            return Page();
        }
    }
}
