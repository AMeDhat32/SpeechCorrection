using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpeechCorrectionAPIs.SpeechCorrection.Core.Models.Identity;
using SpeechCorrectionAPIs.SpeechCorrection.Repository.Identity;
namespace SpeechCorrectionAPIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region ConfigureServices
            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                // options.Password.RequireNonAlphanumeric = false;
                // options.Password.RequireDigit = false;
                // options.Password.RequireLowercase = false;
                // options.Password.RequireUppercase = false;
                // options.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           

            #endregion

            var app = builder.Build();

            #region ConfigureMiddleware
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            app.UseHttpsRedirection();

            app.UseAuthorization(); 
            #endregion

            app.Run();
        }
    }
}
