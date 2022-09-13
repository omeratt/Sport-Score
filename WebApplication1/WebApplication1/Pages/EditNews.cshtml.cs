using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.ViewModel;
namespace WebApplication1.Pages
{
    [Authorize(Roles = "Admin")]
    public class EditNewsModel : PageModel
    {
        public NewsContext News { get; set; } = null;
        public string current = null;
        public List<News> list;

        public EditNewsModel(NewsContext _News)
        {
            
            News = _News;
            
            list = News.News.ToList();
            if(list.Count > 0)
                current = list[0].text;
            else
            {
                News.Add(new News() { text = "" });
                current = "";
                News.SaveChangesAsync();
            }
        }

        //public IActionResult OnPost()
        //{
        //    News NewOne = new News() { Id = 1,text = Model.text };
        //    News oldOne = News.News.Find(1);
        //    News.News.Remove(oldOne);
        //    News.News.Add(NewOne);
        //    News.SaveChanges();
        //    News.Entry(NewOne).Reload();
        //    return Page();
        //}
        public void OnGet()
        {
            
        }
    }
}
