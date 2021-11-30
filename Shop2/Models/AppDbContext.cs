using Microsoft.EntityFrameworkCore;
using Shop2.Models.Users;
using Shop2.Models.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop2.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get;set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Category> Categories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
