using Microsoft.AspNetCore.Components.Web;
using Preline.Blazor.Internals;
using Preline.Blazor.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPrelineServices(this IServiceCollection services)
    {
        services.AddScoped<HtmlRenderer>();
        services.AddScoped<TemplateHostRenderer>();

        services.AddSingleton<IModalService, ModalService>();
        return services;
    }
}
