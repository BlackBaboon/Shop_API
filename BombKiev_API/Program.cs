using Microsoft.EntityFrameworkCore;
using DataAccess.Model;
using DataAccess.Wrapper;
using Domain.Interfaces;
using BusinessLogic.Services;
namespace BombKiev_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(
                "Data Source=Daun;Initial Catalog=ЛарионовДота;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=false;TrustServerCertificate=true"));

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IGoodService, GoodService>();

            builder.Services.AddControllersWithViews();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.MapDefaultControllerRoute();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}