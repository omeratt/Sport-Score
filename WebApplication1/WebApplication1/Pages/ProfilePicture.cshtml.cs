using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebApplication1.Model;
using WebApplication1.ViewModel;

namespace WebApplication1.Pages
{
    public class ProfilePictureModel : PageModel
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        [BindProperty]
        public ProfilePic Model { get; set; }
        public byte[] pic { get; set; }

        public ProfilePictureModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
        public async Task<IActionResult> OnGet()
        {
            //var sessionUser = JsonConvert.DeserializeObject<ApplicationUser>(HttpContext.Session.GetString("SessionUser"));
            var user = await userManager.GetUserAsync(User);            
            pic = user.ProfilePic;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(ProfilePic model)
        {


            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);

                if (user == null || (Request.Form.Files.Count <= 0))
                {
                    return Page();
                }

                var file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new System.IO.MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    user.ProfilePic = dataStream.ToArray();
                }

                user.FavTeam = "Maccabi Tel-Aviv";
                await userManager.UpdateAsync(user);
                pic = user.ProfilePic;
                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user));
                //await signInManager.RefreshSignInAsync(user);

                return Page();
            }

            return RedirectToPage("Index");

        }
    }
}
