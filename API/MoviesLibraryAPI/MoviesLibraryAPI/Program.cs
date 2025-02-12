using Microsoft.EntityFrameworkCore;
using MoviesLibraryAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// reading the API base address from the configuration
var baseUrl = builder.Configuration["ApiSettings:BaseUrl"];

// connection with database
builder.Services.AddDbContext<MoviesLibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

