using Microsoft.AspNetCore.Components;

namespace Preline.Blazor.Services;

public interface IModalService
{
    event Func<Task>? CloseRequestedAsync;

    event Func<RenderFragment, Task>? OpenRequestedAsync;

    void Close(ModalResult result);

    Task CloseAsync(ModalResult result);
    Task<ModalResult> OpenAsync<TContent>(Dictionary<string, object?>? parameters = null) where TContent : IComponent;
    Task<ModalResult> OpenAsync<TContent>(string title, Dictionary<string, object?>? parameters = null) where TContent : IComponent;
}

public class ModalService : IModalService
{
    private bool _completing;
    private TaskCompletionSource<ModalResult>? _result;

    public event Func<Task>? CloseRequestedAsync;
    public event Func<RenderFragment, Task>? OpenRequestedAsync;

    public void Close(ModalResult result)
    {
        if (_completing) return;

        try
        {
            _completing = true;
            _result?.SetResult(result);
        }
        finally
        {
            _completing = false;
        }
    }

    public async Task CloseAsync(ModalResult result)
    {
        if (_completing) return;

        try
        {
            _completing = true;

            if (CloseRequestedAsync != null) await CloseRequestedAsync.Invoke();
            _result?.SetResult(result);
        }
        finally
        {
            _completing = false;
        }
    }

    public Task<ModalResult> OpenAsync<TContent>(string title, Dictionary<string, object?>? parameters = null)
                where TContent : IComponent
    {
        parameters ??= [];
        parameters["Title"] = title;
        return OpenAsync<TContent>(parameters);
    }
    public async Task<ModalResult> OpenAsync<TContent>(Dictionary<string, object?>? parameters = null) where TContent : IComponent
    {
        _result = new();

        var content = Wrap(new RenderFragment(builder =>
        {
            var seq = 0;
            builder.OpenComponent<TContent>(seq++);
            foreach (var (key, value) in parameters ?? [])
            {
                if (value is null) continue;
                builder.AddComponentParameter(seq++, key, value);
            }
            builder.CloseComponent();
        }));

        if (OpenRequestedAsync != null) await OpenRequestedAsync.Invoke(content);
        return await _result.Task;
    }

    private RenderFragment Wrap(RenderFragment fragment) => builder =>
    {
        var seq = 0;
        builder.OpenComponent<CascadingValue<ModalInstance>>(seq++);
        builder.AddComponentParameter(seq++, nameof(CascadingValue<ModalInstance>.Value), new ModalInstance(CloseAsync));
        builder.AddComponentParameter(seq++, nameof(CascadingValue<ModalInstance>.IsFixed), true);
        builder.AddComponentParameter(seq, nameof(CascadingValue<ModalInstance>.ChildContent), fragment);
        builder.CloseComponent();
    };
}

#region Utils

public class ModalInstance(Func<ModalResult, Task> callback)
{
    public Task CancelAsync() => callback(ModalResult.Cancel());
    public Task CloseAsync(object? data = null) => callback(ModalResult.Ok(data));
}

public readonly record struct ModalResult
{
    public bool IsCanceled { get; init; }
    public object? Data { get; init; }

    public static ModalResult Cancel() => new() { IsCanceled = true };
    public static ModalResult Ok(object? data = null) => new() { Data = data };
}

#endregion Utils