using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CourseProject.Mvc2.Models;
using Microsoft.AspNetCore.Identity;

namespace CourseProject.Mvc2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationIdentityContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionUser")));

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(opts => {
                opts.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                opts.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                opts.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                opts.Password.RequireDigit = false; // требуются ли цифры
                opts.User.RequireUniqueEmail = true;    // уникальный email
                opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz1234567890"; // допустимые символы
            })
                .AddEntityFrameworkStores<ApplicationIdentityContext>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}