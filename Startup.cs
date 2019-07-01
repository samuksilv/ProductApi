using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Product.api.Infrastructure.DI;
using Swashbuckle.AspNetCore.Swagger;

namespace Product.api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);
            services.ConfigureMongoDb (this.Configuration);
            services.AddApiVersioning (o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion (1, 0);
            });

            services.AddSwaggerGen (options => {
                options.SwaggerDoc ("v1", new Info { Title = "Product Api", Version = "v1" });
                options.DescribeAllEnumsAsStrings ();
                options.DescribeStringEnumsInCamelCase ();
                options.DescribeAllParametersInCamelCase ();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseSwagger ();
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Product Api");
            });

            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}