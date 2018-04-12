using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GZY_CMS.Core.Autofac;
using GZY_CMS.Model;
using GZY_CMS.SystemModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GZY_CMS.WebServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            // Configuration = configuration;
            var builder = new ConfigurationBuilder()
               .SetBasePath(hostingEnvironment.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true)
               .AddJsonFile($"appconfig/myappconfig.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.RegisterController();
            services.AddMvc();
            var cons = Configuration.GetSection("ConnectionString")["GZY_CMS"];
            var conss = Configuration.GetSection("ConnectionString")["GZY_System"];
            services.AddDbContextPool<GZYCMSContext>(
                    options => options.UseMySql(cons));
            services.AddDbContextPool<SystemContext>(
                   options => options.UseMySql(conss));
            return services.ReplacementIOC(new AutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
