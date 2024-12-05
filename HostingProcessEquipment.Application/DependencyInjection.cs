using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using HostingProcessEquipment.Application.PipeLinesBehaviours;


namespace HostingProcessEquipment.Application;

public static class DependencyInjection
    {
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //add services
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
            config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        services.AddValidatorsFromAssembly(assembly);
        
        return services;
    }
}

