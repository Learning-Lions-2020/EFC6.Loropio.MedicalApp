using MedicalApp.Data.Repository;
using MedicalApp.Domain.Contracts;
using MedicalApp.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MedicalAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalAppDbContext")));

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Add Razor Pages support
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Register your repositories here
builder.Services.AddScoped<IRecordsRepository<Patient>, RecordsRepository<Patient>>();
builder.Services.AddScoped<IRecordsRepository<Doctor>, RecordsRepository<Doctor>>();
builder.Services.AddScoped<IRecordsRepository<Appointment>, RecordsRepository<Appointment>>();
builder.Services.AddScoped<IRecordsRepository<Prescription>, RecordsRepository<Prescription>>();
builder.Services.AddScoped<IMedicalRepository, MedicalRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
