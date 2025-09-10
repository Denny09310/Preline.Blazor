using TailwindMerge;

namespace Preline.Blazor.Internals;

internal readonly struct CssBuilder
{
    private static readonly TwMerge tw = new();
    
    private readonly List<string> _classes;

    public CssBuilder()
    {
        _classes = [];
    }

    public CssBuilder(params IEnumerable<string> classes)
    {
        _classes = [.. classes];
    }

    public CssBuilder Add(string classes) => Add(classes, true);

    public CssBuilder Add(string classes, bool when)
    {
        if (when && !string.IsNullOrWhiteSpace(classes))
        {
            _classes.Add(classes);
        }
        return this;
    }

    public CssBuilder Add(IReadOnlyDictionary<string, object>? attributes)
    {
        if (attributes == null)
        {
            return this;
        }

        if (attributes.TryGetValue("class", out var obj)
            && obj is string str
            && !string.IsNullOrWhiteSpace(str))
        {
            _classes.Add(str);
        }

        return this;
    }

    public string Build() => tw.Merge([.. _classes]) ?? "";
}