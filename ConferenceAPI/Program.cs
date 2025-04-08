
using ConferenceAPI.Data;
using ConferenceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbConnect>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING"));
            });

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            
                app.UseSwagger();
                app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Attendees APIs
            app.MapGet("/attendees", async (ApplicationDbConnect context) => 
            await context.Attenddee.ToListAsync());

            app.MapGet("/attendees/{id}", async (ApplicationDbConnect context, int id) => 
            await context.Attenddee.FindAsync(id) is Attendee attendee 
                ? Results.Ok(attendee) 
                : Results.NotFound());
            
            app.MapGet("/Test", (HttpContext httpContext) =>
            {
                return "HelloWorld";
            })
            .WithName("GetHello")
            .WithOpenApi();

            app.Run();
        }
    }
}
