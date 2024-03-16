
using System.Reflection;
using CatalogAPI.API;
using DataAccess.Data;
using DataAccess.DbAccess;
using StatusService;

namespace CatalogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            
            builder.Services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "ProductCatalogAPI"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                doc.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
            builder.Services.AddSingleton<IProductData, ProductData>();
            builder.Services.AddHostedService<StatusLogger>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.ConfigureApi();

            app.UseAuthorization();

            app.Run();
        }
    }
}
