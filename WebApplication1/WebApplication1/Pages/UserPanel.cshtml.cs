using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;
using WebApplication1.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace WebApplication1.Pages
{
    [Authorize(Roles = "Admin,Vip,Standard")]
    public class UserPanelModel : PageModel
    {

        public byte[] profilePic { get; set; }
        public ApplicationUser user { get; set; }
        private readonly UserManager<ApplicationUser> _userManager;

        public UserPanelModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            user = await _userManager.GetUserAsync(User);
            HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user));
            
            //var sessionUser = JsonConvert.DeserializeObject<ApplicationUser>(HttpContext.Session.GetString("SessionUser"));
            profilePic = user.ProfilePic;
            return Page();
            
        }
    }
}
