using HostingProcessEquipment.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using HostingProcessEquipment.Application.Interfaces;

namespace HostingProcessEquipment.Infrastructure;

public static  class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IContractRepository, ContractRepository>();
        services.AddScoped<IProductionFacilityRepository, ProductionFacilityRepository>();
        services.AddScoped<IEquipmentTypeRepository, EquipmentTypeRepository>();
        return services;
    }
}

