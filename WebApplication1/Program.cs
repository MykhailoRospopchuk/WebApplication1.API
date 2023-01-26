using Microsoft.EntityFrameworkCore;
using WebApplication1.Configuration;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// take connection string from file
string connection = builder.Configuration.GetConnectionString("WebApiDbConnectionString");
// add context PersonApiDbContext as a services in app
builder.Services.AddDbContext<WebApiDbContext>(options => options.UseSqlServer(connection));



builder.Services.AddAutoMapper(typeof(MapperConfig));



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


