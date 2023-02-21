using Microsoft.EntityFrameworkCore;
using SahafWebAPI.DataProvider;
using SahafWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookDataProvider, BookDataProvider>();
builder.Services.AddScoped<IBookStoreDataProvider, BookStoreDataProvider>();
builder.Services.AddScoped<IUserDataProvider, UserDataProvider>();
builder.Services.AddScoped<IReportDataProvider, ReportDataProvider>();



builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDatabase"));

});


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
