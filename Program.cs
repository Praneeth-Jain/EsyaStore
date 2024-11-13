using EsyaStore.Data.Context;
using EsyaStore.Middleware;
using Microsoft.EntityFrameworkCore;
using System;

namespace EsyaStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
                options.UseSqlServer(ConnectionString);
            }
           );

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseSession();

            
            app.UseHttpsRedirection();
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.UseStatusCodePagesWithReExecute("/NotFound");
            app.UseMiddleware<RequestLoggingMiddleware>();

            app.UseMiddleware<RoleBasedRedirectionMiddleware>();



            app.MapRazorPages();
            app.Run();
        }
    }
}
