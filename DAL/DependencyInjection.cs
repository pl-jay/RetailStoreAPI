using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailStoreAPI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DependencyInjection
    {
        public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RetailStoreDbContext>(options =>
                 options.UseSqlServer(
                     configuration.GetConnectionString("RetailStoreApiConnectionString"),
                     b => b.MigrationsAssembly(typeof(RetailStoreDbContext).Assembly.FullName)));

            services.AddScoped<IRetailStoreDbContext>(provider => provider.GetService<RetailStoreDbContext>());
        }
    }
}
