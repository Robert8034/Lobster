
using Application.Data;
using AutoMapper;
using Lobster.Core;
using Lobster.Core.Data;
using Lobster.Core.Domain;
using Lobster.Data;
using Lobster.Server.Services.Authentication;
using Lobster.Server.Services.EncryptionServices;
using Lobster.Server.Services.FollowServices;
using Lobster.Server.Services.PostingServices;
using Lobster.Server.Services.UserServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddControllers();

            //services.AddSingleton<DbContext, LobsterContext>();
            services.AddDbContext<DbContext, LobsterContext>();

            services.AddScoped<IRepository<BaseEntity>, Repository<BaseEntity>>();
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Post>, Repository<Post>>();
            services.AddScoped<IRepository<Like>, Repository<Like>>();
            services.AddScoped<IRepository<Follow>, Repository<Follow>>();
            services.AddScoped<IRepository<Reaction>, Repository<Reaction>>();
            services.AddSingleton<IEncryptionService, EncryptionService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IFollowService, FollowService>();
            services.AddScoped<IPostingService, PostingService>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(AutoMapperProfile));


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

            app.EnsureMigrated();

        }
    }
}
