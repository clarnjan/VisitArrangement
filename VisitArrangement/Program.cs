using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VisitArrangement.API.Configuration;
using VisitArrangement.API.JwtFeatures;
using VisitArrangement.Domain.Interfaces;
using VisitArrangement.Domain.Services;
using VisitArrangement.Infrastructure.Entities;
using VisitArrangement.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VisitArrangement;Trusted_Connection=True;MultipleActiveResultSets=true");
    options.LogTo(Console.WriteLine).EnableSensitiveDataLogging();
});

builder.Services.AddDbContext<VisitArrangementDbContext>(options =>
{
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VisitArrangement;Trusted_Connection=true;MultipleActiveResultSets=true;");
    options.LogTo(Console.WriteLine).EnableSensitiveDataLogging();
});


builder.Services.AddAutoMapper(typeof(AutomapperConfig).Assembly);

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<VisitArrangementDbContext>();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["validIssuer"],
        ValidAudience = jwtSettings["validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(jwtSettings.GetSection("securityKey").Value))
    };
});

builder.Services.AddScoped<JwtHandler>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IMessagesService, MessagesService>();
builder.Services.AddScoped<IArrangementService, ArrangementService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
    RequestPath = new PathString("/StaticFiles")
});

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
