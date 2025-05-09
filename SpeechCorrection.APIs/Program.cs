using Microsoft.AspNetCore.Mvc;
using SpeechCorrection.APIs.Errors;
using SpeechCorrection.APIs.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region ConfigueServices 
builder.Services.AddControllers();

builder.Services.AddOpenApi();
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

#region MiddleWares
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithRedirects("/error/{0}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 
#endregion

app.Run();
