using Preline.Blazor.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddComponents(this IServiceCollection services)
    {
        services.AddSingleton<IModalService, ModalService>();
        return services;
    }
}
