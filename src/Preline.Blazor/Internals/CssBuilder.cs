namespace Preline.Blazor.Internals;

internal readonly struct CssBuilder
{
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

    public CssBuilder Add(Dictionary<string, object> attributes)
    {
        if (attributes.TryGetValue("class", out var obj)
            && obj is string str
            && !string.IsNullOrWhiteSpace(str))
        {
            attributes.Remove("class");
            _classes.Add(str);
        }

        return this;
    }

    public string Build()
    {
        if (_classes.Count == 0)
            return string.Empty;

        // Dictionary: key → (bestPriority, bestClass)
        var map = new Dictionary<string, (int priority, string cls)>(capacity: _classes.Count * 2);
        var order = new List<string>(map.Capacity);

        foreach (var chunk in _classes)
        {
            var span = chunk.AsSpan();
            int i = 0, len = span.Length;
            while (i < len)
            {
                // skip spaces
                while (i < len && span[i] == ' ') i++;
                if (i >= len) break;

                // read next token
                int start = i;
                while (i < len && span[i] != ' ') i++;
                var token = span[start..i].ToString();

                // compute key & priority
                GetKeyAndPriority(token, out var key, out var priority);

                if (map.TryGetValue(key, out var existing))
                {
                    if (priority >= existing.priority)
                    {
                        map[key] = (priority, token);
                    }
                }
                else
                {
                    map[key] = (priority, token);
                    order.Add(key);
                }
            }
        }

        // build final list in the order keys were first encountered
        var result = new List<string>(order.Count);
        foreach (var key in order)
            result.Add(map[key].cls);

        return string.Join(' ', result);
    }

    // Determines the de-duplication key (including variants) and priority
    private static void GetKeyAndPriority(string cls, out string key, out int priority)
    {
        // !important detection
        var isImportant = cls.Length > 0 && cls[0] == '!';
        var clean = isImportant ? cls[1..] : cls;

        // custom property
        if (clean.Length >= 5 && clean[0] == '[' && clean[1] == '-' && clean[^1] == ']')
        {
            key = clean;
            priority = 3;
            return;
        }

        // split variants vs base
        // look for last ':'
        int lastColon = clean.LastIndexOf(':');
        string variants, baseCls;
        if (lastColon >= 0)
        {
            variants = clean[..lastColon];
            baseCls = clean[(lastColon + 1)..];
        }
        else
        {
            variants = string.Empty;
            baseCls = clean;
        }

        // extract base-key
        int lastDash = baseCls.LastIndexOf('-');
        var baseKey = lastDash >= 0 ? baseCls[..lastDash] : baseCls;

        key = variants.Length > 0
            ? variants + ":" + baseKey
            : baseKey;

        // priorities: custom props 3, important 2, normal 1
        priority = isImportant ? 2 : 1;
    }
}
