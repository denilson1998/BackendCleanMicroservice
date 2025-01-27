using Ardalis.GuardClauses;
using Ardalis.ListStartupServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Coupons.Api.OptionsSetup;
using Coupons.Infrastructure;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

string? connectionString = builder.Configuration.GetConnectionString("connection");
Guard.Against.Null(connectionString);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);



builder.Services.AddFastEndpoints();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(b =>
{
    b.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    };
});
builder.Services.AddAuthorization();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
//builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();


builder.Services.AddSwaggerGen(s =>
{
    s.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
    });
});



builder.Services.SwaggerDocument(o =>
{
    o.ShortSchemaNames = true;
});

// add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
builder.Services.Configure<ServiceConfig>(config =>
{
    config.Services = new List<ServiceDescriptor>(builder.Services);

    // optional - default path to view services is /listallservices - recommended to choose your own path
    config.Path = "/listservices";
});

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    //containerBuilder.RegisterModule(new DefaultCoreModule());
    containerBuilder.RegisterModule(new AutofacInfrastructureModule(builder.Environment.IsDevelopment()));
});

var app = builder.Build();

//ApplyMigrations(app.Services.GetRequiredService<ApplicationDbContext>());

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseShowAllServicesMiddleware(); // see https://github.com/ardalis/AspNetCoreStartupServices
}
else
{
    app.UseDefaultExceptionHandler(); // from FastEndpoints
    app.UseHsts();
}

app.UseAuthentication();

app.UseAuthorization();

app.UseFastEndpoints();

app.UseSwaggerGen(); // FastEndpoints middleware

app.UseHttpsRedirection();

//app.UseAuthorization();

//SeedDatabase(app);

app.Run();

void ApplyMigrations(ApplicationDbContext context)
{
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}