using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class ApplicationUser: IdentityUser
    {
        public byte[] ProfilePic { get; set; }
        public string FavTeam { get; set; }

    }
}
