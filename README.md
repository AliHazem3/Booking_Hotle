The connection between Hotel.APIs and WebApplicationHotel is 

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

app.UseCors("MyPolicy");
app.UseAuthorization();

Not Core HttpClient
