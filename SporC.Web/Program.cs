using Microsoft.EntityFrameworkCore;
using SporCDAL.Contexts;
using Microsoft.AspNetCore.Mvc;

using SporC.BL.Abstract;
using SporC.BL.Concrete;
using SporC.DAL.Repositories.Abstract;
using SporC.DAL.Repositories.Concrete;
using SporC.Web.AutoMapper;
using SporC.Web.Extensions;
using SporC.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SporC.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SqlDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString(connectionstring)));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(SporCMapper));
            builder.Services.AddSporCServices();
           

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/User/Login";
                options.AccessDeniedPath = "/Post/Index";
                options.SlidingExpiration = true;
            });

          
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.MapAreaControllerRoute(
    name: "Dashboard",
    areaName: "Dashboard",
    pattern: "Dashboard/{controller=Home}/{action=Index}/{id?}"
);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Dashboard",
                    areaName: "Dashboard",
                    pattern: "Dashboard/{controller=Admin}/{action=Login}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Post}/{action=Index}/{id?}");
            });


            app.Run();
        }
    }
}