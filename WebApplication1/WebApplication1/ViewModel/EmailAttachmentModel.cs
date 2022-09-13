//using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModel
{
    public class EmailAttachmentModel
    {
            
            public string To { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Subject")]
            public string Subject { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Body")]
            public string Body { get; set; }
            

            [Display(Name = "Attachment")]
            public Microsoft.AspNetCore.Http.IFormFile Attachment { get; set; }
            public string From { get; set; }
        
    }
}
