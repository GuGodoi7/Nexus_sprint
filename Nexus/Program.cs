using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Nexus.Extensions;
using NX.Database;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("NXContext");


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo
{
    Title = "Nexus",
    Version = "v1",
    Description = "API para gerenciamento de usuários, produtos e pedidos do projeto Nexus.",
    Contact = new OpenApiContact() { Email = "nexus.project.2024@gmail.com", Name = "Nexus" }
}));


builder.Services.AddDbContext<NXContext>(options =>
{
    options.UseOracle(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nexus API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
