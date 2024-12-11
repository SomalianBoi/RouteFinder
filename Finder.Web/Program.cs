using Finder.Application.Interfaces;
using Finder.Application.Services;
using Finder.Domain.RepoInterfaces;
using Finder.Infrastructure.Data;
using Finder.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Finder.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(option => 
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IAirlineService, AirlineService>();
            builder.Services.AddScoped<IAirlineRepository, AirlineRepository>();

            builder.Services.AddScoped<IPlaneService, PlaneService>();
            builder.Services.AddScoped<IPlaneRepository, PlaneRepository>();

            builder.Services.AddScoped<IAirportService, AirportService>();
            builder.Services.AddScoped<IAirportRepository, AirportRepository>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
