using Preline.Blazor;
using Preline.Blazor.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ModalServiceExtensions
{
    public static Task<ModalResult> OpenMessageBoxAsync(this IModalService service, string message, string? title = null)
        => service.OpenAsync<MessageBox>(new()
        {
            [nameof(MessageBox.Title)] = title,
            [nameof(MessageBox.Message)] = message,
        });
}