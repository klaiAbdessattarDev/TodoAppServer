using Microsoft.EntityFrameworkCore;
using TodoAppServer.Data;
using TodoAppServer.Repositories;

namespace TodoAppServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var Configuration = builder.Configuration;
            // Add services to the container.
            builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            builder.Services.AddDbContext<TodoAppServerContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TodoAppServerConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowLocalhost");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}