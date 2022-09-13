using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUser user;
        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        //public async Task<ApplicationUser> getCurrentUser()
        //{
        //    user = await _userManager.GetUserAsync(User);


        //}

    }
}
