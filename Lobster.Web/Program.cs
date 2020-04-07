using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Lobster.Client.Services.Validation;
using Lobster.Client.Services.Authentication;
using Lobster.Client.Services.Posting;
using Lobster.Client.Services.FollowServices;
using Blazored.SessionStorage;
using Blazored.LocalStorage;

namespace Lobster.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddSingleton<IValidationService, ValidationService>();
            builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
            builder.Services.AddSingleton<IPostingService, PostingService>();
            builder.Services.AddSingleton<IFollowService, FollowService>();
            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
