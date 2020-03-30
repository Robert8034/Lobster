using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Data;
using Lobster.Core.Data;
using Lobster.Core.Domain;
using Lobster.Data;
using Lobster.Server.Services.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Lobster.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<DbContext, LobsterContext>();
            services.AddControllers();
            services.AddScoped<IRepository<BaseEntity>, Repository<BaseEntity>>();
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseClientSideBlazorFiles<Web.Program>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToClientSideBlazor<Web.Program>("index.html");
            });
        }
    }
}
