using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Pages
{
    public class FavTeamModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser _context;
        //public DbSet<ApplicationUser> Users { get; set; }
        //public ApplicationUser user;
        public FavTeamModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

            //OnGetAsync();
        }

        public async void OnGetAsync()
        {
            //user = await _userManager.GetUserAsync(User);
            
        }
    }
}
