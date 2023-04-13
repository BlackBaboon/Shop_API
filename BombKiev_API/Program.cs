using Microsoft.EntityFrameworkCore;
using DataAccess.Model;
using DataAccess.Wrapper;
using Domain.Interfaces;
using BusinessLogic.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

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

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IGoodsListService, GoodsListService>();

            builder.Services.AddScoped<IShipService, ShipService>();

            builder.Services.AddScoped<ILikedListService, LikedListService>();

            builder.Services.AddScoped<ICommentService,  CommentService>();


            builder.Services.AddControllersWithViews();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "Z_V1",
                    Title = "Anti_Kiev API",
                    Description = "API для работы с базой данных магазина",
                    Contact = new OpenApiContact
                    {
                        Name = "ЧВК Вагнер",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "МО РФ",
                        Url = new Uri("https://example.com/license")
                    }
                });
            });

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