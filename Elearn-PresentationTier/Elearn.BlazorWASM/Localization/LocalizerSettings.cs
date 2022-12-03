namespace Elearn.BlazorWASM.Localization;

public class LocalizerSettings
{
    public static CultureName NeutralCulture = new CultureName("English", "en-us");

    public static readonly List<CultureName> SupportedCultureNames = new()
    {
        new CultureName("English","en-US"),
        new CultureName("Spanish(Mexico)","es-MX")
    };
}