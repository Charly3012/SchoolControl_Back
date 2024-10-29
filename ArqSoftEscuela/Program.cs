global using FastEndpoints;
using ArqSoftEscuela.Data;
using ArqSoftEscuela.Mapper;
using ArqSoftEscuela.Repository;
using ArqSoftEscuela.Repository.IRepository;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Construir el ConnectionString usando las variables de entorno
var server = Environment.GetEnvironmentVariable("APOLO");
var user = Environment.GetEnvironmentVariable("SS_USER");
var password = Environment.GetEnvironmentVariable("SS_PASSWORD");
var database = "EscuelaArqSoft"; // Nombre de tu base de datos


// Configurar el ConnectionString manualmente
var connectionString = $"Server={server}; Database={database}; User ID={user}; Password={password}; TrustServerCertificate=true; MultipleActiveResultSets=true";


builder.Services.AddDbContext<ApplicationDBContext>(opciones =>
                                                    opciones.UseSqlServer(connectionString));

// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();


//Mapper
builder.Services.AddAutoMapper(typeof(EscuelaMapper));
builder.Services.AddControllers();

//Repositories
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ISubjectRespository, SubjectRepository>();



//Services


var app = builder.Build();

// Middleware CORS (debe estar antes de los endpoints)
app.UseCors("PermitirTodo");

app.UseFastEndpoints();
app.UseSwaggerGen();
app.Run();

