using ApiCoreCrudDepartamentos.Data;
using ApiCoreCrudDepartamentos.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Departamentos",
        Description = "Api crud de Departamentos",
        Version = "v1"
    });
});

string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryDepartamentos>();
builder.Services.AddDbContext<DepartamentoContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api Crud de Departamentos v1");
    options.RoutePrefix = "";
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
