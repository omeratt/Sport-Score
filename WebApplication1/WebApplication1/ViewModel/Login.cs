using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModel
{
    public class Login
    {
        [Required]
        [DataType(DataType.Text)]
        public string EmailOrUserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }
    }
}
