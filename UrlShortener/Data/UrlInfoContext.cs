using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Data
{
    //public class UrlInfoContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    public class UrlInfoContext : DbContext
    {
        
        public UrlInfoContext(DbContextOptions<UrlInfoContext> options) : base(options)
        {
        }

        public DbSet<UrlInfo> UrlInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //To avoid a table called "UrlInfos" from being created
            modelBuilder.Entity<UrlInfo>().ToTable("UrlInfo"); 
        }
    }
}
