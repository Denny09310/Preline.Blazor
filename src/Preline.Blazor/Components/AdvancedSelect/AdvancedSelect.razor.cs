using Preline.Blazor.Internals;
using System.Text.Json.Serialization;

namespace Preline.Blazor.Components;

public static partial class Styles
{
    public sealed class AdvancedSelect
    {
        public string? Description { get; set; }
        public string? Dropdown { get; set; }
        public string? Icon { get; set; }
        public string? Option { get; set; }
        public string? Search { get; set; }
        public string? SearchNoResult { get; set; }
        public string? TagsInput { get; set; }
        public string? TagsItems { get; set; }
        public string? Toggle { get; set; }
        public string? Wrapper { get; set; }
    }
}

public sealed class AdvancedSelectInitParameters
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DescriptionClasses { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DropdownClasses { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? IconClasses { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OptionClasses { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OptionTemplate { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Placeholder { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SearchClasses { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SearchNoResultClasses { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TagsInputClasses { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TagsItemsClasses { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ToggleClasses { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ToggleTag { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WrapperClasses { get; set; }

    internal static async Task<AdvancedSelectInitParameters> CreateAsync<TOption>(AdvancedSelect<TOption> select, TemplateHostRenderer renderer)
        where TOption : notnull
    {
        var styles = select.Styles;

        var parameters = new AdvancedSelectInitParameters()
        {
            Placeholder = select.Placeholder,
            WrapperClasses = styles?.Wrapper,
            DescriptionClasses = styles?.Description,
            DropdownClasses = styles?.Dropdown,
            IconClasses = styles?.Icon,
            OptionClasses = styles?.Option,
            SearchClasses = styles?.Search,
            SearchNoResultClasses = styles?.SearchNoResult,
            TagsInputClasses = styles?.TagsInput,
            TagsItemsClasses = styles?.TagsItems,
            ToggleClasses = styles?.Toggle,
        };

        if (select.ToggleContent is not null)
        {
            parameters.ToggleTag = await renderer.RenderFragment(select.ToggleContent);
        }

        if (select.ItemContent is not null)
        {
            parameters.OptionTemplate = await renderer.RenderFragment(select.ItemContent);
        }

        return parameters;
    }
}