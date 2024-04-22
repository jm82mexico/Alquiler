using CleanArquitecture.Domain.Alquiler;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArquitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        services.AddTransient<PrecioService>();

        return services;
    }
}
