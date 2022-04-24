using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookAPI.Data;
var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "MyAllowSpecificOrigins";

builder.Services.AddDbContext<BookAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookAPIContext") ?? throw new InvalidOperationException("Connection string 'BookAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "MyAPI V1");
    });
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "MyAPI V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();
