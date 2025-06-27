using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Infrastructure;
using ApiRaizes.Infrastructure;
using ApiRaizes.Repository;
using ApiRaizes.Repository;
using ApiRaizes.Response;
using ApiRaizes.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
namespace MinhaPrimeiraApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<IAuthentication, Authentication>();
            //DEPENDENCE HARVEST --------
            builder.Services.AddScoped<IConnection, Connection>();
            builder.Services.AddScoped<IHarvestService, HarvestService>();
            builder.Services.AddScoped<IHarvestRepository, HarvestRepository>();
            //DEPENDENCE HARVESTSTORAGE -----------
            builder.Services.AddScoped<IConnection, Connection>();
            builder.Services.AddScoped<IHarvestStorageService, HarvestStorageService>();
            builder.Services.AddScoped<IHarvestStorageRepository, HarvestStorageRepository>();
            //DEPENDENCE SALE -------
            builder.Services.AddScoped<IConnection, Connection>();
            builder.Services.AddScoped<ISaleService, SaleService>();
            builder.Services.AddScoped<ISaleRepository, SaleRepository>();
            //DEPENDENCE SPECIES -------
            builder.Services.AddScoped<IConnection, Connection>();
            builder.Services.AddScoped<ISpeciesService, SpeciesService>();
            builder.Services.AddScoped<ISpeciesRepository, SpeciesRepository>();
            //DEPENDENCE CITY -----
            builder.Services.AddScoped<IConnection, Connection>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();
            //DEPENDENCE PROPERTY --------
            builder.Services.AddScoped<IConnection, Connection>();
            builder.Services.AddScoped<IPropertyService, PropertyService>();
            builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
            //DEPENDENCE RAW MATERIAL STOCK --------
            builder.Services.AddScoped<IConnection, Connection>();
            builder.Services.AddScoped<IRawMaterialStockService, RawMaterialStockService>();
            builder.Services.AddScoped<IRawMaterialStockRepository, RawMaterialStockRepository>();
            //DEPENDENCE SOIL HISTORIC --------
            builder.Services.AddScoped<IConnection, Connection>();
            builder.Services.AddScoped<ISoilHistoricService, SoilHistoricService>();
            builder.Services.AddScoped<ISoilHistoricRepository, SoilHistoricRepository>();
            //DEPENDENCE USER --------
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            //DEPENDENCE SUPPLIER --------
            builder.Services.AddScoped<IConnection, Connection>();
            builder.Services.AddScoped<ISupplierService, SupplierService>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
            //DEPENDENCE MEASUREUNIT --------
            builder.Services.AddScoped<IConnection, Connection>();
            builder.Services.AddScoped<IMeasureUnitService, MeasureUnitService>();
            builder.Services.AddScoped<IMeasureUnitRepository, MeasureUnitRepository>();
            // DEPENDENCE PLANTINGRAWMATERIAL -------
            builder.Services.AddScoped<IConnection, Connection>();
            builder.Services.AddScoped<IPlantingRawMaterialService, PlantingRawMaterialService>();
            builder.Services.AddScoped<IPlantingRawMaterialRepository, PlantingRawMaterialRepository>();
            // DEPENDENCE RAWMATERIAL ------
            builder.Services.AddScoped<IConnection, Connection>();
            builder.Services.AddScoped<IRawMaterialService, RawMaterialService>();
            builder.Services.AddScoped<IRawMaterialRepository, RawMaterialRepository>();
            // DEPENDENCE PLANTING
            builder.Services.AddScoped<IConnection, Connection>();
            builder.Services.AddScoped<IPlantingService, PlantingService>();
            builder.Services.AddScoped<IPlantingRepository, PlantingRepository>();

            //ADD BEARER ON SWAGGER 
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>() {}
                    }
                });
            });

            var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:SecretKey"]);


            //ADD JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
        }
    }
}