using FinalApi.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSetting>(
        builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddSingleton<ProdcutService>();

builder.Services.AddControllersWithViews();
// Add services
builder.Services.AddSingleton<ProductService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger for testing
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
