using Ardalis.GuardClauses;
using Ardalis.ListStartupServices;
using Authentication.Domain.Persistence.Repositories;
using Authentication.Infrastructure;
using Authentication.Infrastructure.Repositories;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddFastEndpoints();
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

ApplyMigrations(app.Services.GetRequiredService<ApplicationDbContext>());

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
app.UseFastEndpoints();
app.UseSwaggerGen(); // FastEndpoints middleware

app.UseHttpsRedirection();

//SeedDatabase(app);

app.Run();

void ApplyMigrations(ApplicationDbContext context)
{
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

public partial class Program
{
}