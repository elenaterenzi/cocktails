using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace cocktails.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<cocktails.Models.Cocktail> cocktails {get; set;}
        public DbSet<cocktails.Models.Order> ordini {get; set;}

        public DbSet<cocktails.Models.OrderView> v_ordini {get; set;}
    }
}
