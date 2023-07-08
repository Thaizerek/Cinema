using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;
using Cinema.Models;

namespace Cinema
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
            services.AddControllersWithViews();
            services.AddRazorPages();


            services.Configure<IdentityOptions>(options =>
            {
                // Konfiguracja ustawień hasła
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;

                // Konfiguracja blokady konta
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // Konfiguracja ustawień uwierzytelniania
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
            });

            // Dodanie administratora

            //CreateUserWithRole(services.BuildServiceProvider()).GetAwaiter().GetResult();
        

        services.AddDbContext<CinemaContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CinemaContext")));
        }
        // Ta metoda tworzy użytkownika o roli "Administrator"
        private async Task CreateUserWithRole(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Sprawdź czy rola "Administrator" już istnieje
            if (!await roleManager.RoleExistsAsync("Administrator"))
            {
                // Jeśli nie, dodaj rolę "Administrator"
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            // Sprawdź czy administrator już istnieje
            var adminUser = await userManager.FindByNameAsync("admin@example.com");
            if (adminUser == null)
            {
                // Jeśli nie, utwórz użytkownika "admin@example.com" z rolą "Administrator"
                var user = new IdentityUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com"
                };

                var result = await userManager.CreateAsync(user, "AdminPassword123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.MapRazorPages();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Filmy}/{action=Index}/{id?}");
            });
        }
    }
}
/*

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;
using Microsoft.AspNetCore.Identity;

namespace Cinema
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
            services.AddControllersWithViews();

            services.AddDbContext<CinemaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<CinemaContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Konfiguracja ustawień hasła
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;

                // Konfiguracja blokady konta
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // Konfiguracja ustawień uwierzytelniania
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
            });

            // Dodanie administratora
            CreateUserWithRole(services.BuildServiceProvider()).Wait();
        }

        // Ta metoda tworzy użytkownika o roli "Administrator"
        private async Task CreateUserWithRole(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Sprawdź czy rola "Administrator" już istnieje
            if (!await roleManager.RoleExistsAsync("Administrator"))
            {
                // Jeśli nie, dodaj rolę "Administrator"
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            // Sprawdź czy administrator już istnieje
            var adminUser = await userManager.FindByNameAsync("admin@example.com");
            if (adminUser == null)
            {
                // Jeśli nie, utwórz użytkownika "admin@example.com" z rolą "Administrator"
                var user = new IdentityUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com"
                };

                var result = await userManager.CreateAsync(user, "AdminPassword123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Konfiguracja środowiska, loggera, itp.

            // ...
        }
    }
}
*/