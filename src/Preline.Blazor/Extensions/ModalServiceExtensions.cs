using Preline.Blazor.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ModalServiceExtensions
{
    public static ModalResult OpenAsync(this IModalService service, string title, Dictionary<string, object>? parameters = null)
    {
        parameters ??= [];
        parameters["Title"] = title;
        return service.OpenAsync(title, parameters);
    }
}