using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.Data.DAO;
using TestePratico.Services.Interfaces.DAO;
using TestePratico.Services.Interfaces.Services;
using TestePratico.Services.Services;

namespace TestePratico.Utils
{
    public static class Utilities
    {
        public static void DependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerDAO, OwnerDAO>();

            services.AddScoped<ICatService, CatService>();
            services.AddScoped<ICatDAO, CatDAO>();

            services.AddScoped<IDogService, DogService>();
            services.AddScoped<IDogDAO, DogDAO>();
        }
    }
}
