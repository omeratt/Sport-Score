using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class NewsService
    {
        #region Property
        public NewsContext _appDBContext;
        #endregion

        #region Constructor
        public NewsService(NewsContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        public NewsContext GetNewsContext()
        {
            return  _appDBContext;
        }

        #region Get List of News
        public async Task<List<News>> GetAllNewsAsync()
        {
            return await _appDBContext.News.ToListAsync();
        }
        #endregion

        #region Insert Employee
        public async Task<bool> InsertNewsAsync(News employee)
        {
            await _appDBContext.News.AddAsync(employee);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get News by Id
        public async Task<News> GetNewsAsync(int Id)
        {
            News news = await _appDBContext.News.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return news;
        }
        #endregion

        public async Task<News> Find(string txt)
        {
            News news = await _appDBContext.News.FirstOrDefaultAsync(c => c.text.Equals(txt));
            return news;
        }

        #region Update News
        public async Task<bool> UpdateNewsAsync(News news)
        {
            _appDBContext.News.Update(news);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region DeleteNews
        public async Task<bool> DeleteNewsAsync(News news)
        {
            _appDBContext.Remove(news);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
