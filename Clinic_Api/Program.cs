using Clinic_Api.Application.Queries.GetPatientById;
using Clinic_Api.Domain.Interfaces;
using Clinic_Api.Infrastructure.DbSettings;
using Clinic_Api.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<IPatientsRepository, PatientsRepository>();

builder.Services.AddMediatR((m) => m.RegisterServicesFromAssemblyContaining(typeof(GetPatientByIdQuery)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(cfg =>
{
    var commentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var commentsFullPath = Path.Combine(AppContext.BaseDirectory, commentFile);

    cfg.IncludeXmlComments(commentsFullPath);

    cfg.SwaggerDoc("ClinicApiSpecification", new()
    {
        Title = "Clinic Api",
        Version = "1",
        Contact = new()
        {
            Name = "Kacper Tylec",
            Email = "kacper.tylec1999@gmail.com",
            Url = new Uri("https://github.com/kacper51011")
        },
        Description =
        "<h5>Created as a simulation of basic Api for a clinic." +
        "<h5>The API let us:</h5>" +
        "<ul>" +
        "<li>Create, Update, Delete Patients</li>" +
        "<li>Get Patient By Id </li>" +
        "<li>Get Patients with Paginated results </li>" +
        "<li>Search for Patients by first name or(and) last name simultanously </li>" +
        "<li>Get zpl command template for badge specific for every patient, can be used by client mobile apps which integrates with printers</li>" +
        " <ul/>" +
        ""
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint("/swagger/ClinicApiSpecification/swagger.json", "Clinic Api");
        setup.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
