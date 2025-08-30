using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UA.Application.Interfaces;
using UA.Domain.Entities;
using UA.Infrastructure.Repository;

namespace UA.Infrastructure.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            string? ConnectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<Data.ApplicationDbContext>(options =>
            {
                options.UseSqlite(ConnectionString);
            });
            services.AddScoped(typeof(IRepository<User>), typeof(UserRepository));
            return services;
        }
    }
}
