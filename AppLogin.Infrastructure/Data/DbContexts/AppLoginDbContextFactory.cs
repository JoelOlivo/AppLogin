using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AppLogin.Infrastructure.Data.DbContexts
{
    public class AppLoginDbContextFactory : IDesignTimeDbContextFactory<AppLoginDbContext>
    {
        public AppLoginDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppLoginDbContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(@"C:\Proyectos\AppLogin\AppLogin.WebApi")
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new AppLoginDbContext(optionsBuilder.Options);
        }

    }
}
