using System.Text;
using AutoMapper;
using CinemaAPI.Profiles;
using CinemaAPI.Services;
using CinemaFuncs.Authorization;
using FilmesApi.Data;
using FilmesApi.Profiles;
using FilmesAPI.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<AppDbContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IdadeMinima", policy => 
    {
        policy.Requirements.Add(new IdadeMinimaRequirement(18));
    });
});

builder.Services.AddSingleton<IAuthorizationHandler, IdadeMinimaHandler>();

builder.Services.AddScoped<FilmeService, FilmeService>();
builder.Services.AddScoped<CinemaService, CinemaService>();

builder.Services.AddAutoMapper(
    typeof(CinemaProfile),
    typeof(EnderecoProfile), 
    typeof(FilmeProfile), 
    typeof(GerenteProfile), 
    typeof(SessaoProfile)); 

builder.Services.AddAuthentication(auth => 
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(token =>
{
    token.RequireHttpsMetadata = false;
    token.SaveToken = true;
    token.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("chave-qualquer-aqui")),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
