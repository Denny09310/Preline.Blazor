namespace Preline.Blazor.Internals;

internal readonly struct StyleBuilder
{
    private readonly List<string> _styles;

    public StyleBuilder()
    {
        _styles = [];
    }

    public StyleBuilder(params IEnumerable<string> styles)
    {
        _styles = [.. styles];
    }

    public StyleBuilder Add<T>(string property, T value) => Add(property, value, true);

    public StyleBuilder Add<T>(string property, T value, bool when)
    {
        if (when)
        {
            _styles.Add($"{property}:{value}");
        }

        return this;
    }

    public StyleBuilder Add(IReadOnlyDictionary<string, object>? attributes)
    {
        if (attributes == null)
        {
            return this;
        }

        if (attributes.TryGetValue("style", out var obj)
            && obj is string str
            && !string.IsNullOrWhiteSpace(str))
        {
            _styles.Add(str);
        }

        return this;
    }

    public string Build() => string.Join(";", _styles
        .SelectMany(style => style.Split(";", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)));
}