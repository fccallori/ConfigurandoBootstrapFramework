using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurandoBootstrapFramework.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigurandoBootstrapFramework
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
          /*  services.AddMvc().AddMvcOptions(options => {
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor((_) => "Campo obrigatório.");
            });*/

            services.AddSingleton<IRepository, MemoryRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();


            /*############ ROTAS
             * if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //  app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => {
                //routes.MapRoute(name: "default", template: "{controller}/{action}");
                //routes.MapRoute(name: "app", template: "App{controller=Home}/{action=Index}");
                //routes.MapRoute(name: "parametro", template: "{controller=Home}/{action=Index}/{id=Vazio}");
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
            
            app.UseStaticFiles();
            app.UseStatusCodePages();*/

        }


    }
}