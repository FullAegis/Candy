using System.Text;
using Candy.BLL.Interfaces;
using Candy.BLL.Services;
using Candy.DAL;
using Candy.DAL.Interfaces;
using Candy.DAL.Repositories;
using Candy.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Oapi = Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
  // Définir les information générales de notre API dans swagger
  c.SwaggerDoc("v1", new Oapi::OpenApiInfo { Title = "Candy Shop", Version = "v0.0.1" });

  // Déclarer une schema de sécurité de type Bearer pour Swagger
  c.AddSecurityDefinition("Bearer", new Oapi::OpenApiSecurityScheme
  { Description = "Token bearer utilise le scheama (Bearer {token})"
  , Name = "Authorization"                 // Nom de l'en-tête HTTP
  , In = Oapi::ParameterLocation.Header    // Indique que l'info est envoyé dans le header HTTP
  , Type = Oapi::SecuritySchemeType.ApiKey // Déclare une clé API de type Bearer
  , Scheme = "Bearer"                      // Nom du schéma utilisé
  });

  // Ajoute une exigence de sécurité globale pour toutes les routes prottégés par [Authorize]
  c.AddSecurityRequirement(new Oapi::OpenApiSecurityRequirement {
    { new Oapi::OpenApiSecurityScheme
      { Reference = new Oapi::OpenApiReference 
        { Type = Oapi::ReferenceType.SecurityScheme
        , Id = "Bearer"
        }
      , Scheme = "oauth2" // Nécéssaire pour swagger (interface)
      , Name = "Bearer"
      , In = Oapi::ParameterLocation.Header
      }
    , new List<string>() // Liste vide => Pas de scopes spécifique nécéssaires...
    }
  });
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<CandyDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services.AddSingleton<TokenManager>();

// Configuration de l'authentification JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
    options.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidateLifetime = true,
      ValidIssuer = builder.Configuration["jwt:issuer"],
      ValidAudience = builder.Configuration["jwt:audience"],
      IssuerSigningKey =
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"]!))
    };
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
