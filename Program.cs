using API_RFID;
using API_RFID.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexion a BD
builder.Services.AddSqlServer<EntradasContext>(builder.Configuration.GetConnectionString("cnEntradas"));

// Se creara una instancia de la dependencia a nivel de controlador/clase
builder.Services.AddScoped<IAreasService, AreasService>();
builder.Services.AddScoped<ITiposTurnosService, TiposTurnosService>(); 
builder.Services.AddScoped<ITrabajadoresService, TrabajadoresService>(); 
builder.Services.AddScoped<IEntradasSalidasService, EntradasSalidasService>(); 
builder.Services.AddCors(options =>
    {
        // this defines a CORS policy called "default"
        options.AddPolicy("default", policy =>
        {
            policy.WithOrigins("http://localhost:5242")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("default");

app.MapControllers();

app.Run();
