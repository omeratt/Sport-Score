using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model
{
    public class NewsContext : DbContext
    {
        public DbSet<News> News { get; set; }

        public NewsContext(DbContextOptions<NewsContext> options) : base(options)
        {

        }
        


    }
}
