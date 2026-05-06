using Microsoft.EntityFrameworkCore;
using WEBAPISP_CRUDAPP.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//enable httpclient factory
builder.Services.AddHttpClient();
builder.Services.AddDbContext<AptonlineContext>(option => option.UseSqlServer("Data Source=localhost;Initial Catalog=APTONLINE;Integrated Security=True;Encrypt=False;Trust Server Certificate=true;"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
