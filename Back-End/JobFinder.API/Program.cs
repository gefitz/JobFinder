using JobFinder.API.DTO.Mapper;
using JobFinder.API.Service;
using JobFinder.Data.DataBase;
using JobFinder.Data.DataBase.Sql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connection = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddScoped<Command>(opc => new Command(connection));
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<CandidatoService>();
builder.Services.AddScoped<CandidatoDB>();
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
