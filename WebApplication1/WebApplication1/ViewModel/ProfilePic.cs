using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModel
{
    public class ProfilePic
    {
        [Display(Name = "Profile picture")]
        public byte[] ProfilePicture { get; set; }

    }
}
