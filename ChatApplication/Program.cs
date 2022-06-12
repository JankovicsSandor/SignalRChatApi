using ChatApplication.Database;
using ChatApplication.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IUserDatabase, UserDatabase>();
builder.Services.AddCors(op => op.AddPolicy("CorsPolicy", build => { build.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("http://localhost:4200"); }));
builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");
app.MapHub<ChatHub>("/hub");
app.MapHealthChecks("/health");

app.Run();
