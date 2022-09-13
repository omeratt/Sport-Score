using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public string text { get; set; }
    }
}
