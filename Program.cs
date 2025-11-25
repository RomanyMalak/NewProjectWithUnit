
using Microsoft.EntityFrameworkCore;
using Second_API_project.Dbcontext;
using Second_API_project.Controllers;
using Second_API_project.Repository;
using Second_API_project.Model;
using Second_API_project.Uint_of_Ropository;

namespace Second_API_project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<App_context>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("myconn"))
            );
           // builder.Services.AddScoped(typeof(IRepository<>), typeof(MainRepository<>));
            builder.Services.AddScoped<IUnitofwork, UnitRrpository>();
            // builder.Services.AddScoped<UnitRrpository>();
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

                       

            app.Run();
        }
    }
}
