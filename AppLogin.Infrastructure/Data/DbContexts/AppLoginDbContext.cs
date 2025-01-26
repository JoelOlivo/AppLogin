using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppLogin.Domain.Entities;
using AppLogin.Infrastructure.Data.Configurations;

namespace AppLogin.Infrastructure.Data.DbContexts
{
    public class AppLoginDbContext : DbContext
    {
        public AppLoginDbContext(DbContextOptions<AppLoginDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        }
    }
}
