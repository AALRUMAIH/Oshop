using oshop.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using oshop.Application.Common.Interfaces;
using oshop.Application.Products;
using oshop.Infrastructure.Repositories;
using oshop.Infrastructure.Common.Interfaces;
using oshop.Infrastructure.Persistence;
using oshop.Application.common.interfaces;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();


// Add DbContext with SQL Server configuration.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategory, CategoryService>();

// Register the ICategoryRepository service
builder.Services.AddScoped<ICategoryRepository, CategoryController>();

builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserReposiroy, UserRepositery.UserController>();




builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", coreBuilder =>
          coreBuilder
          .WithOrigins("http://localhost:4200")
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials());
});



// Register Swagger generator services.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Login API",
        Version = "v1",
        Description = "API for user login and authentication"
    });
});



var app = builder.Build();
app.UseCors("CorsPolicy");


//app.UseCors("CorsPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Login API v1");
        options.RoutePrefix = string.Empty; // Set Swagger UI at the root
    });
}


app.UseRouting();


// Global exception handling middleware
app.UseExceptionHandler("/error");

// Use HTTPS redirection.
app.UseHttpsRedirection();

// Use Authorization middleware.
app.UseAuthorization();

// Map controller endpoints.
app.MapControllers();

app.Run();
