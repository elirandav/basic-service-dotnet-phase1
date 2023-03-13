using Users.API;
using Users.API.Service;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IUsersService, UsersService>();
    services.AddScoped<IUsersRepository, UsersRepository>();
    services.AddSingleton<IHttpClientWithHandlerFactory, HttpClientWithHandlerFactory>();
}

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


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

public partial class Program { }