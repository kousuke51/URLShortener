using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Security
{
    public class ApplicationUser : IdentityUser
    {
        public List<UserRole> UserRoles { get; set; }

        public string Name { get; set; }
    }
}
