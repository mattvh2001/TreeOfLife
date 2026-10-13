using App.Api.Endpoints;
using App.Api.Extensions;
using App.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddFrontendCors(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors(ServiceCollectionExtensions.FrontendCorsPolicy);

app.MapTrackEndpoints();

app.Run();
