using BookingHotel_APi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("BookingHotel.")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", policy =>
    {
        // Allow both localhost and 127.0.0.1, and without a trailing slash
        policy.WithOrigins("https://localhost:7129", "http://localhost:5133")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();  // Add AllowCredentials if you need to support cookies or authentication
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
