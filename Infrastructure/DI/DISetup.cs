using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.api.Infrastructure.Data;
using Product.api.Infrastructure.Data.Contexts;

namespace Product.api.Infrastructure.DI {
    public static class DISetup {
        public static void ConfigureMongoDb (this IServiceCollection services, IConfiguration configuration) {

            string connectionString = configuration.GetSection ("Database:ConnectionString").Value;
            bool isSsl = Convert.ToBoolean (configuration.GetSection ("Database:IsSsl").Value);

            services.AddScoped<MongoDBConnection> (ctx => new MongoDBConnection (connectionString, isSsl));
            services.AddScoped<ProductContext> ();
            services.AddScoped<UserContext> ();
        }
    }
}