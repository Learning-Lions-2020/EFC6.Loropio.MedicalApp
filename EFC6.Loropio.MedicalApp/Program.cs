using MedicalApp.Data.Repository;
using MedicalApp.Domain.Contracts;
using MedicalApp.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MedicalAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalAppDbContext")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddScoped<IRecordsRepository<Patient>, RecordsRepository<Patient>>();
builder.Services.AddScoped<IRecordsRepository<Doctor>, RecordsRepository<Doctor>>();
builder.Services.AddScoped<IRecordsRepository<Appointment>, RecordsRepository<Appointment>>();
builder.Services.AddScoped<IRecordsRepository<Prescription>, RecordsRepository<Prescription>>();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();

var app = builder.Build();

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
