using Microsoft.AspNetCore.Components;

namespace Preline.Blazor.Components.Base;

public abstract class PrelineComponentBase : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> AdditionalAttributes { get; set; } = [];
}