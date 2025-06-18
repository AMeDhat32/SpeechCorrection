using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SpeechCorrection.APIs.Errors;
using SpeechCorrection.APIs.Extensions;
using SpeechCorrection.APIs.Middlewares;
using SpeechCorrection.Core.Models.Identity;
using SpeechCorrection.Core.Services.Contract;
using SpeechCorrection.Repository.Data;
using SpeechCorrection.Repository.Data.Identity;
using SpeechCorrection.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region ConfigueServices 
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});
// configure database context
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
builder.Services.AddDbContext<ApplicationContext> (
options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();



// enable swagger service
builder.Services.AddSwaggerServices();



builder.Services.AddOpenApi();
// handle validation errors globally
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
	options.InvalidModelStateResponseFactory = (context) =>
	{
		var errors = context.ModelState.Where(e => e.Value.Errors.Count > 0).SelectMany(e => e.Value.Errors)
			.Select(e => e.ErrorMessage).ToList();
		return new BadRequestObjectResult(new ApiValidationErrorResponse() { Errors = errors });
	};
});




#endregion

var app = builder.Build();

// auto migrate the database
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    var identityContext = services.GetRequiredService<IdentityContext>();
    await identityContext.Database.MigrateAsync();

    var applicationContext = services.GetRequiredService<ApplicationContext>();
    await applicationContext.Database.MigrateAsync();
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred during migration");
}


#region MiddleWares
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
{
    app.AddSwaggerMiddleware();
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
       options
        .WithTheme(ScalarTheme.Mars)
       .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
     );


}

app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithRedirects("/error/{0}");
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 
#endregion

app.Run();
