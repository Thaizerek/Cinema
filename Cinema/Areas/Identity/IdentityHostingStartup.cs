using System;
using Cinema.Areas.Identity.Data;
using Cinema.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Cinema.Areas.Identity.IdentityHostingStartup))]
namespace Cinema.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CinemaContextIdentity>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CinemaContext")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CinemaContextIdentity>();
            });
        }
    }
}