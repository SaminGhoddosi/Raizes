using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Infrastructure;
using ApiRaizes.Repository;
using Microsoft.AspNetCore.Mvc;
using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Infrastructure;
using ApiRaizes.Repository;
using ApiRaizes.Response;
using ApiRaizes.Services;
namespace MinhaPrimeiraApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            //DEPENDENCE HARVEST --------
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<IHarvestService, HarvestService>();
            builder.Services.AddTransient<IHarvestRepository, HarvestRepository>();
            //DEPENDENCE HARVESTSTORAGE -----------
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<IHarvestStorageService, HarvestStorageService>();
            builder.Services.AddTransient<IHarvestStorageRepository, HarvestStorageRepository>();
            //DEPENDENCE SALE -------
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<ISaleService, SaleService>();
            builder.Services.AddTransient<ISaleRepository, SaleRepository>();
            //DEPENDENCE SPECIES -------
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<ISpeciesService, SpeciesService>();
            builder.Services.AddTransient<ISpeciesRepository, SpeciesRepository>();
            //DEPENDENCE CITY -----
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddTransient<ICityRepository, CityRepository>();
            //DEPENDENCE PROPERTY --------
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<IPropertyService, PropertyService>();
            builder.Services.AddTransient<IPropertyRepository, PropertyRepository>();
            //DEPENDENCE RAW MATERIAL STOCK --------
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<IRawMaterialStockService, RawMaterialStockService>();
            builder.Services.AddTransient<IRawMaterialStockRepository, RawMaterialStockRepository>();
            //DEPENDENCE SOIL HISTORIC --------
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<ISoilHistoricService, SoilHistoricService>();
            builder.Services.AddTransient<ISoilHistoricRepository, SoilHistoricRepository>();
            //DEPENDENCE USER --------
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            //DEPENDENCE SUPPLIER --------
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<ISupplierService, SupplierService>();
            builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
            //DEPENDENCE MEASUREUNIT --------
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<IMeasureUnitService, MeasureUnitService>();
            builder.Services.AddTransient<IMeasureUnitRepository, MeasureUnitRepository>();
            // DEPENDENCE PLANTINGRAWMATERIAL -------
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<IPlantingRawMaterialService, PlantingRawMaterialService>();
            builder.Services.AddTransient<IPlantingRawMaterialRepository, PlantingRawMaterialRepository>();
            // DEPENDENCE RAWMATERIAL ------
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<IRawMaterialService, RawMaterialService>();
            builder.Services.AddTransient<IRawMaterialRepository, RawMaterialRepository>();




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