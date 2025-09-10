using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Preline.Blazor.Internals;

internal class TemplateHostRenderer(HtmlRenderer renderer)
{
    public Task<string> RenderFragment(RenderFragment fragment)
    {
        return renderer.Dispatcher.InvokeAsync(async () =>
        {
            var output = await renderer.RenderComponentAsync<RenderFragmentHost>(
                ParameterView.FromDictionary(new Dictionary<string, object?>
                {
                    [nameof(RenderFragmentHost.Fragment)] = fragment
                }));

            return output.ToHtmlString();
        });
    }

    private sealed class RenderFragmentHost : IComponent
    {
        private RenderHandle _renderHandle;

        [Parameter]
        public RenderFragment? Fragment { get; set; }

        public void Attach(RenderHandle renderHandle)
        {
            _renderHandle = renderHandle;
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            parameters.SetParameterProperties(this);
            _renderHandle.Render(Fragment ?? (builder => { }));
            return Task.CompletedTask;
        }
    }
}