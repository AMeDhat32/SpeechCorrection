using Microsoft.AspNetCore.Mvc;
using SpeechCorrection.APIs.Errors;
using SpeechCorrection.APIs.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region ConfigueServices 
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});

// enable swagger service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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

#region MiddleWares
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithRedirects("/error/{0}");
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 
#endregion

app.Run();
