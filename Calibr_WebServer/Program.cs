using Calibr_WebServer.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Domain.Interfaces;
using DataAccess.Model;
using BusinessLogic.Services;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Calibr_WebServer.Auth;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Calibr_WebServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthenticationCore();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<ProtectedSessionStorage>();
            builder.Services.AddScoped<ProtectedLocalStorage>();

            string home_connectionstring = "Data Source=Daun;Initial Catalog=ЛарионовДота;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=false;TrustServerCertificate=true";
            string lab116p_connectionstring = "Data Source=lab116-p;Initial Catalog=ЛарионовДота;User=sa;Password=12345;MultipleActiveResultSets=True;Encrypt=false;TrustServerCertificate=true";

            builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(
                home_connectionstring));
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IGoodService, GoodService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IGoodsListService, GoodsListService>();
            builder.Services.AddScoped<IShipService, ShipService>();
            builder.Services.AddScoped<ILikedListService, LikedListService>();
            builder.Services.AddScoped<ICommentService, CommentService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}