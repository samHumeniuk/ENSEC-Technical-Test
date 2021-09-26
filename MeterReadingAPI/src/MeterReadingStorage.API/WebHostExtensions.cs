using MeterReadingStorage.DataAccessLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MeterReadingStorage.API
{
    public static class WebHostExtensions
    {
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetService<MeterReadingDbContext>();

                new MeterReadingDbSeeder(dbContext).SeedData();
                dbContext.Dispose();
            }

            return host;
        }
    }
}

