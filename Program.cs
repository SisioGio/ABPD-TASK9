using TASK9.Services;
using TASK9.Models;
using TASK9.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IDoctorRepository, DoctorRepository>();
builder.Services.AddSingleton<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<MainDbContext>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddControllers();

builder.Services.AddSingleton<Microsoft.Extensions.Logging.ILogger>(provider =>
provider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<TASK9.Controllers.DoctorController>>());

builder.Services.AddSingleton<Microsoft.Extensions.Logging.ILogger>(provider =>
provider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<TASK9.Controllers.PrescriptionController>>());

builder.Services.AddSingleton<Microsoft.Extensions.Logging.ILogger>(provider =>
provider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<TASK9.Controllers.AccountsController>>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;


}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromSeconds(30),
        ValidIssuer = "http://localhost:5227",
        ValidAudience = "http://localhost:5227",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sfsdfsdfdsfsdfsdfsdfsddfaefwewmjcndsnsdjfsdfsdbnhsbvbhcxi"))



    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandling();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
