using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
//using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Model;
//using static System.Net.Http.IHttpClientFactory
//using RestSharp;

namespace WebApplication1.Pages
{
    [Authorize(Roles = "Admin,Vip,Standard")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        public string news;

        public IndexModel(ILogger<IndexModel> logger, NewsContext _n, UserManager<ApplicationUser> userManager)
        {
            news = _n.News.ToList<News>()[0].text;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user));
            return Page();
        }
    }
}
