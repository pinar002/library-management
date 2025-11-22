using Microsoft.EntityFrameworkCore;
using KutuphaneAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle
builder.Services.AddControllers();

// Veritabanı bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS - frontendden gelen isteklere izin ver
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder
            .WithOrigins("http://localhost:5123", "https://localhost:5123")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// HTTP requestlerini HTTPS e yonlendir
app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
