using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShowcaseSite.Areas.Identity.Data;
using ShowcaseSite.Data;

[assembly: HostingStartup(typeof(ShowcaseSite.Areas.Identity.IdentityHostingStartup))]
namespace ShowcaseSite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ShowcaseSiteContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ShowcaseSiteContextConnection")));

                services.AddDefaultIdentity<ShowcaseSiteUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ShowcaseSiteContext>();
            });
        }
    }
}