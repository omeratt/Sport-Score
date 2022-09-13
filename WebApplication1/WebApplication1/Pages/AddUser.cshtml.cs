using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;
using WebApplication1.ViewModel;

namespace WebApplication1.Pages
{
    [Authorize(Roles = "Admin")]
    public class AddUserModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHostingEnvironment _env;
        public List<string> RoleItems { get; set; }

        [BindProperty]
        public AddUser Model { get; set; }


        public AddUserModel(UserManager<ApplicationUser> userManager, IHostingEnvironment env)
        {
            this.userManager = userManager;
            this._env = env;
            RoleItems = new List<string> { "Standard", "Vip", "Admin" };
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                string path = _env.WebRootPath + "\\img\\default_pic.png";
                byte[] photo = System.IO.File.ReadAllBytes(path);

                var user = new ApplicationUser()
                {
                    UserName = Model.UserName,
                    Email = Model.Email,
                    ProfilePic = photo,
                };

                var result = await userManager.CreateAsync(user, Model.Password);
                if (result.Succeeded)
                {
                    if(Model.Role.Equals("Admin"))
                        await userManager.AddToRoleAsync(user, "Vip");

                    await userManager.AddToRoleAsync(user, Model.Role);
                    return RedirectToPage("AdminPanel");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return Page();
        }

    }

}
