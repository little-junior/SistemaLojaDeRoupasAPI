using SistemaLojaDeRoupas.Repository;
using SistemaLojaDeRoupas.Models;
using SistemaLojaDeRoupas.API.Filters;

namespace SistemaLojaDeRoupas.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("ShopPolicy", policy =>
                {
                    policy.WithOrigins("http://localhost:5500").AllowAnyMethod();
                });
            });

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<LogResultFilter>();
            });

            // builder.Services.AddControllers();

            builder.Services.AddSingleton<IRepository<Venda>, VendaRepository>();
            builder.Services.AddSingleton<IRepository<Devolucao>, DevolucaoRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
