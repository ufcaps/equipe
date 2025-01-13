using Backend.Presentation.Api.Extensions;
using Backend.Presentation.Api.Middlewares;
using Backend.Core.Application.Extensions;
using Backend.Infra.Persistence.Extensions;
using Backend.Infra.Auth.Jwt.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.ConfigureAuthApp();
builder.Services.ConfigureCorsPolicy();
builder.Services.ConfigurePersistenceApp();
builder.Services.ConfigureApplicationApp();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
