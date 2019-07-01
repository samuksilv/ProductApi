using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.api.Infrastructure.Data;
using Product.api.Infrastructure.Data.Connections;
using Product.api.Infrastructure.Data.Contexts;

namespace Product.api.Infrastructure.DI {
    public static class DISetup {
        public static void ConfigureMongoDb (this IServiceCollection services, IConfiguration configuration) {

            string productConnectionString = configuration.GetSection ("DatabaseProduct:ConnectionString").Value;
            bool productIsSsl = Convert.ToBoolean (configuration.GetSection ("DatabaseProduct:IsSsl").Value);
            string userConnectionString = configuration.GetSection ("DatabaseUser:ConnectionString").Value;
            bool userIsSsl = Convert.ToBoolean (configuration.GetSection ("DatabaseUser:IsSsl").Value);

            services.AddScoped<ProductDatabase> (ctx => new ProductDatabase (productConnectionString, productIsSsl));


            services.AddScoped<UserDatabase> (ctx => new UserDatabase (userConnectionString, userIsSsl));

            services.AddScoped<ProductContext> ();
            services.AddScoped<UserContext> ();
        }
    }
}