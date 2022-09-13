using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModel
{
    public class ChangeEmail
    {
        
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

                
        [DataType(DataType.EmailAddress)]
        [Display(Name = "New Email")]
        public string NewEmail { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm Email")]
        [Compare("NewEmail", ErrorMessage = "The new Email and confirmation Email don't match.")]
        public string ConfirmEmail { get; set; }
    }
}
