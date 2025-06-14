using AutoMapper;
using Fiap.Api.VerdeVolt.Data;
using Fiap.Api.VerdeVolt.Data.Repository;
using Fiap.Api.VerdeVolt.Models;
using Fiap.Api.VerdeVolt.Services;
using Fiap.Api.VerdeVolt.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region INICIALIZANDO O BANCO DE DADOS
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);
#endregion

#region Registro de Servicos e Repositorios
builder.Services.AddScoped<IMatrizEnergeticaRepository, MatrizEnergeticaRepository>();
builder.Services.AddScoped<IMatrizEnergeticaService, MatrizEnergeticaService>();
builder.Services.AddScoped<IAuthService, AuthService>();
#endregion

#region AutMapper
var mapperConfig = new AutoMapper.MapperConfiguration(
    c => {
        c.AllowNullCollections = true;
        c.AllowNullDestinationValues = true;

        c.CreateMap<MatrizEnergeticaCadastroViewModel, MatrizEnergeticaModel>();
        c.CreateMap<MatrizEnergeticaModel, MatrizEnergeticaExibicaoViewModel>();
    }
);
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

#region Autenticação
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
#endregion

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
