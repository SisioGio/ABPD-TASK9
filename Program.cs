using TASK8.Services;
using TASK8.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IDoctorRepository, DoctorRepository>();
builder.Services.AddSingleton<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddSingleton<MainDbContext>();
builder.Services.AddControllers();

builder.Services.AddSingleton<Microsoft.Extensions.Logging.ILogger>(provider =>
provider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<TASK8.Controllers.DoctorController>>());

builder.Services.AddSingleton<Microsoft.Extensions.Logging.ILogger>(provider =>
provider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<TASK8.Controllers.PrescriptionController>>());

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
