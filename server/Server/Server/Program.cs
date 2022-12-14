using Server.Infrasctucture;
using Server.Service.Vehicle;


using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Server;
using Server.Infrasctucture.Seeder;
using Server.Service;
using Microsoft.AspNetCore.Builder;
using NSwag.Generation.Processors.Security;
using NSwag;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
RegisterServices(builder.Services);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseOpenApi();
app.UseSwaggerUi3();
app.UseCors("AllowDevelopmentSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MigrateDatabase<VehicleDBContext>();
RunDataSeeds(app.Services);

app.Run();



static void RegisterServices(IServiceCollection services)
{
    services.AddInfrastructureServices();
    var infraConfig = new InfrastructureConfiguration();
    services.AddSingleton<IInfrastructureConfiguration>(infraConfig);

    services.AddInfrastructureServices();
    services.AddServiceServices();

    services.AddAutoMapper(
        typeof(VehicleMapperProfile));

    services.AddCors(options =>
    {
        options.AddPolicy(name: "AllowDevelopmentSpecificOrigins",
            builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
    });
    services.AddEntityFrameworkSqlServer()
        .AddDbContext<VehicleDBContext>(opt =>
        {
            opt.UseSqlServer(infraConfig.DbConnectionString);
        }, ServiceLifetime.Scoped);

    services.AddEndpointsApiExplorer();
    services.AddOpenApiDocument(document =>
    {
        document.AddSecurity("Bearer", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
        {
            Type = OpenApiSecuritySchemeType.Http,
            Name = "Authorization",
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = OpenApiSecurityApiKeyLocation.Header,
            Description = "Enter a valid token for JWT Authorization"
        });



        document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("Bearer"));
    });


    services.AddSwaggerGenNewtonsoftSupport();

    services.AddHttpContextAccessor();
    services.AddControllers()
        .AddNewtonsoftJson(o =>
        {
            o.SerializerSettings.Converters.Add(new StringEnumConverter());
        });

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGenNewtonsoftSupport();
}

static void RunDataSeeds(IServiceProvider serviceProvider)
{
    var factory = serviceProvider.GetService<IServiceScopeFactory>();

    using var scope = factory!.CreateScope();
    var dbContext = scope.ServiceProvider.GetService<VehicleDBContext>();

    DataSeeder
        .CreateSeeder(dbContext!);

}