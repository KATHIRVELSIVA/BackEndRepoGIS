using CrudMicroProject.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudMicroProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificationOrigin",
                    builder => builder.WithOrigins("http://localhost:3000/")
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod());
            }
            );



            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version())));

            builder.Services.AddControllers();
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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("AllowSpecificationOrigin");

            app.Run();
        }
    }
}
