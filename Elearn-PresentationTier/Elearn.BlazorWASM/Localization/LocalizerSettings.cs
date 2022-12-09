namespace Elearn.BlazorWASM.Localization;

public class LocalizerSettings
{
    public static CultureName NeutralCulture = new CultureName("English", "en-US");

    public static readonly List<CultureName> SupportedCultureNames = new()
    {
        new CultureName("English","en-US"),
        new CultureName("Danish(Denmark)","da-DK"),
        new CultureName("Romanian(Romania)","ro-RO"),
        new CultureName("Italian(Italy)","it-IT")
        
     
    };
}