using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace CityInfo.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc() // use MVC pattern
                    .AddMvcOptions(o =>
                    {
                      o.OutputFormatters.Add( new XmlDataContractSerializerOutputFormatter());
                    });
                    //.AddJsonOptions(o =>
                    // {
                    //     if(o.SerializerSettings.ContractResolver != null)
                    //     {
                    //         var castedResolver = o.SerializerSettings.ContractResolver
                    //            as DefaultContractResolver;
                    //         castedResolver.NamingStrategy = null;
                    //     }
                    // });
                    // commented code is used for serialization,json properties wriitten exactly as in entity
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // in dev env
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();

            // use MVC Middleware
            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });


        }
    }
}
