namespace Elearn.BlazorWASM.Localization;

public class CultureName
{
    public string Name { get; set; }
    public string Culture { get; set; }

    public CultureName(string name, string culture)
    {
        Name = name;
        Culture = culture;
    }
}