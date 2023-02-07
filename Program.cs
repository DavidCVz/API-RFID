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
