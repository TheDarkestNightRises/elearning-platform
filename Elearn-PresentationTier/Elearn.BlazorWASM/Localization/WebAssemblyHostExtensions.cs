using System.Globalization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Elearn.BlazorWASM.Localization;

public static class WebAssemblyHostExtensions
{
    // the source code was inspired by https://www.youtube.com/watch?v=e8IkSFQmonE 
    public async static Task SetDefaultCulture(this WebAssemblyHost host)
    {
        var localStorage = host.Services.GetRequiredService<ILocalStorageService>();
        var cultureString = await localStorage.GetItemAsync<string>("culture");

        CultureInfo cultureInfo;

        if (!string.IsNullOrWhiteSpace(cultureString))
        {
            cultureInfo = new CultureInfo(cultureString);
        }
        else
        {
            cultureInfo = new CultureInfo(LocalizerSettings.NeutralCulture.Name);
        }

        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
    }
}