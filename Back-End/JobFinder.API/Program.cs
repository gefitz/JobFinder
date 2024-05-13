using JobFinder.API.DTO.Mapper;
using JobFinder.API.Service;
using JobFinder.Data.DataBase;
using JobFinder.Data.DataBase.Sql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connection = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddScoped<Command>(opc => new Command(connection));
builder.Services.AddAutoMapper(typeof(MapperProfile));

#region Services
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<CidadeService>();
#endregion

#region DB
builder.Services.AddScoped<CandidatoDB>();
builder.Services.AddScoped<LoginDB>();
builder.Services.AddScoped<CidadeDB>();    
#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["jwt:issuer"],
        ValidAudience = builder.Configuration["jwt:audience"],
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:secretkey"])),
    };
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowSpecificOrigin",
        build =>
        {
            build.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowSpecificOrigin");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
